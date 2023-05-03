using StudentMnmng.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class StudentControl
{
    public static List<Student> StudentList { get; set; }

    public static void LadeSchuelerListeAusCsv(string dateiPfad)
    {
        StudentList = new List<Student>();
        var daten = File.ReadAllLines(dateiPfad);
        foreach (var datenZeile in daten.Skip(1))
        {
            var zeilenDaten = datenZeile.Split(',');
            var schueler = new Student
            {
                FirstName = zeilenDaten[0],
                LastName = zeilenDaten[1],
                SchoolClass = zeilenDaten[2],
                Email = null
            };
            StudentList.Add(schueler);
        }
    }

    public static void GeneriereEmailAdressen()
    {
        foreach (var student in StudentList)
        {
            var vorname = student.FirstName.ToLower();
            var nachname = student.LastName.ToLower();
            var zufall = new Random().Next(1000, 9999);
            student.Email = $"{vorname}.{nachname}{zufall}@schule.de";
        }
    }

    public static string ZeigeKurzstatistik()
    {
        var anzahlSchueler = StudentList.Count;
        var anzahlKlassen = StudentList.Select(x => x.SchoolClass).Distinct().Count();
        var schuelerProKlasse = StudentList.GroupBy(x => x.SchoolClass).Select(g => new { Klasse = g.Key, AnzahlSchueler = g.Count() });
        var durchschnittSchuelerProKlasse = StudentList.GroupBy(x => x.SchoolClass).Select(g => g.Count()).Average();

        var statistikText = $"Anzahl Schüler insgesamt: {anzahlSchueler}" + Environment.NewLine;
        statistikText += $"Anzahl Klassen: {anzahlKlassen}" + Environment.NewLine;
        statistikText += "Schüler pro Klasse:" + Environment.NewLine;
        foreach (var klasse in schuelerProKlasse)
        {
            statistikText += $"{klasse.Klasse}: {klasse.AnzahlSchueler}" + Environment.NewLine;
        }
        statistikText += $"Durchschnitt Schüler pro Klasse: {durchschnittSchuelerProKlasse:F2}";

        return statistikText;
    }
}
