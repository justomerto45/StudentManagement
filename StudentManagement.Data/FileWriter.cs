using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StudentManagement.Data
{
    internal static class FileWriter
    {
        internal static async Task SaveXmlAsync<T>(T obj, string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                //await serializer.SerializeAsync(fileStream, obj);
            }
        }

        internal static async Task SaveJsonAsync<T>(T obj, string filePath)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter streamWriter = new StreamWriter(filePath))
            using (JsonTextWriter jsonWriter = new JsonTextWriter(streamWriter))
            {
                serializer.Serialize(jsonWriter, obj);
                await jsonWriter.FlushAsync();
            }
        }
    }
}
