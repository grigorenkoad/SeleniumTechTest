using Framework;
using NLog;
using TechTalk.SpecFlow;

namespace Tests1.Steps
{
    [Binding]
    public class BaseSteps
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        [AfterScenario]
        public void TearDown()
        {
            Browser.Kill();
        }

        [AfterScenario]
        public void AfterScenarioHook()
        {
            if (ScenarioContext.Current.TestError != null)
            {
                var error = ScenarioContext.Current.TestError;
                Log.Error($"An error ocurred: {error.Message}");
                Log.Error($"It was of type: {error.GetType().Name}");
            }
        }
    }
}
