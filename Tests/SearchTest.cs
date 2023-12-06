using Xunit;
using Xunit.Abstractions;

namespace WebUnitTests
{
    [Collection("Test collection")]
    public class SearchTest : BaseTest
    {
        public SearchTest(ITestOutputHelper outputHelper) : base(outputHelper)
        {}

        [Fact]
        public void UnitTest()
        {
            try
            {
                Assert.True(false);
                RecordTestResult(currentTestName, TestResult.Pass);
            }
            catch (Exception ex)
            {
                RecordTestResult(currentTestName, TestResult.Fail);
            }
        }
    }
}