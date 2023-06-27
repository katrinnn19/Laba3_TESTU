namespace Fotius.Example.Todo
{
    internal class ChromeDriver : IWebDriver
    {
        private ChromeOptions options;

        public ChromeDriver(ChromeOptions options)
        {
            this.options = options;
        }

        public string Url { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IWebElement FindElement(object value)
        {
            throw new NotImplementedException();
        }

        public object FindElements(object value)
        {
            throw new NotImplementedException();
        }

        public void Quit()
        {
            throw new NotImplementedException();
        }
    }
}