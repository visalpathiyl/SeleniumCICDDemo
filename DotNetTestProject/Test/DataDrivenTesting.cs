using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using DotNetTestProject.POM;


//This is a random Test


namespace DotNetTestProject.Test
{ 
    [TestFixture("admin", "password")]



    public class DataDriven
    {
        private IWebDriver _driver;
        private string _userName;
        private string _password;

        public DataDriven(String UserName, String PassWord)
        {
            this._userName = UserName;
            this._password= PassWord;
        }

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            _driver.Manage().Window.Maximize();
        }


        [Test]
        [Category("Smoke")]
        public void Nunit_Project()
        {
            LoginPage lg_p = new LoginPage(_driver);
            lg_p.Log_In();
            lg_p.UserName("admin", "password");
        }


        [TearDown]

        public void TearDown()
        {

            _driver.Dispose();
        }


    }
}

