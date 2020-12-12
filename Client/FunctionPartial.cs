using Billogram.Handle;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Billogram
{
    public sealed partial class APIClient
    {
        /// <summary>
        /// Try your connection to the API-Server and make sure your credentials are correct.
        /// </summary>
        /// <returns>Either a bool or an enum for status-code depending on context.</returns>
        public async Task<StatusObject> TryConnecting()
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

        /// <summary>
        /// Fetch a list of all stored object of type T from the server.
        /// </summary>
        /// <typeparam name="T">Any object that is inhereted by the IStructureList interface.</typeparam>
        /// <param name="parameters">For any filtering or ordering of returned list of objects.</param>
        /// <returns>Structure of type T with a list of data that was retrieved from server.</returns>
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

            var url = m_APIBaseURL + temp + parameters.Param();
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

        /// <summary>
        /// Fetch a unique data object of type T from the server.
        /// </summary>
        /// <typeparam name="T">Any object that is inhereted by the IStructureUnique interface.</typeparam>
        /// <param name="id">The id of the data object you're fetching.</param>
        /// <returns>Structure of type T with a the unique data that was retrieved from server.</returns>
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

        /// <summary>
        /// Fetch a unique data object of type T from the server, which doesn't require an ID.
        /// </summary>
        /// <typeparam name="T">Any object that is inhereted by the IStructureUnique interface.</typeparam>
        /// <returns>Structure of type T with a the unique data that was retrieved from server.</returns>
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

        /// <summary>
        /// Create a unique data object of type T and send it to the server.
        /// </summary>
        /// <typeparam name="T">Any object that is inhereted by the IStructureUnique interface.</typeparam>
        /// <param name="data">The object of type T to be created</param>
        /// <returns>The object of the actual object created</returns>
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

        /// <summary>
        /// Delete a unique data object of type T from the server.
        /// </summary>
        /// <typeparam name="T">Any object that is inhereted by the IStructureUnique interface.</typeparam>
        /// <param name="id">The object-id to be deleted</param>
        /// <returns>An empty object of type T</returns>
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

        /// <summary>
        /// Delete a unique data object of type T from the server, which doesn't require an ID.
        /// </summary>
        /// <typeparam name="T">Any object that is inhereted by the IStructureUnique interface.</typeparam>
        /// <returns>An empty object of type T</returns>
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

        /// <summary>
        /// Update a unique data object of type T and update it in the server.
        /// </summary>
        /// <typeparam name="T">Any object that is inhereted by the IStructureUnique interface.</typeparam>
        /// <param name="id">The object-id to be updated.</param>
        /// <param name="data">The data to update the unique with.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Update an Image object of type T from server, which doesn't require an ID. 
        /// </summary>
        /// <typeparam name="T">Any object that is inhereted by the IStructureUnique interface.</typeparam>
        /// <param name="data">The data to update the unique with.</param>
        /// <returns></returns>
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
