
using DotNetTestProject.Test;

namespace DotNetTestProject.POM
{
    public class LoginPage(IWebDriver driver)
    {
        //private readonly IWebDriver driver;

        //public LoginPage(IWebDriver driver)
        //{
        //    this.driver = driver;
        //}

        IWebElement Login_Page => driver.FindElement(By.Id("loginLink"));

        IWebElement User_Name => driver.FindElement(By.Id("UserName"));

        IWebElement Pass_word => driver.FindElement(By.Id("Password"));

        IWebElement Submit_Button => driver.FindElement(By.CssSelector(".btn"));

        IWebElement employee_details => driver.FindElement(By.LinkText("Employee Details"));

        IWebElement manage_users => driver.FindElement(By.LinkText("Manage Users"));

        IWebElement log_off => driver.FindElement(By.LinkText("Log off"));




        public void Log_In()
        {
            Login_Page.Method1();
        }

        public void UserName(String UN, String Pass)
        {

            User_Name.EnterText(UN);
            Pass_word.EnterText(Pass);
            Submit_Button.Submit();

        }

        public (bool empDetails, bool manUser) Isloggedin()
        {
            return (employee_details.Displayed, manage_users.Displayed);
        }

        
    }
}
