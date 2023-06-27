
namespace Fotius.Example.Todo
{
    public class TodoListWebPageTest : IDisposable
    {
        private IWebDriver driver;

        public object By { get; private set; }
       
        public TodoListWebPageTest()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--remote-allow-origins=*");
            driver = new ChromeDriver(options);
        }

        public void Dispose()
        {
            // TODO: comment Quit method call to keep browser open after test
            driver.Quit();
        }

        [Fact]
        public void TestAddingItemToTodoList()
        {
            GoToHtmlPage();
            // Add a new item
            IWebElement todoInput = driver.FindElement(By.id("todo"));
            IWebElement addButton = driver.FindElement(By.id("add"));
            todoInput.SendKeys("Task 1");
            addButton.Click();

            // Verify the item is added to the list
            IWebElement todoItem = driver.FindElement(By.XPath("//div[@class='col' and text()='Task 1']"));
            Assert.NotNull(todoItem);
        }

        [Fact]
        public void TestRemovingItemFromTodoList()
        {
            GoToHtmlPage();
            // Add a new item
            IWebElement todoInput = driver.FindElement(By.Id("todo"));
            IWebElement addButton = driver.FindElement(By.Id("add"));
            todoInput.SendKeys("Task 1");
            addButton.Click();

            // Remove the item
            IWebElement removeButton = driver.FindElement(By.XPath("//div[@class='col' and text()='Task 1']/../div/button"));
            removeButton.Click();

            // Verify the item is removed from the list
            bool itemPresent = driver.FindElements(By.XPath("//div[@class='col' and text()='Task 1']")).Count > 0;
            Assert.False(itemPresent);
        }

        [Fact]
        public void TestAddingMultipleItemsToTodoList()
        {
            GoToHtmlPage();
            // Add multiple items to the list
            string[] tasks = { "Task 1", "Task 2", "Task 3" };
            foreach (string task in tasks)
            {
                IWebElement todoInput = driver.FindElement(By.Id("todo"));
                IWebElement addButton = driver.FindElement(By.Id("add"));
                todoInput.SendKeys(task);
                addButton.Click();
            }

            // Verify all items are added to the list
            foreach (string task in tasks)
            {
                IWebElement todoItem = driver.FindElement(By.XPath("//div[@class='col' and text()='" + task + "']"));
                Assert.NotNull(todoItem);
            }
        }

        void GoToHtmlPage()
        {
            string basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Resources");
            string htmlPath = Path.Combine(basePath, "todo.html");
            string absolutePath = Path.GetFullPath(htmlPath);
            driver.Url = "file:///" + absolutePath;
        }
    }
}
