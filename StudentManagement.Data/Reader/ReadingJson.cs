using Newtonsoft.Json;
public static class ReadingJson
{
    public static async Task SaveJsonAsync<T>(List<T> liste, string jsonPath)
    {
        string json = JsonConvert.SerializeObject(liste);
        await File.WriteAllTextAsync(jsonPath, json);
    }

    public static async Task<List<T>> ReadJsonAsync<T>(string jsonPath)
    {
        string json = await File.ReadAllTextAsync(jsonPath);
        List<T> liste = JsonConvert.DeserializeObject<List<T>>(json);
        return liste;
    }
}