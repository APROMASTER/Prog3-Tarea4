using Xunit.Abstractions;
using System.Reflection;

public static class TestOutputHelperExtensions
{
    public static string GetTestName(this ITestOutputHelper output)
    {
        var type = output.GetType();
        var testMember = type.GetField("test", BindingFlags.Instance | BindingFlags.NonPublic);
        var test = (ITest) testMember.GetValue(output);
        return test.DisplayName;
    }
}