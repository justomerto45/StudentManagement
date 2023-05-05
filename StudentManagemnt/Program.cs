using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Schuelerliste;
using StudentManagement.Data;

namespace SchuelerListe
{
    public partial class Program
    {
        static async Task Main(string[] args)
        {
            string csvPath = "C:\\Users\\Can Mert\\Downloads\\SchuelerListe.CSV";
            List<Student> studentList = await CsvReader.ReadCSV<Student>(csvPath);

            // email adressen für students generieren
            foreach (var students in studentList)
            {
                students.Email = $"{students.FirstName.ToLower()}.{students.LastName.ToLower()}@tfbseke.at";
            }

            // studentlist als xml file speichern
            string xmlPath = "C:\\Users\\Can Mert\\Downloads\\schueler.xml";
            await SaveFileWithIncrementedNameAsync(xmlPath, studentList, ReadingXML.SaveXMLAsync);

            // studentlist als json file speichern
            string jsonPath = "C:\\Users\\Can Mert\\Downloads\\schueler.json";
            await SaveFileWithIncrementedNameAsync(jsonPath, studentList, ReadingJson.SaveJsonAsync);


            async Task SaveFileWithIncrementedNameAsync<T>(string filePath, T data, Func<T, string, Task> saveMethod)
            {
                if (File.Exists(filePath))
                {
                    int i = 1;
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
                    string fileExtension = Path.GetExtension(filePath);
                    string newFilePath;
                    do
                    {
                        newFilePath = Path.Combine(Path.GetDirectoryName(filePath), $"{fileNameWithoutExtension}{i}{fileExtension}");
                        i++;
                    } while (File.Exists(newFilePath));
                    filePath = newFilePath;
                }

                await saveMethod(data, filePath);
            }


            // ausgabe der studentlist in der konsole
            foreach (var students in studentList)
            {
                Console.WriteLine($"{students.FirstName} {students.LastName} ({students.SchoolClass}) - {students.Email}\n");
            }

            // statistik anzeigen
            StudentControl.StatisticHelper(studentList);

            Console.ReadLine();
        }
    }
}