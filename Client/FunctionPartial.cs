using Billogram.Handle;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Billogram
{
    public sealed partial class BillogramClient
    {
        public async Task<StatusObject> TestConnection()
        {
            var url = m_APIBaseURL + "/customer" + "?page=" + 1 + "&page_size=" + 1;
            try
            {
                var response = await m_client.GetAsync(url);

                string responseBody = await response.Content.ReadAsStringAsync();
                var temp = JsonConvert.DeserializeObject<Structures.Customer.List>(responseBody);
                return temp.status;
            }
            catch
            {
                return ResponseCode.ERROR_INVALID_OR_UNKNOWN_RESPONSE_CODE.ToString();
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

            var url = m_APIBaseURL + temp + parameters.GetParam();
            try
            {
                var response = await m_client.GetAsync(url);
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

            if (typeof(T) == typeof(Structures.Customer.Unique))
                temp = "/customer/" + id.ToString();

            else if (typeof(T) == typeof(Structures.Invoice.Unique))
                temp = "/billogram/" + id.ToString();

            else if (typeof(T) == typeof(Structures.Reports.Unique))
                temp = "/report/" + id.ToString();

            else
                return null;

            var url = m_APIBaseURL + temp;
            try
            {
                var response = await m_client.GetAsync(url);

                string responseBody = await response.Content.ReadAsStringAsync();
                var deserializedObject = JsonConvert.DeserializeObject<T>(responseBody);
                return deserializedObject;
            }
            catch
            {
                return null;
            }
        }
        public async Task<T> FetchUnique<T>() where T : class, Structures.IStructureUnique
        {
            string temp = string.Empty;

            if (typeof(T) == typeof(Structures.Settings.Unique))
                temp = "/settings";

            else if (typeof(T) == typeof(Structures.Logotypes.Unique))
                temp = "/logotype";

            else if (typeof(T) == typeof(Structures.Reports.Unique))
                temp = "/report";

            else
                return null;

            var url = m_APIBaseURL + temp;
            try
            {
                var response = await m_client.GetAsync(url);

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
                temp = "/customer";

            else if (typeof(T) == typeof(Structures.Invoice.List))
                temp = "/billogram";

            else if (typeof(T) == typeof(Structures.Reports.Unique))
                temp = "/report";

            else if (typeof(T) == typeof(Structures.Item.Unique))
                temp = "/item";
            else
                return null;
            var url = m_APIBaseURL + temp;
            var jsonContent = JsonConvert.SerializeObject(data, Formatting.Indented);
            var dataContent = new StringContent(jsonContent);
            try
            {
                var response = await m_client.PostAsync(url, dataContent);
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
                temp = "/item/" + id.ToString();
            else
                return null;
            var url = m_APIBaseURL + temp;
            try
            {
                var response = await m_client.DeleteAsync(url);
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

            if (typeof(T) == typeof(Structures.Logotypes.Unique))
                temp = "/logotype";
            else if (typeof(T) == typeof(Structures.CoverPhoto.Unique))
                temp = "/coverphoto";
            else
                return null;
            var url = m_APIBaseURL + temp;
            try
            {
                var response = await m_client.DeleteAsync(url);
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

            var url = m_APIBaseURL + temp;
            var jsonContent = JsonConvert.SerializeObject(data, Formatting.Indented);
            var dataContent = new StringContent(jsonContent);
            try
            {
                var response = await m_client.PutAsync(url, dataContent);
                string responseBody = await response.Content.ReadAsStringAsync();
                var deserializedObject = JsonConvert.DeserializeObject<T>(responseBody);
                return deserializedObject;
            }
            catch
            {
                return null;
            }
        }
        public async Task<T> UploadImage<T>(T data) where T : class, Structures.IStructureUnique
        {
            string temp = string.Empty;
            if (typeof(T) == typeof(Structures.Logotypes.Unique))
                temp = "/logotype";

            else if (typeof(T) == typeof(Structures.CoverPhoto.Unique))
                temp = "/coverphoto";

            var url = m_APIBaseURL + temp;
            var jsonContent = JsonConvert.SerializeObject(data, Formatting.Indented);
            var dataContent = new StringContent(jsonContent);
            try
            {
                var response = await m_client.PostAsync(url, dataContent);
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
