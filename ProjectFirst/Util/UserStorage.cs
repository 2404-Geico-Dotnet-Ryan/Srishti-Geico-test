class UserStorage
{
    //Temporary setup

    public Dictionary<int, UserManagementSystem> users; //created a dictionary which is our storage device

    public int idCounter = 1;

    public UserStorage()
    {   
        //creating some usermgmtsystem objects - user1, user2 etc..
        UserManagementSystem user1 = new(idCounter, "JBond", "jbond@test.com", "444-444-4444", true); idCounter++;
        UserManagementSystem user2 = new(idCounter, "HPotter", "hpotter@test.com", "111-111-1111", true); idCounter++;
        UserManagementSystem user3 = new(idCounter, "AReed", "areed@test.com", "444-333-4444", true); idCounter++;
        UserManagementSystem user4 = new(idCounter, "SFord", "sford@test.com", "333-444-3333", true); idCounter++;

    
        users = [];
        users.Add(user1.UserId, user1);
        users.Add(user2.UserId, user2);
        users.Add(user3.UserId, user3);
        users.Add(user4.UserId, user4);


    }
    
    
    
    
}
























