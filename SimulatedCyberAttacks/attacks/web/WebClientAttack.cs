using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace SimulatedCyberAttacks.attacks.web
{
    public class WebClientAttack : WebAttack
    {
        protected RemoteWebDriver browser = null;

        protected void SubmitAttackToLoginPage(string injectionString)
        {         
            browser.FindElement(By.Id("loginDesktopUserName")).SendKeys(injectionString);
            browser.FindElement(By.Id("loginDesktopPassWord")).SendKeys(injectionString);
            
            System.Threading.Thread.Sleep(_testStepInterval);

            IWebElement link = browser.FindElement(By.Id("loginDesktopSubmitClick"));
            link.Click();
        }        
        protected void BringUpLoginPage()
        {           
            browser.Navigate().GoToUrl(Url);
            string pageText = browser.FindElement(By.TagName("body")).Text;
            
            IWebElement link = browser.FindElementByLinkText("here");
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval);
        }
    }
}
