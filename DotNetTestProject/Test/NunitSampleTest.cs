using DotNetTestProject.POM;
using FluentAssertions;
using System.Text.Json;

namespace DotNetTestProject.Test
{



    [TestFixture("admin", "password")]
    //[TestFixture("admin1", "password1")]
    //[TestFixture("admin2", "password2")]



    public class NunitSampleTest
    {
        private IWebDriver _driver;
        private string _userName;
        private string _passWord;

        public NunitSampleTest(string UserName, string PassWord)
        {
            _userName = UserName;
            _passWord = PassWord;
        }

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            _driver.Manage().Window.Maximize();
            Console.WriteLine(_userName);
            Console.WriteLine(_passWord);

            //ReadJsonFile();
        }

        [Test]
        [Category("DDT")]
        [TestCaseSource(nameof(LoginReadJsonModel))]
        public void ReadingJsonFile(Login log)
        {
            //String json = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LoginData.json");
            //var readjson = File.ReadAllText(json);
            //var logModel = JsonSerializer.Deserialize<Login>(readjson);
            
            LoginPage lg_p = new LoginPage(_driver);
            lg_p.Log_In();
            lg_p.UserName(log.Username, log.Password);
            var loggedIn = lg_p.Isloggedin();

            Assert.IsTrue(loggedIn.empDetails && loggedIn.manUser);
        }

        public static IEnumerable<Login> LoginModel()
        {
            yield return new Login { 

                Username = "admin", 
                Password = "password" 
            };
        }

        public static IEnumerable<Login> LoginReadJsonModel()
        {
            string json = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Test Data", "LoginData.json");
            var readjson = File.ReadAllText(json);
            var logModel = JsonSerializer.Deserialize<List<Login>>(readjson);

            foreach (var item in logModel)
            {
                yield return item;
            }
        }

        private void ReadJsonFile()
        {
            string json = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Test Data",  "LoginData.json");
            var readjson = File.ReadAllText(json);
            var logModel = JsonSerializer.Deserialize<Login>(readjson);
        }


        [Test]
        [TestCase("chrome", "30")]
        public void BrowserTest(string Browser, string Version)
        {
            Console.WriteLine($"Browser is  { Browser} and it's version is {Version}");
        }



        [Test]
        [Category("DDT")]
        [TestCaseSource(nameof(LoginReadJsonModel))]
        public void ReadingJsonFileFluentAssert(Login log)
        {
            //String json = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LoginData.json");
            //var readjson = File.ReadAllText(json);
            //var logModel = JsonSerializer.Deserialize<Login>(readjson);

            LoginPage lg_p = new LoginPage(_driver);
            lg_p.Log_In();
            lg_p.UserName(log.Username, log.Password);
            var loggedIn = lg_p.Isloggedin();

            loggedIn.empDetails.Should().BeTrue();
            loggedIn.manUser.Should().BeTrue();
        }


        [TearDown]

        public void TearDown()
        {

            _driver.Dispose();
        }


    }
}
