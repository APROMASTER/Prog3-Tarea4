using Xunit;
using Xunit.Abstractions;

namespace WebUnitTests
{
    [Collection("Test collection")]
    public class SearchTest : BaseTest
    {
        #pragma warning disable CS8602
        public SearchTest(ITestOutputHelper outputHelper) : base(outputHelper)
        {
            new LoginTestLogic(Driver, TestData.LoadData("TestData")).MakeLoginProcess();
        }

        [Fact]
        public void MakeSearchProcess_MatchSearch()
        {
            var testData = TestData.LoadData("TestData");
            string result = new SearchTestLogic(Driver, testData).MakeSearchProcess();
            Assert.True(testData.Search == result);
            RecordTestResult(currentTestName, TestResult.Pass);
        }

        [Fact]
        public void MakeSearchProcess_EmptySearch()
        {
            var testData = TestData.LoadData("WrongData");
            string result = new SearchTestLogic(Driver, testData).MakeSearchProcess();
            Assert.False(testData.Search == result);
            RecordTestResult(currentTestName, TestResult.Pass);
        }
    }
}