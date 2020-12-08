using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

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
    }
}
