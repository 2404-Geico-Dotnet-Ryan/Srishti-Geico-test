class UserService
{
    /*
        Services:
            -view password expiration date
            -Change Password
            
    */

    UserRepo ur = new(); //UserService needs to access the repo layer so we are adding here

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
        System.Console.WriteLine("Your password is valid until: " + passwordExpirationDate );
    }

    public void ChangePassword()
    {
        System.Console.WriteLine();
    }





}