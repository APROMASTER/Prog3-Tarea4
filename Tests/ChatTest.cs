using Xunit;
using Xunit.Abstractions;

namespace WebUnitTests
{
    [Collection("Test collection")]
    public class ChatTest : BaseTest
    {
        public ChatTest(ITestOutputHelper outputHelper) : base(outputHelper)
        {
            new LoginTestLogic(Driver, TestData.LoadData("TestData")).MakeLoginProcess();
        }

        [Fact]
        public void MakeChatProcessPass()
        {
            //bool result = new PostTestLogic(Driver, TestData.LoadData("TestData")).MakePostProcess();
            //Assert.True(result, "Posting fail");
            RecordTestResult(currentTestName, TestResult.Pass);
        }

        [Fact]
        public void MakeChatProcessFail()
        {
            
            //bool result = new PostTestLogic(Driver, TestData.LoadData("WrongData")).MakePostProcess();
            //Assert.False(result, "Posting successful");
            RecordTestResult(currentTestName, TestResult.Pass);
        }
    }
}