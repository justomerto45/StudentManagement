using StudentManagement.Data;

public static class CsvReader
{
    public static List<Student> ReadCSV(string filePath)
    {
        // List of the students
        List<Student> studentsList = new List<Student>();

        try
        {
            using (StreamReader reader = new StreamReader(filePath))
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
        }
        
        catch (Exception e)
        {
            Console.WriteLine("Error reading CSV file: " + e.Message);
        }

        return studentsList;
    }
}
