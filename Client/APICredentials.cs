using System;
using System.Collections.Generic;
using System.Text;

namespace Billogram
{
    public class APICredentials
    {
        public string API_UserName { get; set; }
        public string API_Secret { get; set; }
        public string API_BaseUrl { get; set; }
        public APICredentials(string APIBaseUrl, string APIUserName, string APISecret)
        {
            API_UserName = APIUserName;
            API_Secret = APISecret;
            API_BaseUrl = APIBaseUrl;
        }
    }
}
