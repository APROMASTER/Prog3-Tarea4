class TestData
{
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Username { get; set; }
    public string? Post { get; set; }
    public string? Search { get; set; }
    public string? ProfileToSearch { get; set; }
    public string? ChatMessage { get; set; }

    public static TestData? LoadData(string jsonFileName)
    {
        return Newtonsoft.Json.JsonConvert.DeserializeObject<TestData>(File.ReadAllText(@$"..\..\..\TestsData\{jsonFileName}.json"));
    }
}