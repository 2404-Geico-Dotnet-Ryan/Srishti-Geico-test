class ManagerService
{
    ManagerRepo mr;

        public ManagerService(ManagerRepo mr)
    {
        this.mr = mr;
    }

    //Register
    public Manager? Register(Manager mg)
    {
        //let's not let them register if the role is anything other than "Manager"
        if (mg.Role != "manager")
        {
            //reject them
            System.Console.WriteLine("Invalid Role - Please try again!");
            return null;
        }

        //let's not let them register if the Username is already taken! :o
        //Get all managers
        List<Manager> allManagers = mr.GetAllManagers() ?? []; //adding ?? [] repairs Unhandled exception. System.NullReferenceException: Object reference not set to an instance of an object.
        //Check if our new Managername matches any of the Managernames on all those Managers.
        foreach (Manager manager in allManagers)
        {
            if (manager.Username == mg.Username)
            {
                System.Console.WriteLine("Username already taken! - Please try again!");
                return null;//reject them
            }
        }
        //IF we make it this far, then we are saying that the role is good to go 
        //and the username is good to go.
        return mr.AddManager(mg);
    }

    //Login
    public Manager? Login(string username, string password)
    {
        //Get all Managers
        List<Manager> allManagers = mr.GetAllManagers() ?? []; //adding ?? [] repairs Unhandled exception. System.NullReferenceException: Object reference not set to an instance of an object.

        //check each one to see if we find a match.
        foreach (Manager manager in allManagers)
        {
            //If matching Managername and password, they 'login' -> return that Manager
            if (manager.Username == username && manager.Password == password)
            {
                //Yay! Login!
                return manager; //us returning the Manager will indicate success.
            }
        }

        //If we make it this far - we didnt find a match! Oh no!
        System.Console.WriteLine("Invalid Username / Password combo! Please Try Again!");
        return null; //reject the login
    }
}