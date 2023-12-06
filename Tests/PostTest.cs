using Xunit;
using Xunit.Abstractions;

namespace WebUnitTests
{
    [Collection("Test collection")]
    public class PostTest : BaseTest
    {
        public PostTest(ITestOutputHelper outputHelper) : base(outputHelper)
        {}

        [Fact]
        public void UnitTest()
        {
            try
            {
                Assert.True(false);
                //RecordTestResult(currentTestName, TestResult.Pass);
            }
            catch (Exception ex)
            {
                //RecordTestResult(currentTestName, TestResult.Fail);
            }
        }

        [Fact]
        public void UnitTest2()
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