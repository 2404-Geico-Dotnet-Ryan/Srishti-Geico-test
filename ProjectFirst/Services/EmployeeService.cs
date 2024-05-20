class EmployeeService
{
    /*
        Services:
            -view password expiration date
            -Reset Password    
    */
    EmployeeRepo er = new(); //employeeService needs to access the repo layer so we are adding here

    //let's write out some methods..//don't think about UI in this layer...//only processes /action that is happening

    public void ViewPasswordExpirationDate(DateTime lastPasswordChangedDate)
    {
        int passwordExpirationDays = 90;
        DateTime currentDate = DateTime.Now;

        DateTime passwordExpirationDate = lastPasswordChangedDate.AddDays(passwordExpirationDays);

        if (currentDate > passwordExpirationDate)
        {
            System.Console.WriteLine("Your Password has expired. Please change it.");
        }
        else
            System.Console.WriteLine("Your password is valid until: " + passwordExpirationDate);
    }


    public List<Employee> GetEmployees()
    {
        List<Employee> allEmployees = er.GetAllEmployees();
       return allEmployees;

    }

   
     
    public bool IsPasswordExpired(DateTime lastpasswordchangeddate)
    {
        int passwordExpirationDays = 90;

        //calculate the expiration date
       DateTime expirationDate = lastpasswordchangeddate.AddDays(passwordExpirationDays);

        // Compare with the current date
       return DateTime.Now > expirationDate;
    }

  //Ew, a Trivial Service!
    public Employee? GetEmployee(int id)
    {
        return er.GetEmployee(id);
    }

 public Employee? UpdateEmployee(Employee e)
    {
        return er.UpdateEmployee(e);
    }

}