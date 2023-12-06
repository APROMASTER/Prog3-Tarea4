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
            bool result = new ChatTestLogic(Driver, TestData.LoadData("TestData")).MakeChatProcess();
            Assert.True(result, "Posting fail");
            RecordTestResult(currentTestName, TestResult.Pass);
        }

        [Fact]
        public void MakeChatProcessFail()
        {
            
            bool result = new ChatTestLogic(Driver, TestData.LoadData("WrongData")).MakeChatProcess();
            Assert.False(result, "Posting successful");
            RecordTestResult(currentTestName, TestResult.Pass);
        }
    }
}