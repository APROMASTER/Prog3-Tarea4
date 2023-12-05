using OpenQA.Selenium;

class LoginTestLogic
{
    private readonly IWebDriver driver;
    public readonly string site;
    private readonly TestData config;

    public LoginTestLogic(IWebDriver webDriver, TestData data)
    {
        config = data;
        driver = webDriver;
    }

    public bool WriteLoginEmail()
    {
        bool result = false;
        try
        {
            if (config == null) throw new Exception("No data found");
            driver.Url = "https://twitter.com/i/flow/login";
            //driver.Navigate().GoToUrl(site);
            Thread.Sleep(3000);
            var emailBox = driver.FindElement(By.XPath("//*[@id=\"layers\"]/div/div/div/div/div/div/div[2]/div[2]/div/div/div[2]/div[2]/div/div/div/div[5]/label/div/div[2]"));
            emailBox.Click();
            
            Thread.Sleep(500);
            var emailInput = driver.FindElement(By.XPath("//*[@id=\"layers\"]/div/div/div/div/div/div/div[2]/div[2]/div/div/div[2]/div[2]/div/div/div/div[5]/label/div/div[2]/div/input"));
            emailInput.SendKeys(config.Email + Keys.Return);

            //var passwordInput = driver.FindElement(By.XPath("//*[@id=\"layers\"]/div/div/div/div/div/div/div[2]/div[2]/div/div/div[2]/div[2]/div[1]/div/div[2]/label/div/div[2]/div/input"));
            IWebElement passwordInput = null;
            Thread.Sleep(800);
            if (passwordInput != null)
            {
                passwordInput.SendKeys(config.Password + Keys.Return);
            }
            else
            {
                var usernameInput = driver.FindElement(By.XPath("//*[@id=\"layers\"]/div/div/div/div/div/div/div[2]/div[2]/div/div/div[2]/div[2]/div[1]/div/div[2]/label/div/div[2]/div/input"));
                usernameInput.SendKeys(config.Username + Keys.Return);

                Thread.Sleep(800);
                passwordInput = driver.FindElement(By.XPath("//*[@id=\"layers\"]/div/div/div/div/div/div/div[2]/div[2]/div/div/div[2]/div[2]/div[1]/div/div/div[3]/div/label/div/div[2]/div[1]/input"));
                passwordInput.SendKeys(config.Password + Keys.Return);
            }
            result = true;
            Thread.Sleep(4000);
            //((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(@"..\..\..\Results\Logged.png");
        }
        catch (Exception ex)
        {
            Thread.Sleep(2000);
            Console.WriteLine($"Error - {ex}");
            //((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(@"..\..\..\Results\Failed To Log.png");
        }
        return result;
    }
}