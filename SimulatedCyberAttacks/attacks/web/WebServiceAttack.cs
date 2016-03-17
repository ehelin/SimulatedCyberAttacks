using System;

namespace SimulatedCyberAttacks.attacks.web
{
    public class WebServiceAttack : WebAttack
    {        
        protected BucketListServicesWcf.BucketListServicesClient client = null;
        
        protected virtual void RunInjectionAttack(){}       
       
        protected void ReportResultStringArray(string[] expected, string[] actual, string injectionValue, string method)
        {
            if (actual != null && actual.Length>= 1 && !expected[0].Equals(actual[0]))
                Console.WriteLine("--Attack Succeeded! (Expected/Actual) (" + expected.ToString() + "/" + actual.ToString() + ")");
        }
        protected void ReportResultBool(bool expected, bool actual, string injectionValue, string method)
        {
            if (!expected.Equals(actual))
                Console.WriteLine("--Attack Succeeded! (Expected/Actual) (" + expected.ToString() + "/" + actual.ToString() + ")");
        }
        protected void ReportResultString(string expected, string actual, string injectionValue, string method)
        {
            if (!expected.Equals(actual))
                Console.WriteLine("--Attack Succeeded! (Expected/Actual) (" + expected + "/" + actual + ")");
        }
    }
}
