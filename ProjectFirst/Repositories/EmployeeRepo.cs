using System;
class EmployeeRepo
{
    // CRUD operations
    EmployeeStorage employeeStorage = new();

    public Employee AddEmployee(Employee e)
    {
        e.EmployeeId = employeeStorage.idCounter++;

        employeeStorage.employees.Add(e.EmployeeId, e);
        return e;
    }

    public Employee? GetEmployee(int employeeid)
    {
        if (employeeStorage.employees.ContainsKey(employeeid))
        {
            return employeeStorage.employees[employeeid];
        }
        else
        {
            System.Console.WriteLine("Invalid Employee ID - Please Try Again");
            return null;
        }
    }

    //THIS IS A NEW METHOD!
    //No Parameters because...get everything is get everything. No options to choose.
    public List<Employee> GetAllEmployees()
    {
        //I am choosing to return a List because that is a much more common collection to
        //work with. It does mean I have to do a little bit of work here - but its not bad.
        return employeeStorage.employees.Values.ToList();
    }

    public Employee? UpdateEmployee(Employee updatedEmployee)
    {
        try
        {
            employeeStorage.employees[updatedEmployee.EmployeeId] = updatedEmployee;
            return updatedEmployee;
        }
        catch (Exception)
        {
            System.Console.WriteLine("Invalid Employee ID - Please Try Again");
            return null;
        }

    }

    public Employee? DeleteEmployee(Employee de)
    {
        //If we have the ID -> then simply Remove it from storage
        bool didRemove = employeeStorage.employees.Remove(de.EmployeeId);

        if (didRemove)
        {
            //How do I get this to return th emovie that was just removed?
            return de;

        }
        else
        {
            System.Console.WriteLine("Invalid Employee ID - Please Try Again");
            return null;
        }
    }

}