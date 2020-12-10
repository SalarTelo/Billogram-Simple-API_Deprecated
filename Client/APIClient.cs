using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Billogram
{
    public sealed partial class APIClient
    {
        /// <summary>
        /// The medium to communicate with the API.
        /// </summary>
        private readonly HttpClient m_client;
        /// <summary>
        /// The password to the API.
        /// </summary>
        private string m_APISecret;
        /// <summary>
        /// The username to the API.
        /// </summary>
        private string m_APIUserName;
        /// <summary>
        /// The base for the API to call from.
        /// </summary>
        private string m_APIBaseURL;

        /// <summary>
        /// Initialize instance of client credentials.
        /// </summary>
        /// <param name="API_BaseUrl">The base for the API to call from.</param>
        /// <param name="API_UserName">The username to the API.</param>
        /// <param name="API_Secret">The password to the API.</param>
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

        /// <summary>
        /// Initialize instance of client credentials.
        /// </summary>
        /// <param name="API_UserName">The username to the API.</param>
        /// <param name="API_Secret">The password to the API.</param>
        /// <param name="isSandbox">Is the client communicating with a sandbox envoirment?</param>
        public APIClient(string API_UserName, string API_Secret, bool isSandbox)
        {
            m_client = new HttpClient();

            m_APIBaseURL = isSandbox ? "https://sandbox.billogram.com/api/v2" : "https://billogram.com/api/v2";
            m_APIUserName = API_UserName;
            m_APISecret = API_Secret;

            byte[] byteArray = Encoding.ASCII.GetBytes(m_APIUserName + ":" + m_APISecret);
            m_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            m_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Initialize instance of client credentials.
        /// </summary>
        /// <param name="API_BaseURL">The base for the API to call from.</param>
        /// <param name="credentials">The credentials for the API.</param>
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

        /// <summary>
        /// Initialize instance of client credentials.
        /// </summary>
        /// <param name="credentials">The credentials for the API.</param>
        /// <param name="isSandbox">Is the client communicating with a sandbox envoirment?</param>
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

        /// <summary>
        /// Change/Update the credentials of current instance.
        /// </summary>
        /// <param name="API_BaseUrl">The base for the API to call from.</param>
        /// <param name="API_UserName">The username to the API.</param>
        /// <param name="API_Secret">The password to the API.</param>
        public void UpdateCredentials(string API_BaseUrl, string API_UserName, string API_Secret)
        {
            m_APIBaseURL = API_BaseUrl;
            m_APIUserName = API_UserName;
            m_APISecret = API_Secret;

            byte[] byteArray = Encoding.ASCII.GetBytes(m_APIUserName + ":" + m_APISecret);
            m_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            m_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        /// <summary>
        /// Change/Update the credentials of current instance.
        /// </summary>
        /// <param name="API_BaseUrl">The base for the API to call from.</param>
        /// <param name="credentials">The credentials for the API.</param>
        public void UpdateCredentials(string API_BaseUrl, APICredentials credentials)
        {
            m_APIBaseURL = API_BaseUrl;
            m_APIUserName = credentials.API_UserName;
            m_APISecret = credentials.API_Secret;

            byte[] byteArray = Encoding.ASCII.GetBytes(m_APIUserName + ":" + m_APISecret);
            m_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            m_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

    }

}
