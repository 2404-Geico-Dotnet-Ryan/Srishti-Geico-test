using System.Transactions;

class Program
{
    static EmployeeService es;
    static ManagerService ms;
    static Manager? currentManager = null;
    static void Main(string[] args)
    {
       string path =@"C:\Users\A214163\Documents\RevatureTraining\Srishti-Geico-test\ProjectFirst\usermgmt-app-db.txt";
       
     
        string connectionString = File.ReadAllText(path);

        System.Console.WriteLine(connectionString); //can remove later
         ManagerRepo mr = new(connectionString);
         ms = new(mr);

         EmployeeRepo er = new(connectionString); // <-- we'll need to add the connection string in the near future
         es = new(er);

        //Lets just quickly test the Repo all by itself - and then if it works
        //we can assume nothing else changed -> therefore it should integrate cleanly into the app.
       // Manager newManager = new(0, "brian", "pass4", "manager");
      // System.Console.WriteLine("Added Manager: " + mr.AddManager(newManager));



            //Going to start off with the call to Main Menu still
      
     // MainMenu();
       InitMenu(); //temporarily comment out the menu So we're not running the full application.
    }

     private static void InitMenu()
    {
        System.Console.WriteLine("=========Welcome to the User management App!=========");
        bool keepGoing = true;
        while (keepGoing)
        {
            System.Console.WriteLine("Please Pick an Option Down Below:");
            System.Console.WriteLine("=================================");
            System.Console.WriteLine("[1] Login");
            System.Console.WriteLine("[2] Register");
            System.Console.WriteLine("[0] Quit");
            System.Console.WriteLine("=================================");

            int input = int.Parse(Console.ReadLine() ?? "0");
            //Same Validation method copied over
            input = ValidateCmd(input, 2);

            keepGoing = DecideInitOption(input); //Slightly different method.
        }
    }
    private static void MainMenu()
    {
        System.Console.WriteLine("Welcome Back, " +currentManager?.Username);
        bool keepGoing = true;
        while (keepGoing)
        {
            System.Console.WriteLine("Please Pick an Option Down Below:");
            System.Console.WriteLine("=================================");
            System.Console.WriteLine("[1] View All Employees ");
            System.Console.WriteLine("[2] View Employee with Active Password");
            System.Console.WriteLine("[3] View Employee with Expired Password");
            System.Console.WriteLine("[4] View Employee Password Expiration Date");
            System.Console.WriteLine("[5] Reset Employee Password");
            System.Console.WriteLine("[6] Add Employee");
            System.Console.WriteLine("[0] Quit");
            System.Console.WriteLine("=================================");

            int input = int.Parse(Console.ReadLine() ?? "0");
            //Same Validation method copied over
            input = ValidateCmd(input, 6);

            //Extracted to method - uses switch case to determine what to do next.
            keepGoing = DecideNextOption(input);
        }
        //end of loop means keepGoing = false -> Logout
        currentManager = null;
    }

     private static bool DecideInitOption(int input)
    {
        switch (input)
        {
            case 1:
                Login(); break;
            case 2:
                Register(); break;
            case 0:
            default:
                //If option 0 or anything else -> set keepGoing to false.
                return false;
        }

        return true;
    }
    private static bool DecideNextOption(int input)
    {
        switch (input)
        {
            case 1:
                {
                    RetrievingAllEmployees();
                    break;
                }
            case 2:
                {
                    ViewEmployeeWithActivePassword();
                    break;
                }
            case 3:
                {
                    ViewEmployeeWithExpiredPassword();
                    break;
                }
            case 4:
                {
                    ViewEmployeePasswordExpirationDate();
                    break;
                }
            case 5:
                {
                    ResetEmployeePassword();
                    break;
                }
            case 6:
                {
                    AddEmployee();
                    break;
                }

            case 0:
            default:
                {
                    //If option 0 or anything else -> set keepGoing to false.
                    return false;
                }
        }

        return true;
    }

     private static void Register()
    {
        System.Console.WriteLine("Please Enter a New Username: ");
        string username = Console.ReadLine() ?? "";
        //Could Add some validation here to loop if Username is empty or taken.

        System.Console.WriteLine("Please Enter a New Password: ");
        string password = Console.ReadLine() ?? "";
        //Could Add some validation here to loop if Password is empty or not long enough.

        //Lets not set an ID and assume their Role to be 'user'
        //My Register method chose a different tactic of passing in the whole Manager
        Manager? newManager = new(0, username, password, "manager");
        newManager = ms.Register(newManager); //should return the new manager.
        if (newManager != null)
        {
            System.Console.WriteLine("New Manager Registered!");
        }
        else
        {
            System.Console.WriteLine("Registration Failed! Please Try Again!");
        }
    }


    private static void Login()
    {
        while (currentManager == null)
        {
            System.Console.WriteLine("Please Enter Your Username: ");
            string username = Console.ReadLine() ?? "";

            System.Console.WriteLine("Please Enter Your Password: ");
            string password = Console.ReadLine() ?? "";

            //Setting the currentUser variable signifies Logging in. If Login() fails it will remain null.
            currentManager = ms.Login(username, password);
            if (currentManager == null)
                System.Console.WriteLine("Login Failed. Please Try Again.");
        }

        //Now that they are logged in -> send them to Main Menu.
        MainMenu();
        //When this MainMenu ends, so does this calling of Login() which means go
        //back to InitMenu().
    }
    private static void RetrievingAllEmployees()
    {
        //use our service methods now.
        List<Employee> allEmployees = es.GetEmployees();

        System.Console.WriteLine("=== List of all Employees ===");
        foreach (Employee e in allEmployees)
        {
            System.Console.WriteLine(e);
        }
        System.Console.WriteLine("=================================");
    }



    private static void ViewEmployeeWithActivePassword()
    {
        List<Employee> allEmployees = es.GetEmployees();

        System.Console.WriteLine("=== List of Employees with Active Password ===");

        foreach (Employee e in allEmployees)
        {
            if (e.PasswordExpirationDate > DateTime.Now)
            {
                System.Console.WriteLine(e);
            }
        }
        System.Console.WriteLine("=================================");
    }


    private static void ViewEmployeeWithExpiredPassword()
    {

        List<Employee> allEmployees = es.GetEmployees();

        System.Console.WriteLine("=== List of Employees with Expired Password ===");
        foreach (Employee e in allEmployees)
        {
            if (e.PasswordExpirationDate <= DateTime.Now)
            {
                System.Console.WriteLine(e);
            }
        }
        System.Console.WriteLine("=================================");

    }

    /*
        private static void ViewEmployeePasswordExpirationDate()
        {
            Employee lookupemployee = new();
            System.Console.WriteLine("Enter an Employee ID");
            int input = int.Parse(Console.ReadLine() ?? "0");
            lookupemployee = es.GetEmployee(input);


            bool isitexpired = es.IsPasswordExpired(lookupemployee.LastPasswordChangedDate);

            if (isitexpired == true)
            {
                System.Console.WriteLine("Is the employee's password expired: " + isitexpired);
                System.Console.WriteLine("Employee's password expired on: " + lookupemployee.PasswordExpirationDate);
            }
            else
            {
                System.Console.WriteLine("Is the employee's password expired: " + isitexpired);
                System.Console.WriteLine("Employee's password expires on: " + lookupemployee.PasswordExpirationDate);
            }
        }

    */


    private static void ViewEmployeePasswordExpirationDate()
    {
        Employee lookupemployee = new();

        System.Console.WriteLine("Enter an Employee ID");
        int input = int.Parse(Console.ReadLine() ?? "0");
        //input validation

        if (input > 0)
        {
            lookupemployee = es.GetEmployee(input);

            bool isitexpired = es.IsPasswordExpired(lookupemployee.LastPasswordChangedDate);

            if (isitexpired == true)
            {
                System.Console.WriteLine("Is the employee's password expired: " + isitexpired);
                System.Console.WriteLine("Employee's password expired on: " + lookupemployee.PasswordExpirationDate);
            }
            else
            {
                System.Console.WriteLine("Is the employee's password expired: " + isitexpired);
                System.Console.WriteLine("Employee's password expires on: " + lookupemployee.PasswordExpirationDate);
            }
        }
        else
        {
            System.Console.WriteLine("Invalid employee ID. Please enter a positive integer.");
        }
    }


    private static void ResetEmployeePassword()
    {

        Employee lookupemployee = new(); //new object of the Employee type

        try
        {
            System.Console.WriteLine("Enter an Employee ID");
            int input = int.Parse(Console.ReadLine() ?? "0");

            if (input <= 0)
            {
                System.Console.WriteLine("Invalid employee ID.");
                return;
            }
            lookupemployee = es.GetEmployee(input);

            System.Console.WriteLine("Employee to be Updated: " + lookupemployee);
            lookupemployee.PasswordExpirationDate = DateTime.Now;

            lookupemployee.LastPasswordChangedDate = DateTime.Now;
            lookupemployee.PasswordActive = false;
            lookupemployee = es.UpdateEmployee(lookupemployee);
            System.Console.WriteLine("Updated Employee Password: " + lookupemployee);
        }
        catch (FormatException)
        {
            System.Console.WriteLine("Invalid input. Please enter a valid Employee ID.");
        }
    }


        static void AddEmployee()
        {
            System.Console.WriteLine("Enter Employee UserName: ");
           string inputName = (Console.ReadLine() ?? "");

           System.Console.WriteLine("Enter Employee Email Id : ");
           string inputEmail = (Console.ReadLine() ?? "");

            System.Console.WriteLine("Enter Employee Phone Number : ");
           string inputPhoneNum = (Console.ReadLine() ?? "");

            Employee? newEmployee = new Employee(0,inputName, inputEmail, inputPhoneNum, DateTime.Now, DateTime.Now.AddDays(90), true, 1);

            es.AddEmployee(newEmployee);
            System.Console.WriteLine("Newly Added Employee: " + newEmployee) ;

        }



    //Generic Command Input Validator - assume 1-maxOption are the number of options. and 0 is an option to quit.
    private static int ValidateCmd(int cmd, int maxOption)
    {
        while (cmd < 0 || cmd > maxOption)
        {
            System.Console.WriteLine("Invalid Command - Please Enter a command 1-" + maxOption + "; or 0 to Quit");
            cmd = int.Parse(Console.ReadLine() ?? "0");
        }

        //if input was already valid - it skips the if statement and just returns the value.
        return cmd;
    }


}


