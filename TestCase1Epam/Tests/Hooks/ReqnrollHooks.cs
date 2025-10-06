using Reqnroll;
using TestCase1Epam.Core.Hooks;

namespace TestCase1Epam.Tests.Hooks
{
    [Binding]
    public class ReqnrollHooks : BaseScenario
    {
        public ReqnrollHooks(ScenarioContext context) : base(context) { }

        [BeforeScenario(Order = 0)]
        public void BeforeScenario()
        {
            Console.WriteLine("Before Scenario ejecutado");
           InitializeDriver();
        }

        [AfterScenario(Order = 100)]
        public void AfterScenario()
        {
            Cleanup();
            Console.WriteLine("AfterScenarioEjecutado");
        }
    }
}