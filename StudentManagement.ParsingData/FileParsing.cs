using Microsoft.VisualBasic.FileIO;
using StudentManagement.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

public static class FileParsing
{
    public static class FileReader
    {
        public static async Task<List<T>> ReadAsync<T>(string filePath, FileTypes fileType)
        {
            List<T> list = new List<T>();

            try
            {
                switch (fileType)
                {
                    case FileType.CSV:
                        // Use CsvReader to read CSV files
                        break;
                    case FileType.JSON:
                        // Use JsonReader to read JSON files
                        list = await JsonReader.ReadJsonAsync<T>(filePath);
                        break;
                    case FileType.XML:
                        // Use XmlReader to read XML files
                        list = await XmlReader.ReadXmlAsync<T>(filePath);
                        break;
                    default:
                        throw new ArgumentException("Invalid file type");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error reading file: " + e.Message);
            }

            return list;
        }
    }

    public static class JsonReader
    {
        public static async Task<List<T>> ReadJsonAsync<T>(string filePath)
        {
            List<T> list = new List<T>();

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string json = await reader.ReadToEndAsync();
                    list = JsonConvert.DeserializeObject<List<T>>(json);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error reading JSON file: " + e.Message);
            }

            return list;
        }
    }

    public static class XmlReader
    {
        public static async Task<List<T>> ReadXmlAsync<T>(string filePath)
        {
            List<T> list = new List<T>();

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<T>));

                using (StreamReader reader = new StreamReader(filePath))
                {
                    list = (List<T>)serializer.Deserialize(reader);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error reading XML file: " + e.Message);
            }

            return list;
        }
    }
