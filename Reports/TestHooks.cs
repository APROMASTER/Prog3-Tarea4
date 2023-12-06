using Xunit;

public class TestHooks : IAsyncLifetime
{
    public Task InitializeAsync()
    {
        ReportUtil.Initialize();
        return Task.CompletedTask;
    }

    public Task DisposeAsync()
    {
        ReportUtil.FlushReport();
        return Task.CompletedTask;
    }
}