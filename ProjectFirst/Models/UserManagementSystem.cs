class UserManagementSystem
{
    public int UserId {get; set;}
    public string UserName { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }
    
    public bool PasswordActive { get; set;}


    public UserManagementSystem()
    {
        UserName = "";
        EmailAddress = "";
        PhoneNumber = "";
    }

    public UserManagementSystem(int userid, string username, string emailaddress, string phonenumber, bool passwordactive)
    {
        UserId = userid;
        UserName = username;
        EmailAddress = emailaddress;
        PhoneNumber = phonenumber;
        PasswordActive = passwordactive;

    }



    public override string ToString()
    {
        return $"userid: {UserId}, username: {UserName}, emailaddress: {EmailAddress}, phonenumber: {PhoneNumber}, passwordactive : {PasswordActive}";
    }

}