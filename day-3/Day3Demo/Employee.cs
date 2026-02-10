namespace EmployeeDemo
{
    public class Employee
    {
        public int Id;
        public string FirstName;
        public string LastName;
        public int Age;

        public Employee(int id, string firstName, string lastName, int age)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public void Print()
        {
            Console.WriteLine($"Employee: {FirstName} {LastName}, Age: {Age}");
        }

        public int DoubleTheAge()
        {
            Age *= 2;
            return Age;
        }
    }
}
