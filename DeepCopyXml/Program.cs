using System;
using System.Xml.Serialization;
using System.IO;

namespace DeepCopyXml
{
    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

    }
    internal class Program
    {

        public static T DeepCopyXML<T>(T input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input), "Input object cannot be null.");

            using (var stream = new MemoryStream())
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(stream, input);
                stream.Position = 0;

                return (T)xmlSerializer.Deserialize(stream);
            }
        }

        static void Main(string[] args)
        {


            Person originalPerson = new Person { Name = "Mr Bean", Age = 30 };

            try
            {

                Person copiedPerson = DeepCopyXML(originalPerson);


                copiedPerson.Name = "Muhammed Ali The Greatest";
                copiedPerson.Age = 30;


                Console.WriteLine("Original Person: " + originalPerson.Name);
                Console.WriteLine("Copied Person: " + copiedPerson.Name);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.ReadLine();
            }

        }
    }
}
