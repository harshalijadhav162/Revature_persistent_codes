namespace MethodsDemo
{
    class Student
    {
        public static int NumberOfStudents = 0;
        public string Name { get; set; }
        public int Age { get; set; }

        public Student(string Name, int Age)
        {
            this.Name = Name;
            this.Age = Age;
            NumberOfStudents++;
        }

        public void Promote() => Print();

        public void Print()
        {
            Console.WriteLine($"Name: {this.Name}, Age: {this.Age}, Total Students: {NumberOfStudents}");
        }

        public int DoubleTheAge(int multiplyBy = 2) => this.Age * multiplyBy;
    }
}
