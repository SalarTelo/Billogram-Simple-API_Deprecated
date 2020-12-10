using System;
using System.Collections.Generic;
using System.Text;

namespace Billogram
{
    /// <summary>
    /// A way to store credentials for the API to decrease redundancy. 
    /// </summary>
    public class APICredentials
    {
        public readonly string API_UserName;
        public readonly string API_Secret;
        public readonly string API_BaseUrl;
        public APICredentials(string APIBaseUrl, string APIUserName, string APISecret)
        {
            API_UserName = APIUserName;
            API_Secret = APISecret;
            API_BaseUrl = APIBaseUrl;
        }
    }
}
