using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using Newtonsoft.Json;
using StudentManagement.Data;

public static class CsvConverter
{
    public static void ConvertCSV(string csvFilePath, string xmlFilePath, string jsonFilePath)
    {
        // List of the students
        List<Student> studentsList = new List<Student>();

        try
        {
            using (StreamReader reader = new StreamReader(csvFilePath))
            {
                // Read header
                string header = reader.ReadLine();
                if (header != "Klasse;Nachname;Vorname")
                {
                    throw new Exception("Invalid header format.");
                }

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(';');

                    Student student = new Student
                    {
                        SchoolClass = values[0],
                        LastName = values[1],
                        FirstName = values[2]
                    };

                    studentsList.Add(student);
                }
            }

            // Convert to XML
            XElement xml = new XElement("Students",
                from student in studentsList
                select new XElement("Student",
                    new XElement("SchoolClass", student.SchoolClass),
                    new XElement("LastName", student.LastName),
                    new XElement("FirstName", student.FirstName)
                )
            );
            xml.Save(xmlFilePath);

            // Convert to JSON
            string json = JsonConvert.SerializeObject(studentsList, Formatting.Indented);
            File.WriteAllText(jsonFilePath, json);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error converting CSV file: " + e.Message);
        }
    }
}