using System;
using System.Collections.Generic;
using System.Text;

namespace Billogram
{
    public class BillogramCredentials
    {
        public string API_UserName { get; set; }
        public string API_Secret { get; set; }
        public string API_BaseUrl { get; set; }
        public BillogramCredentials(string APIBaseUrl, string APIUserName, string APISecret)
        {
            API_UserName = APIUserName;
            API_Secret = APISecret;
            API_BaseUrl = APIBaseUrl;
        }
    }
}
