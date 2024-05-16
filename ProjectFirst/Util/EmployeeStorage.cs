class EmployeeStorage
{
    //Temporary setup

    public Dictionary<int, Employee> employees; //created a dictionary which is our storage device

    public int idCounter = 1;

    public EmployeeStorage()
    {   
        //creating some employee objects - employee1, employee2 etc..
        Employee employee1 = new(idCounter, "JBond", "jbond@test.com", "444-444-4444", 03-15-2024, 90, true); idCounter++;
        Employee employee2 = new(idCounter, "HPotter", "hpotter@test.com", "111-111-1111", 03-15-2024, 90, true); idCounter++;
        Employee employee3 = new(idCounter, "AReed", "areed@test.com", "444-333-4444", 03-15-2024, 90, true); idCounter++;
        Employee employee4 = new(idCounter, "SFord", "sford@test.com", "333-444-3333", 03-15-2024, 90, true); idCounter++;

    //Add the new employee objects to the dictionary
        employees = [];
        employees.Add(employee1.EmployeeId, employee1);
        employees.Add(employee2.EmployeeId, employee2);
        employees.Add(employee3.EmployeeId, employee3);
        employees.Add(employee4.EmployeeId, employee4);


    }
    
    
    
    
}
























