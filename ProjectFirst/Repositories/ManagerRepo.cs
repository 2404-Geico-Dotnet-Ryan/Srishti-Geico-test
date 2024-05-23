using Microsoft.Data.SqlClient;

class ManagerRepo
{
   // ManagerStorage managerStorage = new();- no need of this as we are establishing connection to database now so we need sth here in repo
     private readonly string _connectionString;

    //Dependency Injection -> Constructor Injection
    public ManagerRepo(string connString)
    {
        _connectionString = connString;
    }

    //add, get-one, get-all, update, and delete

    public Manager AddManager(Manager mn)
    {
       
       //Set up DB connection
        using SqlConnection connection = new(_connectionString); //SQL Connection inherits a really popular known interface called I Disposable.  
        connection.Open();

        //Create the SQL String
        string sql = "INSERT INTO dbo.[Manager] OUTPUT inserted.* VALUES (@Username, @Password, @Role)"; //OUTPUT inserted.*- This is a special way for us to get DML statements are inserts, updates, and deletes to return 
                                                                                //something umm the way that we do that in the insert command is right here we just do update or output inserted dot star insert dot star 
                                                                                //just means essentially like all information about the records that are inserted.

        //Set up SqlCommand Object and use its methods to modify the Parameterized Values
        using SqlCommand cmd = new(sql, connection);
        cmd.Parameters.AddWithValue("@Username", mn.Username);
        cmd.Parameters.AddWithValue("@Password", mn.Password);
        cmd.Parameters.AddWithValue("@Role", mn.Role);

        //Execute the Query
        //cmd.ExecuteNonQuery();//This executes a non-select SQL statement (inserts, updates, deletes )
        using SqlDataReader reader = cmd.ExecuteReader();

        //Extract the Results
        if (reader.Read())
        {
            //If Read() found data -> then extract it.
            Manager newManager = new();
            newManager.ManagerId = (int)reader["ManagerId"];
            newManager.Username = (string)reader["Username"];
            newManager.Password = (string)reader["Password"];
            newManager.Role = (string)reader["Role"];

            return newManager;
        }
        else
        {
            //Else Read() found nothing -> Insert Failed. :(
            return null;
        }
    }

    public Manager? GetManager(int id)
    {
         return null; 
    }

    public List<Manager> GetAllManagers()
    {
       List<Manager> managers = []; //empty collection object

        try
        {
            //Set up DB Connection
            using SqlConnection connection = new(_connectionString); //sqlconnection object created
            connection.Open();

            //Create the SQL String
            string sql = "SELECT * FROM dbo.[Manager]"; //I like the way you phrase that by the nature of the operation, right by the nature of what a select statement is, is to return data, so we don't need that output.

            //Set up SqlCommand Object
            using SqlCommand cmd = new(sql, connection); //the SQL Command object which is actually responsible for executing these commands line 75

            //Execute the Query
            using var reader = cmd.ExecuteReader(); //flexing options here with the use of var.

            //Extract the Results
            while (reader.Read())
            {
                //for each iteration -> extract the results to a User object -> add to list.
                Manager newManager = BuildUser(reader);

                //don't return! Instead Add to List!
                managers.Add(newManager);
            }

            return managers;
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
            System.Console.WriteLine(e.StackTrace);
            return null;
        }
    }

    public Manager? Updatemanager(Manager updatedmanager)
    {
       return null;
    }

    public Manager? Deletemanager(Manager mn)
    {
       return null;

    }

      //Helper Method
    private static Manager BuildUser(SqlDataReader reader) //BuildUser really doesn't make sense outside the context of this user repo, so to help encourage that, I'm keeping it private, meaning it's only to be used by this user.
    {
        Manager newManager = new();
        newManager.ManagerId = (int)reader["ManagerId"];
        newManager.Username = (string)reader["Username"];
       newManager.Password = (string)reader["Password"];
        newManager.Role = (string)reader["Role"];

        return newManager;
    }
}