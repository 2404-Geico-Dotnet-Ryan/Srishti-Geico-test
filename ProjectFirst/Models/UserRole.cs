class UserRole
{
    public int UserId {get; set;}
    public string RoleName { get; set; }
   

    public UserRole()
    {
        RoleName = "";
      
    }

    public UserRole(int userid, string rolename)
    {
        UserId = userid;
        RoleName = rolename;
    }

     public override string ToString()
    {
        return $"userid: {UserId}, rolename: {RoleName}";
    }



}