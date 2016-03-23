using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Newtonsoft.Json;

namespace SimulatedCyberAttacks.attacks.web.rest
{
    public class Connect
    {
        private string url = string.Empty;
        private HttpClient client = null;

        public Connect(string pUrl)
        {
            url = pUrl;

            client = new HttpClient();
            client.BaseAddress = new System.Uri(url);
        }

        public async Task<string> ProcessUser(string userName, string passWord)
        {
            string callUrl = "/api/Account";
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("encodedUser", userName);
            values.Add("encodedPass", passWord);
            string result = String.Empty;

            try
            {
                HttpClient localClient = new HttpClient();
                localClient.BaseAddress = new System.Uri(this.url);
                var content = new StringContent(JsonConvert.SerializeObject(values), System.Text.Encoding.UTF8, "application/json");
                var response = await localClient.PostAsync(callUrl, content);

                result = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<string>(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }
            
            return result;
        }
        public async Task<bool> ProcessRegistration(string userName, string passWord, string email)
        {
            string callUrl = "/api/Registration";
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("encodedUser", userName);
            values.Add("encodedPass", passWord);
            values.Add("encodedEmail", email);
            bool registered = false;

            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(values), System.Text.Encoding.UTF8, "application/json");
                var response = await client.PostAsync(callUrl, content);

                var result = await response.Content.ReadAsStringAsync();
                registered = Convert.ToBoolean(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }

            return registered;
        }
        public async Task<string[]> GetBucketListItems(string encodedUserName, string encodedSortString, string encodedToken)
        {
            var query = System.Web.HttpUtility.ParseQueryString(string.Empty);
            query["encodedUserName"] = encodedUserName;
            query["encodedSortString"] = encodedSortString;
            query["encodedToken"] = encodedToken;
            string queryString = query.ToString();
            string[] results = null;
            string callUrl = "/api/BucketList?" + queryString;

            try
            {
                var response = await client.GetAsync(callUrl).ConfigureAwait(false);
                string contentResult = await response.Content.ReadAsStringAsync();
                
                results = contentResult.Split(',');                
                results = JsonConvert.DeserializeObject<string[]>(results[0]);
            }
            catch(Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }

            return results;
        }
        public async Task<string[]> Upsert(string bucketListItems, string userName, string token)
        {
            string callUrl = "/api/BucketListUpsert";
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("encodedBucketListItems", bucketListItems);
            values.Add("encodedUser", userName);
            values.Add("encodedToken", token);
            string result = String.Empty;
            string[] results = null;

            try
            {
                HttpClient localClient = new HttpClient();
                localClient.BaseAddress = new System.Uri(this.url);
                var content = new StringContent(JsonConvert.SerializeObject(values), System.Text.Encoding.UTF8, "application/json");
                var response = await localClient.PostAsync(callUrl, content);                
                string contentResult = await response.Content.ReadAsStringAsync();
                
                results = contentResult.Split(',');                
                results = JsonConvert.DeserializeObject<string[]>(results[0]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            return results;
        }        
        public async Task<string[]> Delete(string bucketListDbId, string encodedUser, string encodedToken)
        {
            string callUrl = "/api/BucketListDelete";
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("bucketListDbId", bucketListDbId);
            values.Add("encodedUser", encodedUser);
            values.Add("encodedToken", encodedToken);
            string result = String.Empty;
            string[] results = null;

            try
            {
                HttpClient localClient = new HttpClient();
                localClient.BaseAddress = new System.Uri(this.url);
                var content = new StringContent(JsonConvert.SerializeObject(values), System.Text.Encoding.UTF8, "application/json");
                var response = await localClient.PostAsync(callUrl, content);

                string contentResult = await response.Content.ReadAsStringAsync();
                
                results = contentResult.Split(',');                
                results = JsonConvert.DeserializeObject<string[]>(results[0]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            return results;
        }
    }
}
