using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

class TrendTest
{
    public IWebDriver driver;
    public readonly string site;

    public LoginTest()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        site = "https://twitter.com/i/flow/login";

        driver.Url = site;
        driver.FindElement(By.Name("q")).SendKeys(Keys.Return);
        Console.WriteLine(driver.Title);
    }


    ~LoginTest()
    {
        driver.Quit();
    }
}