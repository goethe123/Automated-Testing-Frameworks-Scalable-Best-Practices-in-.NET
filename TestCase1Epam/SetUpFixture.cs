using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[SetUpFixture]
public class SetUpFixture
{
    [OneTimeSetUp]
    public void BeforeAllTests()
    {
        XmlConfigurator.Configure(new FileInfo("Log.config"));
    }
}
