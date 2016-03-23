using System;
using Shared.interfaces.web;
using Shared;

namespace SimulatedCyberAttacks
{
    class Program
    {
        public static bool SimulatedInjectionAttackesComplete = false;
        private static string WebApiUrl = "http://http://localhost:12738";

        static void Main(string[] args)
        {
            RunSimumatedAttacks();

            Console.Read();  //don't close til developer closes application :)
        }

        private static void RunSimumatedAttacks()
        {
            Console.WriteLine("Starting simulated attacks (localhost targets only!) - " + DateTime.Now.ToString());

            //Uncomment these tests, comment out the web api and run Service as start up project on Tgimba project
            SimulatedInjectionAttackesComplete = true;
            RunBasicTests();
            //RunBasicAttacks();
            RunServiceSimumatedSqlInjectionAttacksWcf();  

            //Run these tests separately from the ones above
            //RunClientSimumatedSqlInjectionAttacks();
            //RunServiceSimumatedSqlInjectionAttacksWebApi();

            Console.WriteLine("Simulated attacks completed (localhost targets only!) - " + DateTime.Now.ToString());
        }     
        private static void RunServiceSimumatedSqlInjectionAttacksWebApi()
        { 
            Console.WriteLine("Running web api service simulated sql injection tests (localhost targets only!)");
            
            Utilities.Setup();
            ISqlInjection siService = new SimulatedCyberAttacks.attacks.web.rest.SqlInjection(WebApiUrl);
            siService.RunAttack();
            
            while (!SimulatedInjectionAttackesComplete)
            {
                System.Threading.Thread.Sleep(1000);
                int waitForIt = 1;
            }
        }     
        private static void RunServiceSimumatedSqlInjectionAttacksWcf()
        { 
            Console.WriteLine("Running wcf service simulated sql injection tests (localhost targets only!)");
            
            Utilities.Setup();
            ISqlInjection siService = new SimulatedCyberAttacks.attacks.web.wcf.SqlInjection();
            siService.RunAttack();
        }
        private static void RunClientSimumatedSqlInjectionAttacks()
        {
            Console.WriteLine("Running client simulated sql injection tests (localhost targets only!)");
            Utilities.Setup();
            
            ISqlInjection siClient = new SimulatedCyberAttacks.attacks.web.page.SqlInjection(WebApiUrl + "/WebBucketList/Desktop");
            siClient.RunAttack();
        }
        private static void RunBasicTests()
        {
            Console.WriteLine("Running basic tests (localhost targets only!)");
            Utilities.Setup();

            tests.Basic b = new tests.Basic();
            b.RunTests();
        }
        private static void RunBasicAttacks()
        {
            Console.WriteLine("Running basic attacks (localhost targets only!)");
            Utilities.Setup();

            throw new NotImplementedException();
        }
    }
}
