using Xunit;

[CollectionDefinition("Test collection", DisableParallelization = true)]
public class TestCollection : ICollectionFixture<TestHooks>
{

}