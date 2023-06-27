namespace Fotius.Example.Todo
{
    internal interface IWebDriver
    {
        string Url { get; set; }

        IWebElement FindElement(object id);
        object FindElements(object id);
        void Quit();
    }
}