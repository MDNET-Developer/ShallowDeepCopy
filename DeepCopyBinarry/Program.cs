using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace DeepCopy
{
    internal class Program
    {
        [Serializable] //Bunu yazmasaq serialize ede bilmeyecek
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
        public static T DeepClone<T>(T obj)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("Serializable olmalidir", nameof(obj));
            }

            //binary serialization.
            using (MemoryStream memoryStream = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, obj);
                memoryStream.Position = 0;
                return (T)formatter.Deserialize(memoryStream);
            }
        }
        static void Main(string[] args)
        {
            Person person1 = new Person
            {
                Name = "John",
                Age = 30
            };


            Person person2 = DeepClone(person1);


            person1.Name = "Jane";
            person1.Age = 33;


            Console.WriteLine("Original Person:");
            Console.WriteLine($"Name: {person1.Name}, Age: {person1.Age}");

            Console.WriteLine("\nCloned Person:");
            Console.WriteLine($"Name: {person2.Name}, Age: {person2.Age}");
        }
    }
}
