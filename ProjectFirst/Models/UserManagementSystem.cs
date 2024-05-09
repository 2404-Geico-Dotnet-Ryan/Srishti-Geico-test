class UserManagementSystem
{
    public int UserId {get; set;}
    public string FullName { get; set; }
    public string EmailAddress { get; set; }
    public int PhoneNumber { get; set; }


    public UserManagementSystem()
    {
        FullName = "";
        EmailAddress = "";
    }

    public UserManagementSystem(int userid, string fullname, string emailaddress, int phonenumber)
    {
        UserId = userid;
        FullName = fullname;
        EmailAddress = emailaddress;
        PhoneNumber = phonenumber;
    }


    public override string ToString()
    {
        return $"userid : {UserId}, fullname : {FullName}, emailaddress : {EmailAddress}, phonenumber : {PhoneNumber}";
    }

}