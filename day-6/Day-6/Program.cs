using GarbageCollectionDemo;
using System;
using System.Collections;
using System.Data.Common;
using System.Security.Cryptography.X509Certificates;

namespace Day6
{
    class Program
    {
        public static void Main()
        {
            var res1 = new Resource("Res1");
            var res2 = new Resource("Res2");

            res1 = null;
            res2 = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();

            

            
            RecordDemo();
            Console.WriteLine("Record Demo Done");
        }
        //private static void DisposableDemo()
        //{
            //using (var manager = new GarbageCollectionDemo.FileManager("DisposableRes");
            //{
              //  manager.OpenFile("path/to/file.txt");
            //}
          //  using var manager2 = new GarbageCollectionDemo.FileManager("DisposableRes");
        //}
        private static void RecordDemo()
        {
            var temp1 = new Temp { Id = 1, Name = " Temp1"};
            var temp2 = new Temp { Id = 1, Name = " Temp1" };
            Console.WriteLine(temp1);
            Console.WriteLine(temp2);
            Console.WriteLine(temp1 == temp2);
            var temp3 = temp1 with { Id = 2 };
            Console.WriteLine(temp3);
        }
        public static void CollectionClassesDemo()
        {
            List<string> list = new List<string>();
            list.Add("Item1");
            list.Add("Item2");
            list.Add("Item3");
            list.Add("Item4");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
        public static void ArrayCollectionDemo()
        {
            ArrayList list = new ArrayList();
            list.Add("Item1");
            list.Add("Item2");
            list.Add("Hello");
            list.Add(3.14);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            PublicKey static void CollectionClassesDemo()
            {
                List<int> marks = new List<int>(10);
                marks.Add(1);
                marks.Add(1);
                Console.WriteLine($"Count: marks.Count), Capacity: {marks.Capacity});


        }

    }
}