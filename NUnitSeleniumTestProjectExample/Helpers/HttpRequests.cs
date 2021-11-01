using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Text;

namespace NUnitSeleniumTestProjectExample.Helpers
{
    public static class HttpRequests
    {
        public static async Task<T> GetAsync<T>(string url)
        {
            string responseString  = string.Empty;
            using (HttpClient client = new HttpClient())
            {
                try	
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    responseString = await response.Content.ReadAsStringAsync();
                    // Above three lines can be replaced with new helper method below
                    // string responseBody = await client.GetStringAsync(uri);

                    //Console.WriteLine(responseString);
                }
                catch(HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");	
                    Console.WriteLine("Message :{0} ",e.Message);
                }
            }

            T resp = JsonSerializer.Deserialize<T>(responseString);
            return resp ;
        }

        public static async Task<T> GetAsync<T>(string url, Dictionary<string,string> requestParams)
        {
            StringBuilder sbURL = new StringBuilder(url);
            if (requestParams.Count > 0)
            {
                sbURL = sbURL.Append("?");
                foreach (KeyValuePair<string,string> param in requestParams)
                {
                    sbURL.Append(param.Key).Append("=").Append(param.Value).Append("&");
                }

                //remove last & char
                sbURL.Remove(sbURL.Length-1, 1);
            }
            
            string responseString  = string.Empty;
            using (HttpClient client = new HttpClient())
            {
                try	
                {
                    HttpResponseMessage response = await client.GetAsync(sbURL.ToString());
                    response.EnsureSuccessStatusCode();
                    responseString = await response.Content.ReadAsStringAsync();
                    // Above three lines can be replaced with new helper method below
                    // string responseBody = await client.GetStringAsync(uri);

                    //Console.WriteLine(responseString);
                }
                catch(HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");	
                    Console.WriteLine("Message :{0} ",e.Message);
                }
            }

            T resp = JsonSerializer.Deserialize<T>(responseString);
            return resp ;
        }
    }
}