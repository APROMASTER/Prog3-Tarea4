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
        public void MakeALoginPassed()
        {
            try
            {
                Assert.True(new LoginTestLogic(Driver, TestData.LoadData("TestData")).WriteLoginEmail());
                RecordTestResult(currentTestName, TestResult.Pass);
            }
            catch (Exception ex)
            {
                RecordTestResult(currentTestName, TestResult.Fail);
            }
        }

        [Fact]
        public void MakeALoginFailed()
        {
            try
            {
                Assert.False(new LoginTestLogic(Driver, TestData.LoadData("WrongData")).WriteLoginEmail());
                RecordTestResult(currentTestName, TestResult.Pass);
            }
            catch (Exception ex)
            {
                RecordTestResult(currentTestName, TestResult.Fail);
            }
        }
    }
}