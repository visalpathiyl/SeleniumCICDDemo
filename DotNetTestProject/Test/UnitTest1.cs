using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using DotNetTestProject.Enum_DataDriven;
using DotNetTestProject.POM;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace DotNetTestProject.Test
{

    [TestFixture("admin", "password", EnumTest.edge)]
    public class Tests
    {
        private IWebDriver _driver;
        private string UserName;
        private string Password;
        private EnumTest enumTest;
        private ExtentReports _extentReport;
        private ExtentTest _extentTest;


        public Tests(String userNAme, String passWOrd, EnumTest enumTest)
        {
            this.UserName = userNAme;
            this.Password = passWOrd;
            this.enumTest = enumTest;
        }

        [SetUp]

        public void Setup()
        {

            SetUpExtendedReport();
            _driver = GetDriverType(enumTest);
            _extentTest.Log(Status.Info, "Browser has been alunched");
            _driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            _driver.Manage().Window.Maximize();

        }

        [TearDown]
        public void TearDown()
        {
            _driver.Dispose();
            _extentTest.Log(Status.Info, "Browser has been closed");
            _extentReport.Flush();

        }

        private void SetUpExtendedReport()
        {
            _extentReport = new ExtentReports();
            var spark = new ExtentSparkReporter("TestReport.html");
            _extentReport.AttachReporter(spark);
            _extentReport.AddSystemInfo("OS", "Windows 11");
            _extentReport.AddSystemInfo("Browser", enumTest.ToString());
            _extentReport.AddSystemInfo("Env", "QA");
            _extentReport.AddSystemInfo("Tester", "Visal");
            _extentTest = _extentReport.CreateTest("Log in Test").Log(Status.Pass, "Extended Report Initialized");
        }

        [Test]
        public void Test1()
        {
            //IWebDriver driver = new ChromeDriver();


            WebDriverWait wait_obj = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var wait_ele = wait_obj.Until(d =>
            {
                var wait_ele1 = _driver.FindElement(By.Id("loginLink"));
                return (wait_ele1 != null && wait_ele1.Displayed) ? wait_ele1 : null;

            }
                );



        }

        private IWebDriver GetDriverType(EnumTest enumTest)
        {
            switch (enumTest)
            {
                case EnumTest.Chrome:
                    _driver = new ChromeDriver();

                    break;
                case EnumTest.edge:
                    _driver = new EdgeDriver();

                    break;
                default:
                    _driver = new FirefoxDriver();

                    break;
            }

            return _driver;
        }




        [Test]

        public void browserTest()
        {
            IWebDriver obj = new ChromeDriver();
            // LoginPage obj1 = new LoginPage(obj);
            // obj.Navigate().GoToUrl("http://eaapp.somee.com/");
            // SeleniumCustomMethods.Method1();
            // SeleniumCustomMethods.EnterText(User_Name, Pass_word);

        }


        [Test]

        public void POM_Execution()
        {

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            LoginPage lp_obj = new LoginPage(driver);
            lp_obj.Log_In();
            _extentTest.Log(Status.Info, "Log in page is shown");
            lp_obj.UserName("admin", "password");
            var loggedIn = lp_obj.Isloggedin();
            Assert.IsTrue(loggedIn.empDetails && loggedIn.manUser);
            _extentTest.Log(Status.Info, "Logged in");


        }



    }

}