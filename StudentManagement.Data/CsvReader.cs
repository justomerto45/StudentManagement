using StudentManagement.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Schuelerliste
{
    public static class CsvReader
    {
        public static async Task<List<T>> ReadCSV<T>(string filePath) where T : Student, new()
        {
            List<T> itemsList = new List<T>();

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    // Read header
                    string header = await reader.ReadLineAsync();
                    if (header != "Klasse;Nachname;Vorname")
                    {
                        throw new Exception("Invalid header format.");
                    }

                    while (!reader.EndOfStream)
                    {
                        string line = await reader.ReadLineAsync();
                        string[] values = line.Split(';');

                        T item = new T();

                        // Using reflection to set property values based on CSV columns
                        typeof(T).GetProperty("SchoolClass").SetValue(item, values[0]);
                        typeof(T).GetProperty("FirstName").SetValue(item, values[2]);
                        typeof(T).GetProperty("LastName").SetValue(item, values[1]);

                        itemsList.Add(item);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error reading CSV file: " + e.Message);
            }

            itemsList.Sort((x, y) => x.SchoolClass.CompareTo(y.SchoolClass));

            return itemsList;
        }

    }
}
