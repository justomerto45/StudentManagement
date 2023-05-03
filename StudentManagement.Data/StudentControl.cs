using StudentManagement.Data;

public static class StudentControl
{
    public static void GenerateEmailAddresses(List<Student> studentList)
    {
        foreach (Student schueler in studentList)
        {
            string firstname = schueler.FirstName.ToLower();
            string lastname = schueler.LastName.ToLower();

            string email = $"{firstname}.{lastname}@example.com";
            schueler.Email = email;
        }
    }

    public static void DisplayStatistics(List<Student> studentList)
    {
        int studentCount = studentList.Count;
        int schoolclassCount = studentList.Select(s => s.SchoolClass).Distinct().Count();

        if (schoolclassCount == 0)
        {
            Console.WriteLine("No school classes found.");
            return;
        }

        int averageStudentPerClass = studentCount / schoolclassCount;

        Console.WriteLine($"Anzahl Schüler: {studentCount}");
        Console.WriteLine($"Anzahl Klassen: {schoolclassCount}");
        Console.WriteLine($"Durchschnitt Schüler pro Klasse: {averageStudentPerClass}");
    }

}
