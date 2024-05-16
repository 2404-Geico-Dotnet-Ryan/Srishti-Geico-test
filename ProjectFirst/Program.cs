class Program
{
    static ManagerService ms = new();
    static void Main(string[] args)
    {
        //Going to start off with the call to Main Menu still
        MainMenu();
    }

    private static void MainMenu()
    {
        //Similar menu different options.
        System.Console.WriteLine("Welcome to the User Management App!");
        bool keepGoing = true;
        while (keepGoing)
        {
            System.Console.WriteLine("Please Pick an Option Down Below:");
            System.Console.WriteLine("=================================");
            System.Console.WriteLine("[1] View All Employees ");
            System.Console.WriteLine("[2] View Employee with Active Password");
            System.Console.WriteLine("[3] View Employee with Expired Password");
            System.Console.WriteLine("[4] View Employee Password Expiration Date");
            System.Console.WriteLine("[4] Reset Employee Password");
            System.Console.WriteLine("[0] Quit");
            System.Console.WriteLine("=================================");

            int input = int.Parse(Console.ReadLine() ?? "0");
            //Same Validation method copied over
            input = ValidateCmd(input, 4);

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
    List<Employee> allEmployees = e.GetEmployees();
    
    System.Console.WriteLine("=== List of Available Movies ===");
    foreach (Employee e in allEmployees)
        {
            System.Console.WriteLine(e);
        }
        System.Console.WriteLine("=================================");
    }


             



private static void ViewEmployeeWithActivePassword()
{






}




private static void ViewEmployeeWithExpiredPassword()
{





}





private static void ViewEmployeePasswordExpirationDate()
{





}






private static void ResetEmployeePassword()
{





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


