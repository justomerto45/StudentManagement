using StudentManagement.Data;

internal class Program
{
    static void Main(string[] args)
    {
        string csvFilePath = "C:\\Users\\Can Mert\\Downloads\\SchuelerListe.CSV";
        List<Student> schuelerList = CsvReader.ReadCSV(csvFilePath);

        StudentControl.GenerateEmailAddresses(schuelerList);

        foreach (Student student in schuelerList)
        {
            Console.WriteLine($"Name: {student.FirstName} {student.LastName}");
            Console.WriteLine($"Klasse: {student.SchoolClass}");
            Console.WriteLine($"Email: {student.Email}");
            Console.WriteLine();
        }

        StudentControl.DisplayStatistics(schuelerList);

        Console.ReadLine();
    }
}