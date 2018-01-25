using Framework.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Tests1.Steps
{
    [Binding]
    public class ToDoSteps
    {
        private ToDoPage page;

        [Given(@"TO-DO Page is opened")]
        public void GivenTO_DOPageIsOpened()
        {
            page = new ToDoPage().Open();
        }
        
        [When(@"I type ""(.*)"" text into TO-DO Input on TO-DO Page")]
        public void WhenITypeTextIntoTO_DOInputOnTO_DOPage(string text)
        {
            page.FillInput(text);
        }

        [When(@"I open Active tab")]
        public void WhenIOpenActiveTab()
        {
            page.ClickActive();
        }

        [When(@"I (complete|uncomplete) ""(.*)"" TO-DO")]
        public void WhenCompleteTO_DO(string state, string text)
        {
            page.CheckToDo(text);
        }

        [When(@"I open Completed tab")]
        public void WhenIOpenCompletedTab()
        {
            page.ClickCompleted();
        }

        [When(@"clear compleded TO-DO")]
        public void WhenClearComplededTO_DO()
        {
            page.ClickClearCompleted();
        }

        [Then(@"""(.*)"" TO-DO is (displayed|missing) in TO-DO list")]
        public void ThenTO_DOIsDisplayedInTO_DOList(string text, string state)
        {
            Assert.AreEqual(state.Equals("displayed"), page.IsToDoDisplayed(text));
        }

        [Then(@"count of TO-DO should be equal ""(.*)""")]
        public void ThenCountOfTO_DOShouldBeEqual(string count)
        {
            Assert.AreEqual(count, page.GetCountOfToDo());
        }

        [Then(@"Clear Completed option is displayed")]
        public void ThenClearCompletedOptionIsDisplayed()
        {
            Assert.IsTrue(page.IsClearCompletedDisplayed());
        }
    }
}
