using System.Collections.Generic;
using OpenQA.Selenium;

namespace Framework.Pages
{
    public class ToDoPage : BasePage
    {
        private const string url = "http://todomvc.com/examples/angularjs/#/";

        public static readonly By InputLocator = By.Id("new-todo");
        public static readonly By CountOfToDoLocator = By.XPath("//span[@id='todo-count']/strong");
        public static readonly By ActiveTabLocator = By.XPath("//footer[@id='footer']//a[@href='#/active']");
        public static readonly By CompletedTabLocator = By.XPath("//footer[@id='footer']//a[@href='#/completed']");
        public static readonly By ClearCompletedLocator = By.XPath("//footer[@id='footer']//button[@id='clear-completed']");
        public static readonly string TemplateOfItem = "//ul[@id='todo-list']/li//label[text()='{0}']";
        public static readonly string TemplateOfItemCheckBox = "//ul[@id='todo-list']/li//label[text()='{0}']/../input";

        public ToDoPage Open()
        {
            Browser.GoTo(url);
            return new ToDoPage();
        }

        public void FillInput(string text)
        {
            Browser.Type(InputLocator, text);
            Browser.Submit(InputLocator);
        }

        public void ClickActive()
        {
            Browser.Click(ActiveTabLocator);
        }

        public void ClickCompleted()
        {
            Browser.Click(CompletedTabLocator);
        }

        public void ClickClearCompleted()
        {
            Browser.Click(ClearCompletedLocator);
        }

        public bool IsToDoDisplayed(string text)
        {
            return Browser.IsElementPresent(By.XPath(string.Format(TemplateOfItem, text)));
        }

        public string GetCountOfToDo()
        {
            return Browser.Read(CountOfToDoLocator);
        }

        public void CheckToDo(string text)
        {
            Browser.Click(By.XPath(string.Format(TemplateOfItemCheckBox, text)));
        }

        public bool IsClearCompletedDisplayed()
        {
            return Browser.IsElementPresent(ClearCompletedLocator);
        }
    }
}
