using log4net.Config;

[SetUpFixture]
public class SetUpFixture
{
    [OneTimeSetUp]
    public void BeforeAllTests()
    {
        XmlConfigurator.Configure(new FileInfo("Log.config"));
    }
}
