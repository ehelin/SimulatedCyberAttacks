using Shared.interfaces.web;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace SimulatedCyberAttacks.attacks.web.page
{
    public class SqlInjection : WebClientAttack, ISqlInjection
    {
        public SqlInjection(string pUrl)
        {
            Url = pUrl;
            this.browser = new FirefoxDriver();
        }    
       
        public void RunAttack()
        {
            LoadSqlInjectionPayload();
            browser.Navigate().GoToUrl(Url);
 	        RunClientSqlInjection();
        }
        private void RunClientSqlInjection()
        {
            foreach(string injectionString in attackStrings)
            {
                System.Console.WriteLine("Running simulated attack for character '" + injectionString + "'");
                this.SubmitAttackToLoginPage(injectionString);
            }

            this.browser.Close();
            this.browser.Dispose();
            this.browser = null;
        }  
    }
}
