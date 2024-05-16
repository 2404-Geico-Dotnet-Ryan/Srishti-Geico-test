class ManagerStorage
{
     public Dictionary<int, Manager > managers;
      public int idCounter = 1;

        public ManagerStorage()
        {
            Manager manager1 = new(idCounter, "srishti", "pass1", "manager"); idCounter++;
            Manager manager2 = new(idCounter, "john", "pass2", "manager"); idCounter++;
           Manager manager3 = new(idCounter, "admin", "pass3", "manager"); idCounter++;


            managers = [];
            managers.Add(manager1.ManagerId, manager1);
            managers.Add(manager2.ManagerId, manager2);
            managers.Add(manager3.ManagerId, manager3);
           
        }



}