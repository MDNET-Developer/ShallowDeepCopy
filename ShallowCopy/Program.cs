using System;

namespace ShallowCopy
{
    internal class Program
    {
        class Worker
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public int Age { get; set; }

            public Salary salary { get; set; }
            public Worker ShallowCopy()
            {
                return (Worker)MemberwiseClone();
            }
        }

        class Salary
        {
            public decimal WorkerSalary { get; set; }
        }
        static void Main(string[] args)
        {
            Salary salaryclass = new()
            {
                WorkerSalary = 955
            };

            Worker worker = new Worker()
            {
                Name = "Murad",
                Surname = "Aliyev",
                Age = 5,
                salary = salaryclass


            };

            Worker worker2 = worker.ShallowCopy();
            Console.WriteLine("Before: ");
            Console.WriteLine($"Worker - Name:{worker.Name} / Surname:{worker.Surname} / Age:{worker.Age} / Salary:{worker.salary.WorkerSalary}");
            Console.WriteLine($"Worker 2 - Name:{worker2.Name} / Surname:{worker2.Surname} / Age:{worker2.Age} / Salary:{worker2.salary.WorkerSalary}");



            worker2.Surname = "Ali";//Value type
            worker2.salary.WorkerSalary = 1150; //ReferanceType


            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("After: ");
            Console.WriteLine($"Worker - Name:{worker.Name} / Surname:{worker.Surname} / Age:{worker.Age} / Salary:{worker.salary.WorkerSalary}");
            Console.WriteLine($"Worker 2 - Name:{worker2.Name} / Surname:{worker2.Surname} / Age:{worker2.Age} / Salary:{worker2.salary.WorkerSalary}");
            Console.ReadLine();
        }
    }
}
