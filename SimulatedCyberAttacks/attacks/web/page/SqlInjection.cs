using Shared.interfaces.web;
using OpenQA.Selenium.Firefox;

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
            BringUpLoginPage();
 	        RunClientSqlInjection();
        }
        private void RunClientSqlInjection()
        {
            foreach(string injectionString in attackStrings)
                this.SubmitAttackToLoginPage(injectionString);
        }  
    }
}
