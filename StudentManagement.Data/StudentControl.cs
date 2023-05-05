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

    public static void StatisticHelper(List<Student> studentList)
    {
        int countStudent = studentList.Count;
        int countSchoolClasses = studentList.Select(s => s.SchoolClass).Distinct().Count();
        double avrgStudentsInClass = (double)studentList.Count / countSchoolClasses;

        Console.WriteLine("Anzahl der Schueler: " + countStudent);
        Console.WriteLine("Anzahl der Klassen: " + countSchoolClasses);
        Console.WriteLine("Durchschnittliche Anzahl Schueler pro Klasse: " + avrgStudentsInClass);

        var schuelerProKlasse = studentList.GroupBy(s => s.SchoolClass)
                                            .Select(g => new
                                            {
                                                SchoolClass = g.Key,
                                                StudentCount = g.Count()
                                            });

        Console.WriteLine("Anzahl der Schueler pro Klasse:");
        foreach (var item in schuelerProKlasse)
        {
            Console.WriteLine("Klasse " + item.SchoolClass + ": " + item.StudentCount + " Schueler");
        }
    }

}
