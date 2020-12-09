using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Billogram
{
    public sealed partial class BillogramClient 
    {
        private HttpClient m_client;
        private string m_APIKey;
        private string m_APIUser;
        private string m_baseURL = "";
        
        public BillogramClient(string baseURL, string user, string pass)
        {
            m_baseURL = baseURL;
            m_APIUser = user;
            m_APIKey = pass;

            if (m_baseURL.EndsWith("/"))
                m_baseURL = m_baseURL.Remove(m_baseURL.Length - 1, 1);

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
                var temp = JsonConvert.DeserializeObject<Structures.Customer.List>(responseBody);
                return temp.status == "OK";
            }
            catch
            {
                return false;
            }
        }

        public async Task<T> FetchList<T>(Query.QuerySearchParameter parameters) where T : class, Structures.IStructureList
        {
            string temp = string.Empty;

            if (typeof(T) == typeof(Structures.Customer.List))
                temp = "/customer";

            else if (typeof(T) == typeof(Structures.Invoice.List))
                temp = "/billogram";

            else if (typeof(T) == typeof(Structures.Item.List))
                temp = "/item";

            else
                return null;


            var url = m_baseURL + temp + parameters.GetParam();
            try
            {
                var response = await m_client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                var deserializedObject = JsonConvert.DeserializeObject<T>(responseBody);
                return deserializedObject;
            }
            catch
            {
                return null;
            }
        }
        public async Task<T> FetchUnique<T>(object id) where T : class, Structures.IStructureUnique
        {
            string temp = string.Empty;

            if (typeof(T) == typeof(Structures.Customer.List))
                temp = "/customer" + id.ToString();

            else if (typeof(T) == typeof(Structures.Invoice.List))
                temp = "/billogram" + id.ToString();

            else if (typeof(T) == typeof(Structures.Reports))
                temp = "/report" + id.ToString();

            else
                return null;

            var url = m_baseURL + temp;
            try
            {
                var response = await m_client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                var deserializedObject = JsonConvert.DeserializeObject<T>(responseBody);
                return deserializedObject;
            }
            catch
            {
                return null;
            }
        }
        public async Task<T> FetchUnique<T>() where T : class, Structures.IStructureUnique, Structures.IFetchable
        {
            string temp = string.Empty;

            if (typeof(T) == typeof(Structures.Settings))
                temp = "/settings";

            else if (typeof(T) == typeof(Structures.Logotypes))
                temp = "/logotype";

            else if (typeof(T) == typeof(Structures.Reports))
                temp = "/report";

            else
                return null;

            var url = m_baseURL + temp;
            try
            {
                var response = await m_client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                var deserializedObject = JsonConvert.DeserializeObject<T>(responseBody);
                return deserializedObject;
            }
            catch
            {
                return null;
            }
        }
        public async Task<T> CreateUnique<T>(T data) where T : class, Structures.IStructureUnique
        {
            string temp = string.Empty;

            if (typeof(T) == typeof(Structures.Customer.List))
                temp = "/customer" ;

            else if (typeof(T) == typeof(Structures.Invoice.List))
                temp = "/billogram";

            else if (typeof(T) == typeof(Structures.Reports))
                temp = "/report";

            else if (typeof(T) == typeof(Structures.Item.Unique))
                temp = "/item";
            else
                return null;
            var url = m_baseURL + temp;
            var jsonContent = JsonConvert.SerializeObject(data, Formatting.Indented);
            var dataContent = new StringContent(jsonContent);
            try
            {
                var response = await m_client.PostAsync(url, dataContent);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var deserializedObject = JsonConvert.DeserializeObject<T>(responseBody);
                return deserializedObject;
            }
            catch
            {
                return null;
            }
        }
        public async Task<T> DeleteUnique<T>(object id) where T : class, Structures.IStructureUnique
        {
            string temp = string.Empty;

            if (typeof(T) == typeof(Structures.Item.Unique))
                temp = "/item/"+id.ToString();
            else
                return null;
            var url = m_baseURL + temp;
            try
            {
                var response = await m_client.DeleteAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var deserializedObject = JsonConvert.DeserializeObject<T>(responseBody);
                return deserializedObject;
            }
            catch
            {
                return null;
            }
        }
        public async Task<T> DeleteUnique<T>() where T : class, Structures.IStructureUnique
        {
            string temp = string.Empty;

            if (typeof(T) == typeof(Structures.Logotypes))
                temp = "/logotype";
            else if (typeof(T) == typeof(Structures.CoverPhoto))
                temp = "/coverphoto";
            else
                return null;
            var url = m_baseURL + temp;
            try
            {
                var response = await m_client.DeleteAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var deserializedObject = JsonConvert.DeserializeObject<T>(responseBody);
                return deserializedObject;
            }
            catch
            {
                return null;
            }
        }
        public async Task<T> UpdateUnique<T>(object id, T data) where T : class, Structures.IStructureUnique
        {
            string temp = string.Empty;

            if (typeof(T) == typeof(Structures.Customer.Unique))
                temp = "/customer/" + id.ToString();

            else if (typeof(T) == typeof(Structures.Invoice.Unique))
                temp = "/billogram/" + id.ToString();

            else if (typeof(T) == typeof(Structures.Item.Unique))
                temp = "/item/" + id.ToString();

            else if (typeof(T) == typeof(Structures.Item.Unique))
                temp = "/settings/" + id.ToString();
            else
                return null;

            var url = m_baseURL + temp;
            var jsonContent = JsonConvert.SerializeObject(data, Formatting.Indented);
            var dataContent = new StringContent(jsonContent);
            try
            {
                var response = await m_client.PutAsync(url, dataContent);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var deserializedObject = JsonConvert.DeserializeObject<T>(responseBody);
                return deserializedObject;
            }
            catch
            {
                return null;
            }
        }
        public async Task<T> Upload<T>(T data) where T : class, Structures.IStructureUnique
        {
            string temp = string.Empty;
            if (typeof(T) == typeof(Structures.Logotypes))
                temp = "/logotype";

            else if (typeof(T) == typeof(Structures.CoverPhoto))
                temp = "/coverphoto";

            var url = m_baseURL + temp;
            var jsonContent = JsonConvert.SerializeObject(data, Formatting.Indented);
            var dataContent = new StringContent(jsonContent);
            try
            {
                var response = await m_client.PostAsync(url, dataContent);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var deserializedObject = JsonConvert.DeserializeObject<T>(responseBody);
                return deserializedObject;
            }
            catch
            {
                return null;
            }
        }
    }


  


}
