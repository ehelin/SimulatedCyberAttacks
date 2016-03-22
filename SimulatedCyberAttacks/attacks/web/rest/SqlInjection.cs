using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.interfaces.web;
using Shared;

namespace SimulatedCyberAttacks.attacks.web.rest
{
    //TODO - implement this class
    public class SqlInjection : WebServiceAttack, ISqlInjection
    {
        public SqlInjection(string pUrl)
        {
            this.Url = pUrl;

            LoadSqlInjectionPayload();
        }

        public void RunAttack()
        {
            RunInjectionAttack();
        }
        
        private async Task<Object> RunInjectionAttack()
        {
            Connect c = new Connect(this.Url);
            object result = null;

            foreach(string attackString in attackStrings)
            {
                //System.Console.WriteLine("Running simulated attack for character '" + injectionString + "'");

                //IEnumerable<string> values = await GetValues(c);
                
                //string token = await ProcessUser(c, attackString);
                //bool registered = await ProcessRegistration(c, attackString);
                string[] bucketListItems = await GetBucketListItems(c, attackString);
                string[] upsertResults = await Upsert(c, attackString);
                string[] deleteResults = await Delete(c, attackString);
            }

            return result;
        }

        private async Task<string[]> GetValues(Connect c)
        {
            string[] values = await c.GetValues().ConfigureAwait(false);

            return values;
        }
        private async Task<string> ProcessUser(Connect c, string attackString)
        {
            string token = await c.ProcessUser(Utilities.EncodeClientBase64String(attackString), 
                                                 Utilities.EncodeClientBase64String(attackString));
            
            return token;
        }
        private async Task<bool> ProcessRegistration(Connect c, string attackString)
        {
            bool registered = await c.ProcessRegistration(Utilities.EncodeClientBase64String(attackString), 
                                                          Utilities.EncodeClientBase64String(attackString),
                                                          Utilities.EncodeClientBase64String(attackString));

            return registered;
        }
        private async Task<string[]> GetBucketListItems(Connect c, string attackString)
        {
            string[] bucketListitems = await c.GetBucketListItems(Utilities.EncodeClientBase64String(attackString), 
                                                                  Utilities.EncodeClientBase64String(attackString),
                                                                  Utilities.EncodeClientBase64String(attackString));

            return bucketListitems;
        }
        private async Task<string[]> Upsert(Connect c, string attackString)
        {
            string[] result = await c.Upsert(Utilities.EncodeClientBase64String(attackString), 
                                             Utilities.EncodeClientBase64String(attackString),
                                             Utilities.EncodeClientBase64String(attackString));

            return result;
        }
        private async Task<string[]> Delete(Connect c, string attackString)
        {
            string[] result = await c.Delete(Utilities.EncodeClientBase64String(attackString), 
                                             Utilities.EncodeClientBase64String(attackString),
                                             Utilities.EncodeClientBase64String(attackString));

            return result;
        }
    }
}
