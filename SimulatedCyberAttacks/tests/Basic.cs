using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Shared;

namespace SimulatedCyberAttacks.tests
{
    public class Basic
    {
        public Basic()
        {
            Utilities.ClearDb();
        }

        public void RunTests()
        {
            BucketListServicesWcf.BucketListServicesClient client = new BucketListServicesWcf.BucketListServicesClient();
        
            if (!string.IsNullOrEmpty(Login("userName", "passWord1", client)))
                throw new Exception("Login result is not empty");

            if (Register("userName", "passWord1", "test@aol.com", client) != true)
                throw new Exception("Registration failed");

            if (string.IsNullOrEmpty(Login("userName", "passWord1", client)))
                throw new Exception("Login result is empty");
        }

        private string Login(string user, string pass, BucketListServicesWcf.BucketListServicesClient client)
        {
            string result = string.Empty;

            try
            {
                result = client.ProcessUser(Utilities.EncodeClientBase64String(user), Utilities.EncodeClientBase64String(pass));
            }
            catch(Exception e)
            {
                throw e;
            }

            return result;
        }
        private bool Register(string user, string pass, string email, BucketListServicesWcf.BucketListServicesClient client)
        {
            bool result = false;

            try
            {
                result = client.ProcessUserRegistration(Utilities.EncodeClientBase64String(user), Utilities.EncodeClientBase64String(email), Utilities.EncodeClientBase64String(pass));
            }
            catch(Exception e)
            {
                throw e;
            }

            return result;
        }
    }
}
