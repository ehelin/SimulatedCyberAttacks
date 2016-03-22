using System;
using Shared.interfaces.web;
using Shared;

namespace SimulatedCyberAttacks.attacks.web.wcf
{
    public class SqlInjection : WebServiceAttack, ISqlInjection
    {
        public SqlInjection()
        {
            LoadSqlInjectionPayload();
            client = new BucketListServicesWcf.BucketListServicesClient();
        }

        public void RunAttack()
        {
            RunInjectionAttack();
        }
         
        protected override void RunInjectionAttack()
        {
            foreach(string injectionString in attackStrings)
            {
                Console.WriteLine("");
                Console.WriteLine("Running SQL Injection attack for character(s) " + injectionString);

                string puResult = ProcessUser(injectionString);
                ReportResultString("", puResult, injectionString, "ProcessUser(string, string)");

                System.Threading.Thread.Sleep(this._testStepInterval);   //Make output readable and not a blur :)
                
                bool purBool = ProcessRegistration(injectionString);
                ReportResultBool(false, purBool, injectionString, "ProcessUserRegistration(string, string, string)");
                
                System.Threading.Thread.Sleep(this._testStepInterval);   //Make output readable and not a blur :)

                string[] gbli = GetBucketListItems(injectionString);
                string[] expected = new string[]{"ERR_000002-Token Expired"};
                ReportResultStringArray(expected, gbli, injectionString, "GetBucketListItems(string, string, string)");
                
                System.Threading.Thread.Sleep(this._testStepInterval);   //Make output readable and not a blur :)

                string[] ubli = UpsertBucketListItem(injectionString);
                ReportResultStringArray(expected, ubli, injectionString, "UpsertBucketListItem(string, string, string)");
                
                System.Threading.Thread.Sleep(this._testStepInterval);   //Make output readable and not a blur :)

                string[] dbli = DeleteBucketListItem(injectionString);
                ReportResultStringArray(expected, dbli, injectionString, "DeleteBucketListItem(int, string, string)");
                
                System.Threading.Thread.Sleep(this._testStepInterval);   //Make output readable and not a blur :)
            }
        } 

        private string ProcessUser(string injectionString)
        {
            string result = string.Empty;

            try
            {
                result = client.ProcessUser(Utilities.EncodeClientBase64String(injectionString), 
                                            Utilities.EncodeClientBase64String(injectionString));
            }
            catch(Exception e)
            {
                Console.WriteLine("WCF-SqlInjection-ProcessUser(args): " + e.Message);
            }

            return result;
        }
        private bool ProcessRegistration(string injectionString)
        {
            bool result = false;

            try
            {
                result = client.ProcessUserRegistration(Utilities.EncodeClientBase64String(injectionString), 
                                                        Utilities.EncodeClientBase64String(injectionString), 
                                                        Utilities.EncodeClientBase64String(injectionString));
            }
            catch(Exception e)
            {
                Console.WriteLine("WCF-SqlInjection-ProcessUserRegistration(args): " + e.Message);
            }

            return result;
        }
        private string[] GetBucketListItems(string injectionString)
        {    
            string[] result = null;

            try
            {
                result = client.GetBucketListItems(Utilities.EncodeClientBase64String(injectionString),
                                                Utilities.EncodeClientBase64String(injectionString),
                                                Utilities.EncodeClientBase64String(injectionString));
            }
            catch(Exception e)
            {
                Console.WriteLine("WCF-SqlInjection-GetBucketListItems(args): " + e.Message);
            }

            return result;
        }
        private string[] UpsertBucketListItem(string injectionString)
        {    
            string[] result = null;

            try
            {
                result = client.UpsertBucketListItem(Utilities.EncodeClientBase64String(injectionString),
                                                            Utilities.EncodeClientBase64String(injectionString),
                                                            Utilities.EncodeClientBase64String(injectionString));
            }
            catch(Exception e)
            {
                Console.WriteLine("WCF-SqlInjection-UpsertBucketListItem(args): " + e.Message);
            }

            return result;
        }        
        private string[] DeleteBucketListItem(string injectionString)
        {    
            string[] result = null;

            try
            {
                result = client.DeleteBucketListItem(0, 
                                    Utilities.EncodeClientBase64String(injectionString), 
                                    Utilities.EncodeClientBase64String(injectionString));
            }
            catch(Exception e)
            {
                Console.WriteLine("WCF-SqlInjection-DeleteBucketListItem(args): " + e.Message);
            }

            return result;
        }
    }
}
