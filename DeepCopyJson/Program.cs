using System;
using System.Text.Json;

namespace DeepCopyJson
{
    internal class Program
    {
        [Serializable]
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public Car PersonCar { get; set; }
            public Person(string name, int age, Car personCar)
            {
                Name = name;
                Age = age;
                PersonCar = personCar;
            }
        }

        public class Car
        {
            public string CarName { get; set; }
        }

        public static T DeepCopy<T>(T input)
        {
            var jsonString = JsonSerializer.Serialize(input);
            return JsonSerializer.Deserialize<T>(jsonString);
        }
        static void Main(string[] args)
        {
            Car car = new()
            {
                CarName = "Mercedes-Benz"
            };
            Person person1 = new Person("Alice", 30, car);

            // Deep copy 
            Person person2 = DeepCopy(person1);

            Console.WriteLine("Before :");
            Console.WriteLine($"person1: {person1.Name} / {person1.Age} / {person1.PersonCar.CarName}");
            Console.WriteLine($"person2: {person2.Name} / {person2.Age} / {person2.PersonCar.CarName}");

            person2.Name = "Bob";
            person2.Age = 25;
            person2.PersonCar.CarName = "BMW";


            Console.WriteLine("After:");
            Console.WriteLine($"person1: {person1.Name} / {person1.Age} / {person1.PersonCar.CarName}");
            Console.WriteLine($"person2: {person2.Name} / {person2.Age} / {person2.PersonCar.CarName}");
            Console.ReadLine();
        }
    }
}
