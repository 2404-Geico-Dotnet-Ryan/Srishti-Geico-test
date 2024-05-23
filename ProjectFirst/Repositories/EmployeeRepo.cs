using System;
using Microsoft.Data.SqlClient;
class EmployeeRepo
{
    // CRUD operations
    //EmployeeStorage employeeStorage = new();
    private readonly string _connectionString;

    //Dependency Injection -> Constructor Injection
    public EmployeeRepo(string connString)
    {
        _connectionString = connString;
    }

    public Employee AddEmployee(Employee e)
    {
        //Set up DB Connection
        using SqlConnection connection = new(_connectionString);
        connection.Open();

        //Create the SQL String
        string sql = "INSERT INTO dbo.Employee OUTPUT inserted.* VALUES (@EmployeeName, @EmailAddress, @PhoneNumber, @LastPasswordChangedDate, @PasswordExpirationDate, @PasswordActive, @ManagerId)";

        //Set up SqlCommand Object and use its methods to modify the Parameterized Values
        using SqlCommand cmd = new(sql, connection);
        cmd.Parameters.AddWithValue("@EmployeeName", e.EmployeeName);
        cmd.Parameters.AddWithValue("@EmailAddress", e.EmailAddress);
        cmd.Parameters.AddWithValue("@PhoneNumber", e.PhoneNumber);
        cmd.Parameters.AddWithValue("@LastPasswordChangedDate", e.LastPasswordChangedDate);
        cmd.Parameters.AddWithValue("@PasswordExpirationDate", e.PasswordExpirationDate);
        cmd.Parameters.AddWithValue("@PasswordActive", e.PasswordActive);
        cmd.Parameters.AddWithValue("@ManagerId", e.ManagerId);

        //Execute the Query
        // cmd.ExecuteNonQuery(); //This executes a non-select SQL statement (inserts, updates, deletes)
        using SqlDataReader reader = cmd.ExecuteReader();

        //Extract the Results
        if (reader.Read())
        {
            //If Read() found data -> then extract it.
            Employee newEmployee = new();
            newEmployee.EmployeeId = (int)reader["EmployeeId"];
            newEmployee.EmployeeName = (string)reader["EmployeeName"];
            newEmployee.EmailAddress = (string)reader["EmailAddress"];
            newEmployee.PhoneNumber = (string)reader["PhoneNumber"];
            newEmployee.LastPasswordChangedDate = (DateTime)reader["LastPasswordChangedDate"];
            newEmployee.PasswordExpirationDate = (DateTime)reader["PasswordExpirationDate"];
            newEmployee.PasswordActive = (bool)reader["PasswordActive"];
            newEmployee.ManagerId = (int)reader["ManagerId"];


            return newEmployee;
        }
        else
        {
            //Else Read() found nothing -> Insert Failed. :(
            return null;
        }
    }

    public Employee? GetEmployee(int employeeid)
    {
        try
        {
            //Set up DB Connection
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            //Create the SQL String
            string sql = "SELECT * FROM dbo.[Employee] WHERE EmployeeId = @EmployeeId";

            //Set up SqlCommand Object
            using SqlCommand cmd = new(sql, connection);
            cmd.Parameters.AddWithValue("@EmployeeId ", employeeid);

            //Execute the Query
            using var reader = cmd.ExecuteReader();

            //Extract the Results
            if (reader.Read())
            {
                //for each iteration -> extract the results to a User object -> add to list.
                Employee newEmployee = BuildEmployee(reader);
                return newEmployee;
            }

            return null; //Didnt find anyone :(

        }
        catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
            System.Console.WriteLine(e.StackTrace);
            return null;
        }

    }

    //THIS IS A NEW METHOD!
    //No Parameters because...get everything is get everything. No options to choose.
    public List<Employee>? GetAllEmployees()
    {
        //I am choosing to return a List because that is a much more common collection to
        //work with. It does mean I have to do a little bit of work here - but its not bad.
        List<Employee> employees = [];

        try
        {
            //Set up DB Connection
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            //Create the SQL String
            string sql = "SELECT * FROM dbo.Employee";

            //Set up SqlCommand Object
            using SqlCommand cmd = new(sql, connection);

            //Execute the Query
            using var reader = cmd.ExecuteReader(); //flexing options here with the use of var.

            //Extract the Results
            while (reader.Read())
            {
                //for each iteration -> extract the results to a User object -> add to list.
                Employee newEmployee = BuildEmployee(reader);

                //don't return! Instead Add to List!
                employees.Add(newEmployee);
            }

            return employees;
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
            System.Console.WriteLine(e.StackTrace);
            return null;
        }
    }

    public Employee? UpdateEmployee(Employee updatedEmployee)
    {

         try
        {
            /* Set up DB connection  */ 
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            /* Create the SQL string with your data fields */ 
            string sql = "UPDATE dbo.Employee SET EmployeeName = @EmployeeName, EmailAddress = @EmailAddress, PhoneNumber = @PhoneNumber, LastPasswordChangedDate = @LastPasswordChangedDate, PasswordExpirationDate = @PasswordExpirationDate, PasswordActive = @PasswordActive  OUTPUT inserted.* WHERE EmployeeId = @EmployeeId"; 

            /* Set up the command to use your passed in data */
            using SqlCommand  cmd = new(sql, connection);
            cmd.Parameters.AddWithValue("@EmployeeId", updatedEmployee.EmployeeId);
            cmd.Parameters.AddWithValue("@EmployeeName", updatedEmployee.EmployeeName);
            cmd.Parameters.AddWithValue("@EmailAddress", updatedEmployee.EmailAddress);
            cmd.Parameters.AddWithValue("@PhoneNumber",updatedEmployee.PhoneNumber);
            cmd.Parameters.AddWithValue("@LastPasswordChangedDate", updatedEmployee.LastPasswordChangedDate);
            cmd.Parameters.AddWithValue("@PasswordExpirationDate", updatedEmployee.PasswordExpirationDate);
            cmd.Parameters.AddWithValue("@PasswordActive", updatedEmployee.PasswordActive);
         

            /* Adds new row to the DB and returns that newly inserted rows data*/ 
            using SqlDataReader reader = cmd.ExecuteReader();

            if(reader.Read())
            {
                /* If read found data we will extract it */ 
                Employee updatedEmployeeFromReader = BuildEmployee(reader);
                return updatedEmployeeFromReader;
            }
            else 
            {
                /* Read found nothing ie insert failed */ 
                return null;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine (e.Message);
            Console.WriteLine (e.StackTrace);
            return null; 
        } 


    }

    public Employee? DeleteEmployee(Employee de)
    {
        //If we have the ID -> then simply Remove it from storage

        return null;

    }

    //Helper Method
    private static Employee BuildEmployee(SqlDataReader reader)
    {
        Employee newEmployee = new();
        newEmployee.EmployeeId = (int)reader["EmployeeId"];
        newEmployee.EmployeeName = (string)reader["EmployeeName"];
        newEmployee.EmailAddress = (string)reader["EmailAddress"];
        newEmployee.PhoneNumber = (string)reader["PhoneNumber"];
        newEmployee.LastPasswordChangedDate = (DateTime)reader["LastPasswordChangedDate"];
        newEmployee.PasswordExpirationDate = (DateTime)reader["PasswordExpirationDate"];
        newEmployee.PasswordActive = (bool)reader["PasswordActive"];
        newEmployee.ManagerId = (int)reader["ManagerId"];
        return newEmployee;
    }


}