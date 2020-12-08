using System;
using System.Collections.Generic;
using System.Text;

namespace Billogram.Query
{
    public class QueryParameter
    {
        public int Page { get; set; }
        public int Page_Size { get; set; }
        public FilterType Filter_Type { get; set; }
        public string Filter_value { get; set; }
        public OrderType Order_Type { get; set; }

        public string Value 
        { 
            get
            {
                var temp = $"?page={Page}&page_size={Page_Size}";
                switch (Filter_Type)
                {
                    case FilterType.none:
                        break;
                    case FilterType.field:
                        temp += $"&filter_type=field";
                        break;
                    case FilterType.fieldPrefix:
                        temp += $"&filter_type=field-prefix";
                        break;
                    case FilterType.fieldSearch:
                        temp += $"&filter_type=field-search";
                        break;
                    case FilterType.special:
                        temp += $"&filter_type=special";
                        break;
                }

                switch (Order_Type)
                {
                    case OrderType.none:
                        break;
                    case OrderType.ascending:
                        break;
                    case OrderType.descending:
                        break;
                }
                return
            }
        }
    }
    public enum FilterType
    {
        none,
        field,
        fieldPrefix,
        fieldSearch,
        special
    }
    public enum OrderType
    {
        none,
        ascending,
        descending
    }

    public struct Customer
    {
        public enum Field
        {
            Customer_No,
            Name,
            Notes,
            Org_No,
            Company_Type,
            Contact_Name,
            Contact_Email,
            Contact_Phone,
            Address_StAddress,
            Address_CareOf,
            Address_ZipCode,
            Address_City,
            Address_Country,
            DeliveryAddress_Name,
            DeliveryAddress_StreetAddress,
            DeliveryAddress_CareOf,
            DeliveryAddress_ZipCode,
            DeliveryAddress_City,
            DeliveryAddress_Country
        }
    }
    
}
