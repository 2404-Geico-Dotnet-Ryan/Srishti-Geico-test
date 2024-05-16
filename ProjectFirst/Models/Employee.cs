using System.ComponentModel;

class Employee
{
    public int EmployeeId {get; set;}
    public string EmployeeName { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }
    public long LastPasswordChangedDate { get; set;}
    public int PasswordExpirationDays { get; set;}
    public bool PasswordActive { get; set;}


    public Employee()
    {
        EmployeeName = "";
        EmailAddress = "";
        PhoneNumber = "";
    }

    public Employee(int employeeid, string employeename, string emailaddress, string phonenumber, long lastpasswordchangeddate, int passwordexpirationdays, bool passwordactive)
    {
        EmployeeId = employeeid;
        EmployeeName = employeename;
        EmailAddress = emailaddress;
        PhoneNumber = phonenumber;
        LastPasswordChangedDate = lastpasswordchangeddate;
        PasswordExpirationDays = passwordexpirationdays;
        PasswordActive = passwordactive;

    }



    public override string ToString()
    {
        return $"employeeid: {EmployeeId}, employeename: {EmployeeName}, emailaddress: {EmailAddress}, phonenumber: {PhoneNumber}, lastpasswordchangeddate: {LastPasswordChangedDate}, passwordexpirationdays: {PasswordExpirationDays}, passwordactive : {PasswordActive}";
    }

}