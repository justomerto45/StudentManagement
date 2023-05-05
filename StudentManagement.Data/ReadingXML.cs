using System.Xml.Serialization;

public static class ReadingXML
{
    public static async Task SaveXMLAsync<T>(List<T> list, string xmlPath)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
        using (TextWriter writer = new StreamWriter(xmlPath))
        {
            serializer.Serialize(writer, list);
        }
    }

    public static async Task<List<T>> ReadXMLAsync<T>(string xmlPath)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
        using (TextReader reader = new StreamReader(xmlPath))
        {
            List<T> list = (List<T>)serializer.Deserialize(reader);
            return list;
        }
    }
}