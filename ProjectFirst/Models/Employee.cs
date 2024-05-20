using System.ComponentModel;

class Employee
{
    public int EmployeeId {get; set;}
    public string EmployeeName { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime LastPasswordChangedDate { get; set;}
    public DateTime PasswordExpirationDate { get; set;}
    public bool PasswordActive { get; set;}

    public Employee()
    {
        EmployeeName = "";
        EmailAddress = "";
        PhoneNumber = "";
    }

    public Employee(int employeeid, string employeename, string emailaddress, string phonenumber, DateTime lastpasswordchangeddate, DateTime passwordexpirationdate, bool passwordactive)
    {
        EmployeeId = employeeid;
        EmployeeName = employeename;
        EmailAddress = emailaddress;
        PhoneNumber = phonenumber;
        LastPasswordChangedDate = lastpasswordchangeddate;
        PasswordExpirationDate = passwordexpirationdate;
        PasswordActive = passwordactive;
    }

    public override string ToString()
    {
        return $"employeeid: {EmployeeId}, employeename: {EmployeeName}, emailaddress: {EmailAddress}, phonenumber: {PhoneNumber}, lastpasswordchangeddate: {LastPasswordChangedDate}, passwordexpirationdate: {PasswordExpirationDate}, passwordactive : {PasswordActive}";
    }

}