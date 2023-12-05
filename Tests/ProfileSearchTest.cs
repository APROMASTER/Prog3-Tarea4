using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

class ProfileSearchTest
{
    public IWebDriver driver;
    public readonly string site;

    public ProfileSearchTest()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        site = "https://twitter.com/i/flow/login";

        driver.Url = site;
        driver.FindElement(By.Name("q")).SendKeys(Keys.Return);
        Console.WriteLine(driver.Title);
    }


}