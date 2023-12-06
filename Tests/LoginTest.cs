using Xunit;
using Xunit.Abstractions;

namespace WebUnitTests
{
    [Collection("Test collection")]
    public class LoginTest : BaseTest
    {
        public LoginTest(ITestOutputHelper outputHelper) : base(outputHelper)
        {}

        [Fact]
        public void MakeALoginPass()
        {
            //Assert.True(false, "Log in Failed");
            bool result = new LoginTestLogic(Driver, TestData.LoadData("TestData")).MakeLoginProcess();
            Assert.True(result, "Failed to Log in");
            RecordTestResult(currentTestName, TestResult.Pass);
        }

        [Fact]
        public void MakeALoginFail()
        {
            //Assert.False(true, "Log in Passed");
            bool result = new LoginTestLogic(Driver, TestData.LoadData("WrongData")).MakeLoginProcess();
            Assert.False(result, "Log in passed");
            RecordTestResult(currentTestName, TestResult.Pass);
            
        }
    }
}