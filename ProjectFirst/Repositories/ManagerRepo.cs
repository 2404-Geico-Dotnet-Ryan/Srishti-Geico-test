class ManagerRepo
{
    ManagerStorage managerStorage = new();

    //add, get-one, get-all, update, and delete

    public Manager AddManager(Manager mn)
    {
        mn.ManagerId = managerStorage.idCounter++;
        managerStorage.managers.Add(mn.ManagerId, mn);
        return mn;
    }

    public Manager? GetManager(int id)
    {
        if (managerStorage.managers.ContainsKey(id))
        {
            Manager selectedManager = managerStorage.managers[id];
            return selectedManager;

            //or    return movieStorage.movies[id];
        }
        else
        {
            System.Console.WriteLine("Invalid Manager ID - Please Try Again");
            return null;
        }
    }

    public List<Manager> GetAllManagers()
    {
        return managerStorage.managers.Values.ToList();
    }

    public Manager? Updatemanager(Manager updatedmanager)
    {
        try
        {
            managerStorage.managers[updatedmanager.ManagerId] = updatedmanager;
            return updatedmanager;
        }
        catch (Exception)
        {
            System.Console.WriteLine("Invalid manager ID - Please Try Again");
            return null;
        }
    }

    public Manager? Deletemanager(Manager mn)
    {
        bool didRemove = managerStorage.managers.Remove(mn.ManagerId);

        if (didRemove)
        {
            return mn;
        }
        else
        {
            System.Console.WriteLine("Invalid manager ID - Please Try Again");
            return null;
        }


    }
}