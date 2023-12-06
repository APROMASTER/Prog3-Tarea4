using OpenQA.Selenium;

class PostTestLogic
{
    private readonly IWebDriver driver;
    private readonly TestData? config;
    private readonly string _initialSite = "https://twitter.com/home";

    public PostTestLogic(IWebDriver webDriver, TestData? data)
    {
        config = data;
        driver = webDriver;
        if (driver.Url != _initialSite) driver.Navigate().GoToUrl(_initialSite);
    }

    public bool MakePostProcess()
    {
        bool result = false;
        try
        {
            if (config == null) throw new Exception("No data found");
            Thread.Sleep(2000);
            var postBox = driver.FindElement(By.XPath("//*[@id=\"react-root\"]/div/div/div[2]/main/div/div/div/div[1]/div/div[3]/div/div[2]/div[1]/div/div/div/div[2]/div[1]/div/div/div/div/div/div/div/div/div/div/label/div[1]/div/div"));
            postBox.Click();
            var postInput = driver.FindElement(By.XPath("//*[@id=\"react-root\"]/div/div/div[2]/main/div/div/div/div[1]/div/div[3]/div/div[2]/div[1]/div/div/div/div[2]/div[1]/div/div/div/div/div/div/div/div/div/div/label/div[1]/div/div/div/div/div/div[2]/div/div/div/div/span"));
            postInput.SendKeys(config.Post);
            
            Thread.Sleep(500);
            var postButton = driver.FindElement(By.XPath("//*[@id=\"react-root\"]/div/div/div[2]/main/div/div/div/div[1]/div/div[3]/div/div[2]/div[1]/div/div/div/div[2]/div[2]/div[2]/div/div/div/div[3]"));
            if (postButton.GetAttribute("aria-disabled") == "true") throw new Exception("Cant click the element");
            postButton.Click();

            result = true;
            Thread.Sleep(4000);
        }
        catch (Exception ex)
        {
            Thread.Sleep(2000);
            Console.WriteLine($"Error - {ex}");
        }
        return result;
    }
}