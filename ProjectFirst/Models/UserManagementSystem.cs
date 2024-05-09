class UserManagementSystem
{
    public int UserId {get; set;}
    public string FullName { get; set; }
    public string EmailAddress { get; set; }
    public int PhoneNumber { get; set; }
    public bool PasswordActive { get; set;}


    public UserManagementSystem()
    {
        FullName = "";
        EmailAddress = "";
    }

    public UserManagementSystem(int userid, string fullname, string emailaddress, int phonenumber, bool passwordactive)
    {
        UserId = userid;
        FullName = fullname;
        EmailAddress = emailaddress;
        PhoneNumber = phonenumber;
        PasswordActive = passwordactive;

    }



    public override string ToString()
    {
        return $"userid : {UserId}, fullname : {FullName}, emailaddress : {EmailAddress}, phonenumber : {PhoneNumber}, passwordactive : {PasswordActive}";
    }

}