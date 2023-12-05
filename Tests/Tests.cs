using Newtonsoft.Json;

class Tests
{
    static TestsConfig configData = null;
    public Tests()
    {
        try
        {
            configData = JsonConvert.DeserializeObject<TestsConfig>(File.ReadAllText("TestsConfig.json"));
            if (configData.Email == null) throw new Exception("No data");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error! {ex}");
            configData = null;
            return;
        }
    }

    public void RunLoginTest()
    {
        if (!GetData()) return;
        var test = new LoginTest();
        test.WriteLoginEmail();
    }

    private bool GetData()
    {
        if (configData == null)
        {
            Console.WriteLine("No Data ByPass Error!");
            return false;
        }
        return true;
    }
}