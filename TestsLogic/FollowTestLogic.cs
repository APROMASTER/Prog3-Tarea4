using OpenQA.Selenium;

class FollowTestLogic
{
    private readonly IWebDriver driver;

    public FollowTestLogic(IWebDriver webDriver)
    {
        driver = webDriver;
    }

    public bool MakeFollowProcess()
    {
        bool result = false;
        try
        {
            Thread.Sleep(2000);
            string followXPath = "//*[@id=\"react-root\"]/div/div/div[2]/main/div/div/div/div[1]/div/div[3]/div/div/div/div[1]/div[1]/div[2]/div[4]/div[1]/div[2]";
            if (driver.FindElement(By.XPath(followXPath)).GetAttribute("data-testid").Contains("-unfollow")) return false;

            var followButton = driver.FindElement(By.XPath(followXPath));
            followButton.Click();

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

    public bool MakeUnfollowProcess()
    {
        bool result = false;
        try
        {
            Thread.Sleep(2000);
            string followXPath = "//*[@id=\"react-root\"]/div/div/div[2]/main/div/div/div/div[1]/div/div[3]/div/div/div/div[1]/div[1]/div[2]/div[4]/div[1]/div[2]";
            if (driver.FindElement(By.XPath(followXPath)).GetAttribute("data-testid").Contains("-follow")) return false;

            var unfollowButton = driver.FindElement(By.XPath(followXPath));
            unfollowButton.Click();
            Thread.Sleep(800);
            var unfollowConfirmButton = driver.FindElement(By.XPath("//*[@id=\"layers\"]/div[2]/div/div/div/div/div/div[2]/div[2]/div[2]/div[1]"));
            unfollowConfirmButton.Click();

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