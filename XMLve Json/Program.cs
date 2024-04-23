using System.Xml.Serialization;
using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace XMLve_Json
{
    internal class Program
    {
       

        static void Main(string[] args)
        {
            Student student = new Student { Name = "Kerim",Surname="Agayev" ,Age = 23 };
            string xmlData = SerializeToXml(student);
            Console.WriteLine("Serialized XML:");
            Console.WriteLine(xmlData);

            
            Student deserializedStudent = DeserializeFromXml(xmlData);
            Console.WriteLine("\nDeserialized Student:");
            Console.WriteLine($"Name: {deserializedStudent.Name},Surname:{deserializedStudent.Surname}, Age: {deserializedStudent.Age}");

           
            string jsonData = SerializeToJson(student);
            Console.WriteLine("\nSerialized JSON:");
            Console.WriteLine(jsonData);

            
            deserializedStudent = DeserializeFromJson(jsonData);
            Console.WriteLine("\nDeserialized Student:");
            Console.WriteLine($"Name: {deserializedStudent.Name},Surname:{deserializedStudent.Surname}, Age: {deserializedStudent.Age}");
        }

       
        public static string SerializeToXml(Student student)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Student));
            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, student);
                return writer.ToString();
            }
        }

       
        public static Student DeserializeFromXml(string xmlData)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Student));
            using (StringReader reader = new StringReader(xmlData))
            {
                return (Student)serializer.Deserialize(reader);
            }
        }

        
        public static string SerializeToJson(Student student)
        {
            return JsonConvert.SerializeObject(student);
        }

        
        public static Student DeserializeFromJson(string jsonData)
        {
            return JsonConvert.DeserializeObject<Student>(jsonData);
        }
    }
    
}
