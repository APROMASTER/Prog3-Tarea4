using OpenQA.Selenium;

class ChatTestLogic
{
    private readonly IWebDriver driver;
    private readonly TestData? config;
    private readonly string _initialSite = "https://twitter.com/messages";

    public ChatTestLogic(IWebDriver webDriver, TestData? data)
    {
        config = data;
        _initialSite += $"/{config.ChatId}";
        driver = webDriver;
        if (driver.Url != _initialSite) driver.Navigate().GoToUrl(_initialSite);
    }

    public bool MakeChatProcess()
    {
        bool result = false;
        try
        {
            if (config == null) throw new Exception("No data found");
            Thread.Sleep(2000);
            var chatInput = driver.FindElement(By.XPath("//*[@id=\"react-root\"]/div/div/div[2]/main/div/div/div/section[2]/div/div/div[2]/div/div/aside/div[2]/div[2]/div/div/div/div/div/label/div[1]/div/div/div/div/div/div/div/div/div/div/span"));
            chatInput.SendKeys(config.ChatMessage);
            Thread.Sleep(800);

            var chatSubmitButton = driver.FindElement(By.XPath("//*[@id=\"react-root\"]/div/div/div[2]/main/div/div/div/section[2]/div/div/div[2]/div/div/aside/div[2]/div[3]"));
            chatSubmitButton.Click();
            
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