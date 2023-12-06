using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit.Abstractions;

public class BaseTest : IDisposable
{
    public IWebDriver Driver { get; private set; }
    public ExtentTest CurrentTest { get; private set; }
    private readonly ITestOutputHelper _output;
    private static readonly Dictionary<string, TestResult> testResults = new Dictionary<string, TestResult>();
    protected string currentTestName;
    private string _imagePath = "Results";

    public BaseTest(ITestOutputHelper outputHelper)
    {
        _output = outputHelper;
        Driver = new ChromeDriver();
        Driver.Manage().Window.Maximize();
        Driver.Url = "https://twitter.com";

        currentTestName = _output.GetTestName();
        CurrentTest = ReportUtil.Extent.CreateTest(currentTestName);
        RecordTestResult(currentTestName, TestResult.Unknown);
    }

    public void Dispose()
    {
        bool exists = Directory.Exists(@"..\..\..\" + _imagePath);
        if (!exists)
            System.IO.Directory.CreateDirectory(@"..\..\..\" + _imagePath);
        TestResult currentTestResult = testResults.GetValueOrDefault(currentTestName);

        switch (currentTestResult)
        {
            case TestResult.Pass:
            {
                //Console.ForegroundColor = ConsoleColor.Green;
                //Console.WriteLine($"========= {currentTestName} PASSED ==========");
                //Console.ResetColor();

                CurrentTest.Log(Status.Pass, currentTestName + " run successfully");
                SaveScreenshot(currentTestName + " Success Screenshot");
            }   break;

            case TestResult.Fail:
            case TestResult.Unknown:
                //Console.ForegroundColor = ConsoleColor.Red;
                //Console.WriteLine($"========= {currentTestName} FAILED ==========");
                //Console.ResetColor();
                
                _output.WriteLine("Test Failed");
                CurrentTest.Log(Status.Fail, currentTestName + " failed");
                SaveScreenshot(currentTestName + " Failure Screenshot");
                break;
        }
        
        Driver.Quit();
        Driver.Dispose();
    }

    void SaveScreenshot(string imageMessage)
    {
        var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
        var screenshotFileName = $"{currentTestName}.png";
        var screenshotFilePath = _imagePath + @"\" + screenshotFileName;
        screenshot.SaveAsFile(@"..\..\..\" + screenshotFilePath);
        CurrentTest.AddScreenCaptureFromPath(screenshotFilePath, imageMessage);
    }

    protected void RecordTestResult(string testName, TestResult result)
    {
        testResults[testName] = result;
    }

    public enum TestResult
    {
        Pass,
        Fail,
        Unknown
    }
}