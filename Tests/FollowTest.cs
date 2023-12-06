using Xunit;
using Xunit.Abstractions;

namespace WebUnitTests
{
    [Collection("Test collection")]
    public class FollowTest : BaseTest
    {
        public FollowTest(ITestOutputHelper outputHelper) : base(outputHelper)
        {
            var config = TestData.LoadData("TestData");
            new LoginTestLogic(Driver, config).MakeLoginProcess();
        }

        [Fact]
        public void MakeFollowProcess()
        {
            new SearchTestLogic(Driver, TestData.LoadData("TestData")).MakeSearchProcess();
            bool result = new FollowTestLogic(Driver).MakeFollowProcess();
            Assert.True(result);
            RecordTestResult(currentTestName, TestResult.Pass);
        }

        [Fact]
        public void MakeFollowProcess_Fail()
        {
            new SearchTestLogic(Driver, TestData.LoadData("TestData")).MakeSearchProcess();
            bool result = new FollowTestLogic(Driver).MakeFollowProcess();
            Assert.False(result);
            RecordTestResult(currentTestName, TestResult.Pass);
        }

        [Fact]
        public void MakeFollowProcessFail_UnknownProfile()
        {
            new SearchTestLogic(Driver, TestData.LoadData("WrongData")).MakeSearchProcess();
            bool result = new FollowTestLogic(Driver).MakeFollowProcess();
            Assert.False(result);
            RecordTestResult(currentTestName, TestResult.Pass);
        }
    }
}