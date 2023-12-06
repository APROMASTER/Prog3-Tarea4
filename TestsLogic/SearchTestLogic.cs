using OpenQA.Selenium;

class SearchTestLogic
{
    private readonly IWebDriver driver;
    private readonly TestData? config;
    private readonly string _initialSite = "https://twitter.com/explore";

    public SearchTestLogic(IWebDriver webDriver, TestData? data)
    {
        config = data;
        driver = webDriver;
        if (driver.Url != _initialSite) driver.Navigate().GoToUrl(_initialSite);
    }

    public string MakeSearchProcess()
    {
        string result = null;
        try
        {
            if (config == null) throw new Exception("No data found");
            Thread.Sleep(2000);
            var searchBox = driver.FindElement(By.XPath("//*[@id=\"react-root\"]/div/div/div[2]/main/div/div/div/div[1]/div/div[1]/div[1]/div/div/div/div/div/div[1]/div[2]/div/div/div/form/div[1]/div"));
            searchBox.Click();
            var searchInput = driver.FindElement(By.XPath("//*[@id=\"react-root\"]/div/div/div[2]/main/div/div/div/div[1]/div/div[1]/div[1]/div/div/div/div/div/div[1]/div[2]/div/div/div/form/div[1]/div/div/div/label/div[2]/div/input"));
            searchInput.SendKeys(config.Search);
            
            Thread.Sleep(1000);
            IWebElement searchOption = null;
            bool terminateSearch = false;
            for (int i = 1; i < 9; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    try
                    {
                        if (driver.FindElement(By.XPath($"//*[@id=\"typeaheadDropdown-{i}\"]")) == null) break;

                        if (driver.FindElement(By.XPath($"//*[@id=\"typeaheadDropdown-{i}\"]/div[{j}]/div/div/div/div[2]/div/div/div/div[1]/div/div[1]/span/span[1]")).Text == config.Search)
                        {
                            searchOption = driver.FindElement(By.XPath($"//*[@id=\"typeaheadDropdown-{i}\"]/div[{j}]/div/div"));
                            result = config.Search;
                            terminateSearch = true;
                            break;
                        }
                    }
                    catch (System.Exception)
                    {
                        continue;
                    }   
                }
                if (terminateSearch) break;
            }
            if (searchOption == null) throw new Exception("SearchOption not found");
            searchOption.Click();
            //if (postButton.GetAttribute("aria-disabled") == "true") throw new Exception("Cant click the element");
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