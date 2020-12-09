using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Billogram
{
    class BillogramClient 
    {
        private HttpClient m_client;
        private string m_APIKey;
        private string m_APIUser;
        private string m_baseURL;

        public BillogramClient(string baseURL, string user, string pass)
        {
            m_baseURL = baseURL;
            m_APIUser = user;
            m_APIKey = pass;

            byte[] byteArray = Encoding.ASCII.GetBytes(m_APIUser + ":" + m_APIKey);
            m_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            m_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public BillogramClient(string user, string pass, bool isSandbox)
        {
            m_baseURL = isSandbox ?  "https://sandbox.billogram.com/api/v2" : "https://billogram.com/api/v2";
            m_baseURL = user;
            m_APIUser = pass;

            byte[] byteArray = Encoding.ASCII.GetBytes(m_APIUser + ":" + m_APIKey);
            m_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            m_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public void UpdateCredentials(string baseURL, string username, string password)
        {
            m_baseURL = baseURL;
            m_APIUser = username;
            m_APIKey = password;

            byte[] byteArray = Encoding.ASCII.GetBytes(m_APIUser + ":" + m_APIKey);
            m_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            m_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<bool> TestConnection()
        {
            var url = m_baseURL + "customer" + "?page=" + 1 + "&page_size=" + 1;
            try
            {
                var response = await m_client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                var temp = JsonConvert.DeserializeAnonymousType(responseBody, new { status = "" });
                return temp.status == "OK";
            }
            catch
            {
                return false;
            }
        }

        public struct Customer
        {
        }
        public struct Invoice
        {
        }
        public struct Items
        {
        }
        public struct Settings
        {
        }
        public struct Logotype
        {
        }
        public struct CoverPhoto
        {

        }
        public struct Reports
        {
        }

    }
}
