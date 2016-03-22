using System;
using Shared.interfaces.web;
using Shared;

namespace SimulatedCyberAttacks
{
    class Program
    {
        static void Main(string[] args)
        {
            RunSimumatedAttacks();

            Console.Read();  //don't close til developer closes application :)
        }

        private static void RunSimumatedAttacks()
        {
            Console.WriteLine("Starting simulated attacks (localhost targets only!) - " + DateTime.Now.ToString());

            //RunBasicTests();
            //RunBasicAttacks();
            RunServiceSimumatedSqlInjectionAttacks();
            //RunClientSimumatedSqlInjectionAttacks();

            Console.WriteLine("Simulated attacks completed (localhost targets only!) - " + DateTime.Now.ToString());
        }        
        private static void RunServiceSimumatedSqlInjectionAttacks()
        { 
            Console.WriteLine("Running service simulated sql injection tests (localhost targets only!)");
            
            //Utilities.Setup();
            //ISqlInjection siService = new SimulatedCyberAttacks.attacks.web.wcf.SqlInjection();
            //siService.RunAttack();
            
            //Utilities.Setup();
            ISqlInjection siService = new SimulatedCyberAttacks.attacks.web.rest.SqlInjection("http://localhost:12738");
            siService.RunAttack();
        }
        private static void RunClientSimumatedSqlInjectionAttacks()
        {
            Console.WriteLine("Running client simulated sql injection tests (localhost targets only!)");
            Utilities.Setup();
            
            ISqlInjection siClient = new SimulatedCyberAttacks.attacks.web.page.SqlInjection("http://localhost:12738/WebBucketList/Desktop");
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
