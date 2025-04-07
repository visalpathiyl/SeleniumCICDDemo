namespace DotNetTestProject.Test
{
    public static class SeleniumCustomMethods
    {
        public static void Method1(this IWebElement locator)
        {
            locator.Click();
        }

        public static void EnterText(this IWebElement locator, string text)
        {
            locator.SendKeys(text);
        }

        public static void Submit(this IWebElement locator)
        {
            locator.Submit();
        }
    }

    
}
