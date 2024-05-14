using System.ComponentModel;

class UserAccount
{
    public int UserId {get; set;}
    public string UserName { get; set; }
    public string Password {get; set;}
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }
    public long LastPasswordChangedDate { get; set;}
    public int PasswordExpirationDays { get; set;}
    public bool PasswordActive { get; set;}


    public UserAccount()
    {
        UserName = "";
        Password = "";
        EmailAddress = "";
        PhoneNumber = "";
    }

    public UserAccount(int userid, string username, string password, string emailaddress, string phonenumber, long lastpasswordchangeddate, int passwordexpirationdays, bool passwordactive)
    {
        UserId = userid;
        UserName = username;
        Password = password;
        EmailAddress = emailaddress;
        PhoneNumber = phonenumber;
        LastPasswordChangedDate = lastpasswordchangeddate;
        PasswordExpirationDays = passwordexpirationdays;
        PasswordActive = passwordactive;

    }



    public override string ToString()
    {
        return $"userid: {UserId}, username: {UserName}, emailaddress: {EmailAddress}, phonenumber: {PhoneNumber}, passwordactive : {PasswordActive}";
    }

}