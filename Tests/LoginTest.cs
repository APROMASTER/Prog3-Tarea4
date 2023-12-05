using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Xunit;

public class LoginTest
{
    public IWebDriver driver;
    public readonly string site;
    private TestsConfig config;

    public LoginTest()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        site = "https://twitter.com/i/flow/login";
    }
    
    [Fact]
    public void WriteLoginEmail()
    {
        driver.Navigate().GoToUrl(site);
        System.Threading.Thread.Sleep(2000);
        var emailBox = driver.FindElement(By.XPath("//*[@id=\"layers\"]/div/div/div/div/div/div/div[2]/div[2]/div/div/div[2]/div[2]/div/div/div/div[5]/label/div/div[2]"));
        emailBox.Click();
        
        System.Threading.Thread.Sleep(2000);
        var emailInput = driver.FindElement(By.XPath("//*[@id=\"layers\"]/div/div/div/div/div/div/div[2]/div[2]/div/div/div[2]/div[2]/div/div/div/div[5]/label/div/div[2]/div/input"));
        emailInput.SendKeys(config.Email);
        System.Threading.Thread.Sleep(2000);
        emailInput.SendKeys(Keys.Return);

        //var passwordInput = driver.FindElement(By.XPath("//*[@id=\"layers\"]/div/div/div/div/div/div/div[2]/div[2]/div/div/div[2]/div[2]/div[1]/div/div[2]/label/div/div[2]/div/input"));
        IWebElement passwordInput = null;
        System.Threading.Thread.Sleep(2000);
        if (passwordInput != null)
        {
            passwordInput.SendKeys(config.Password);
            System.Threading.Thread.Sleep(1000);
            passwordInput.SendKeys(Keys.Return);
        }
        else
        {
            var usernameInput = driver.FindElement(By.XPath("//*[@id=\"layers\"]/div/div/div/div/div/div/div[2]/div[2]/div/div/div[2]/div[2]/div[1]/div/div[2]/label/div/div[2]/div/input"));
            usernameInput.SendKeys(config.Username);
            System.Threading.Thread.Sleep(1000);
            usernameInput.SendKeys(Keys.Return);

            System.Threading.Thread.Sleep(1000);
            passwordInput = driver.FindElement(By.XPath("//*[@id=\"layers\"]/div/div/div/div/div/div/div[2]/div[2]/div/div/div[2]/div[2]/div[1]/div/div/div[3]/div/label/div/div[2]/div[1]/input"));
            passwordInput.SendKeys(config.Password);
            System.Threading.Thread.Sleep(1000);
            passwordInput.SendKeys(Keys.Return);
        }
        System.Threading.Thread.Sleep(2000);
        driver.Close();
        driver.Quit();
        driver.Dispose();
    }



}