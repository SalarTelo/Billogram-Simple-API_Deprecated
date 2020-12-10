using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Billogram.Handle;
namespace Billogram
{
    public sealed partial class APIClient 
    {
        private readonly HttpClient m_client;
        private string m_APISecret;
        private string m_APIUserName;
        private string m_APIBaseURL;
        public APIClient(string API_BaseUrl, string API_UserName, string API_Secret)
        {
            m_client = new HttpClient();
            m_APIBaseURL = API_BaseUrl;
            m_APIUserName = API_UserName;
            m_APISecret = API_Secret;

            if (m_APIBaseURL.EndsWith("/"))
                m_APIBaseURL = m_APIBaseURL.Remove(m_APIBaseURL.Length - 1, 1);

            byte[] byteArray = Encoding.ASCII.GetBytes(m_APIUserName + ":" + m_APISecret);
            m_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            m_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public APIClient(string API_UserName, string API_Secret, bool isSandbox)
        {
            m_client = new HttpClient();

            m_APIBaseURL = isSandbox ?  "https://sandbox.billogram.com/api/v2" : "https://billogram.com/api/v2";
            m_APIUserName = API_UserName;
            m_APISecret = API_Secret;

            byte[] byteArray = Encoding.ASCII.GetBytes(m_APIUserName + ":" + m_APISecret);
            m_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            m_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public APIClient(string API_BaseURL, APICredentials credentials)
        {
            m_client = new HttpClient();

            m_APIBaseURL = API_BaseURL;
            m_APIUserName = credentials.API_UserName;
            m_APISecret = credentials.API_Secret;

            if (m_APIBaseURL.EndsWith("/"))
                m_APIBaseURL = m_APIBaseURL.Remove(m_APIBaseURL.Length - 1, 1);

            byte[] byteArray = Encoding.ASCII.GetBytes(m_APIUserName + ":" + m_APISecret);
            m_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            m_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public APIClient(APICredentials credentials, bool isSandbox)
        {
            m_client = new HttpClient();

            m_APIBaseURL = isSandbox ? "https://sandbox.billogram.com/api/v2" : "https://billogram.com/api/v2";
            m_APIUserName = credentials.API_UserName;
            m_APISecret = credentials.API_Secret;

            byte[] byteArray = Encoding.ASCII.GetBytes(m_APIUserName + ":" + m_APISecret);
            m_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            m_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void UpdateCredentials(string API_BaseUrl, string API_UserName, string API_Secret)
        {
            m_APIBaseURL = API_BaseUrl;
            m_APIUserName = API_UserName;
            m_APISecret = API_Secret;

            byte[] byteArray = Encoding.ASCII.GetBytes(m_APIUserName + ":" + m_APISecret);
            m_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            m_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public void UpdateCredentials(string baseURL, APICredentials credentials)
        {
            m_APIBaseURL = baseURL;
            m_APIUserName = credentials.API_UserName;
            m_APISecret = credentials.API_Secret;

            byte[] byteArray = Encoding.ASCII.GetBytes(m_APIUserName + ":" + m_APISecret);
            m_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            m_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        

    }

  


}
