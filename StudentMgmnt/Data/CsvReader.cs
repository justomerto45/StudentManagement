using System.Collections.Generic;
using System.Formats.Asn1;
using System.IO;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using StudentMnmng.Data;

public static class CsvReader
{
    public static List<Student> ImportiereSchueler(string dateipfad)
    {
        var schuelerListe = new List<Student>();

        using (var reader = new StreamReader(dateipfad))
        {
            while (!reader.EndOfStream)
            {
                var zeile = reader.ReadLine();
                var werte = zeile.Split(';');

                var schueler = new Student()
                {
                    SchoolClass = werte[1],
                    FirstName = werte[2],
                    LastName = werte[3],
                    Email = null // Initialisieren mit null
                };

                schuelerListe.Add(schueler);
            }
        }

        return schuelerListe;
    }
}