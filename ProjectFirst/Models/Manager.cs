class Manager
{
    public int ManagerId {get; set;}
    public string Username { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
   

    public Manager()
    {
        Username = "";
        Password = "";
        Role = "";
    }

    public Manager(int managerid, string username, string password, string role)
    {
        ManagerId = managerid;
        Username = username;
        Password = password;
        Role = role;
    }

     public override string ToString()
    {
        return $"managerid: {ManagerId}, username: {Username}, password: {Password} role: {Role}";
    }



}