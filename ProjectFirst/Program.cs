class Program
{
    static UserService us = new();
    static void Main(string[] args)
    {
          //Going to start off with the call to Main Menu still
        MainMenu();
    }

 private static void MainMenu()
    {
        //Similar menu different options.
        System.Console.WriteLine("Welcome to the User App!");
        bool keepGoing = true;
        while (keepGoing)
        {
            System.Console.WriteLine("Please Pick an Option Down Below:");
            System.Console.WriteLine("=================================");
            System.Console.WriteLine("[1] ");
            System.Console.WriteLine("[2]");
            System.Console.WriteLine("[0] Quit");
            System.Console.WriteLine("=================================");

            int input = int.Parse(Console.ReadLine() ?? "0");
            //Same Validation method copied over
            input = ValidateCmd(input, 4);

            //Extracted to method - uses switch case to determine what to do next.
            keepGoing = DecideNextOption(input);
        }
    }







}


