using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;

namespace SeleniumTestCalculator
{
    [TestClass]
    public class UnitTest1
    {
        private static readonly string DriverDirectory = "C:\\Users\\Riis\\OneDrive - Zealand Sjællands Erhvervsakademi\\Datamatiker\\3. Semester";
        private static IWebDriver _driver;


        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _driver = new ChromeDriver(DriverDirectory); // fast
            //_driver = new FirefoxDriver(DriverDirectory);  // slow
            //_driver = new EdgeDriver(DriverDirectory); //  not working ...
        }

        [ClassCleanup]
        public static void TearDown()
        {
            _driver.Dispose();
        }

        [TestMethod]
        public void TestMethod()
        {
            string url = "file:///C:\\Users\\Riis\\OneDrive - Zealand Sjællands Erhvervsakademi\\Datamatiker\\3. Semester\\JavaScriptCollect+Calculator\\index.html";
            _driver.Navigate().GoToUrl(url);
            Assert.AreEqual("Document", _driver.Title);
            
            IWebElement inputElement = _driver.FindElement(By.Id("inputField"));
            inputElement.Clear();
            inputElement.SendKeys("seleniumWord");

            IWebElement buttonElement1 = _driver.FindElement(By.Id("saveButton"));
            buttonElement1.Click();

            IWebElement buttonElement2 = _driver.FindElement(By.Id("showButton"));
            buttonElement2.Click();

            IWebElement outputElement = _driver.FindElement(By.Id("buttonResult"));
            string text = outputElement.Text;


            Assert.AreEqual("The total list is: seleniumWord", text);
        }

        [TestMethod]
        public void TestMethodAuto()
        {
            string url = "file:///C:\\Users\\Riis\\OneDrive - Zealand Sjællands Erhvervsakademi\\Datamatiker\\3. Semester\\JavaScriptCollect+Calculator\\index.html";
            _driver.Navigate().GoToUrl(url);
            Assert.AreEqual("Document", _driver.Title);

            IWebElement inputElement = _driver.FindElement(By.Id("inputField"));
            inputElement.Clear();
            inputElement.SendKeys("seleniumWord");
            
            IWebElement buttonElement1 = _driver.FindElement(By.Id("saveButton"));
            buttonElement1.Click();

            IWebElement outputElement = _driver.FindElement(By.Id("autoResult"));
            string text = outputElement.Text;
            Assert.AreEqual("AutoResult is: seleniumWord", text);
        }
    }
}
