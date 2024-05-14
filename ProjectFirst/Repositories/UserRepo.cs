using System;
class UserRepo
{
    // CRUD operations

UserStorage userStorage = new();

public UserAccount AddUser(UserAccount u)
{
    u.UserId = userStorage.idCounter++;

    userStorage.users.Add(u.UserId, u);
    return u;
}

public UserAccount? GetUser(int userid)
{
    if(userStorage.users.ContainsKey(userid))
    {
        return userStorage.users[userid];   
    }
    else
    {
        System.Console.WriteLine("Invalid User ID - Please Try Again");
        return null;
    }
}


 public UserAccount? UpdateUser(UserAccount updatedUser)
 {
    try
    {
        userStorage.users[updatedUser.UserId] = updatedUser;
        return updatedUser;
    }
    catch (Exception)
    {
        
        System.Console.WriteLine("Invalid User ID - Please Try Again");
        return null;
    }

 }

 public UserAccount? DeleteUser(UserAccount us)
    {
        //If we have the ID -> then simply Remove it from storage
        bool didRemove = userStorage.users.Remove(us.UserId);

        if (didRemove)
        {
            //How do I get this to return th emovie that was just removed?
            return us;

        }
        else
        {
            System.Console.WriteLine("Invalid User ID - Please Try Again");
            return null;
        }
    }





}