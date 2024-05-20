using System.Transactions;

class Program
{
    static EmployeeService es = new();
    static ManagerService ms = new();
    static void Main(string[] args)
    {
        //Going to start off with the call to Main Menu still
        MainMenu();
    }



    private static void MainMenu()
    {
        //Similar menu different options.
        System.Console.WriteLine("=========Welcome to the User Management App!==========");
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
            System.Console.WriteLine("[0] Quit");
            System.Console.WriteLine("=================================");

            int input = int.Parse(Console.ReadLine() ?? "0");
            //Same Validation method copied over
            input = ValidateCmd(input, 5);

            //Extracted to method - uses switch case to determine what to do next.
            keepGoing = DecideNextOption(input);
        }
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
            case 0:
            default:
                {
                    //If option 0 or anything else -> set keepGoing to false.
                    return false;
                }
        }

        return true;
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


