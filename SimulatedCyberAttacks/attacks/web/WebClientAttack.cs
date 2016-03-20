using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace SimulatedCyberAttacks.attacks.web
{
    public class WebClientAttack : WebAttack
    {
        protected RemoteWebDriver browser = null;

        protected void SubmitAttackToLoginPage(string injectionString)
        {         
            browser.FindElement(By.Id("loginDesktopUserName")).Clear();
            browser.FindElement(By.Id("loginDesktopPassWord")).Clear();
            
            System.Threading.Thread.Sleep(_testStepInterval);

            browser.FindElement(By.Id("loginDesktopUserName")).SendKeys(injectionString);
            browser.FindElement(By.Id("loginDesktopPassWord")).SendKeys(injectionString);
            
            System.Threading.Thread.Sleep(_testStepInterval);

            IWebElement link = browser.FindElement(By.Id("loginDesktopSubmitClick"));
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval);

            browser.SwitchTo().Alert().Accept();
            System.Threading.Thread.Sleep(_testStepInterval);
        }   
    }
}
