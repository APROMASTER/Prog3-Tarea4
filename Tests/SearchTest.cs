using Xunit;
using Xunit.Abstractions;

namespace WebUnitTests
{
    [Collection("Test collection")]
    public class SearchTest : BaseTest
    {
        public SearchTest(ITestOutputHelper outputHelper) : base(outputHelper)
        {
            new LoginTestLogic(Driver, TestData.LoadData("TestData")).MakeLoginProcess();
        }

        [Fact]
        public void MakeSearchProcessPass()
        {
            //bool result = new PostTestLogic(Driver, TestData.LoadData("TestData")).MakePostProcess();
            //Assert.True(result, "Posting fail");
            RecordTestResult(currentTestName, TestResult.Pass);
        }

        [Fact]
        public void MakeSearchProcessFail()
        {
            
            //bool result = new PostTestLogic(Driver, TestData.LoadData("WrongData")).MakePostProcess();
            //Assert.False(result, "Posting successful");
            RecordTestResult(currentTestName, TestResult.Pass);
        }
    }
}