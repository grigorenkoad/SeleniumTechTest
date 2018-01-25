namespace Framework.Pages
{
    public class BasePage
    {
        protected Browser Browser;

        public BasePage()
        {
            this.Browser = Browser.Get();
        }
    }
}
