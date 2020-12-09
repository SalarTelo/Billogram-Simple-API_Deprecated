namespace Billogram.Query
{
    public sealed class CustomerParamQuery : QuerySearchParameter
    {
        public CustomerParamQuery()
        {
            
        }
        public SearchField Search_Field { get; set; }
        public OrderField Order_Field { get; set; }
        private string FilterParam()
        {
            string temp = "";
            switch (Filter_Type)
            {
                case FilterType.None:
                    return temp;
                case FilterType.Field:
                    temp += "&filter_type=field";
                    break;
                case FilterType.FieldPrefix:
                    temp += "&filter_type=field-prefix";
                    break;
                case FilterType.FieldSearch:
                    temp += "&filter_type=field-search";
                    break;
                case FilterType.Special:
                    temp += "&filter_type=special";
                    break;
            }
            switch (Search_Field)
            {
                case SearchField.Name:
                    temp += "&filter_field=name";
                    break;
                case SearchField.Notes:
                    temp += "&filter_field=notes";
                    break;
                case SearchField.Org_No:
                    temp += "&filter_field=org_no";
                    break;
                case SearchField.Customer_No:
                    temp += "&filter_field=customer_no";
                    break;
                case SearchField.Company_Type:
                    temp += "&filter_field=company_type";
                    break;
                case SearchField.Contact_Name:
                    temp += "&filter_field=contact:name";
                    break;
                case SearchField.Contact_Email:
                    temp += "&filter_field=contact:email";
                    break;
                case SearchField.Contact_Phone:
                    temp += "&filter_field=contact:phone";
                    break;
                case SearchField.Address_City:
                    temp += "&filter_field=address:city";
                    break;
                case SearchField.Address_CareOf:
                    temp += "&filter_field=address:careof";
                    break;
                case SearchField.Address_ZipCode:
                    temp += "&filter_field=address:zipcode";
                    break;
                case SearchField.Address_Country:
                    temp += "&filter_field=address:country";
                    break;
                case SearchField.Address_StAddress:
                    temp += "&filter_field=address:street_address";
                    break;
                case SearchField.DeliveryAddress_City:
                    temp += "&filter_field=delivery_address:city";
                    break;
                case SearchField.DeliveryAddress_Name:
                    temp += "&filter_field=delivery_address:name";
                    break;
                case SearchField.DeliveryAddress_CareOf:
                    temp += "&filter_field=delivery_address:careof";
                    break;
                case SearchField.DeliveryAddress_ZipCode:
                    temp += "&filter_field=delivery_address:zipcode";
                    break;
                case SearchField.DeliveryAddress_Country:
                    temp += "&filter_field=delivery_address:country";
                    break;
                case SearchField.DeliveryAddress_StreetAddress:
                    temp += "&filter_field=delivery_address:street_address";
                    break;
            }
            return temp;
        }
        private string OrderParam()
        {
            string temp = "";
            switch (Order_Field)
            {
                case OrderField.None:
                    return temp;
                case OrderField.Customer_No:
                    temp += "&order_field=customer_no"; 
                    break;
                case OrderField.Name:
                    temp += "&order_field=name";
                    break;
                case OrderField.Org_no:
                    temp += "&order_field=org_no";
                    break;
                case OrderField.Contact_Email:
                    temp += "&order_field=contact:email";
                    break;
                case OrderField.Contact_Phone:
                    temp += "&order_field=contact:phone";
                    break;
                case OrderField.Address_ZipCode:
                    temp += "&order_field=address:zipcode";
                    break;
                case OrderField.Address_City:
                    temp += "&order_field=address:city";
                    break;
                case OrderField.DeliveryAddress_Name:
                    temp += "&order_field=delivery_address:name";
                    break;
                case OrderField.DeliveryAddress_ZipCode:
                    temp += "&order_field=delivery_address:zipcode";
                    break;
                case OrderField.DeliveryAddress_City:
                    temp += "&order_field=delivery_address:city";
                    break;
                case OrderField.Created_At:
                    temp += "&order_field=created_at";
                    break;
                case OrderField.Updated_At:
                    temp += "&order_field=updated_at";
                    break;
            }
            return temp + GetOrderDirection;
        }

        public override string GetParam()
        {
            return base.GetParam() + FilterParam() + OrderParam();
        }
        public enum SearchField
        {
            Name,
            Notes,
            Org_No,
            Customer_No,
            Company_Type,
            Contact_Name,
            Contact_Email,
            Contact_Phone,
            Address_City,
            Address_CareOf,
            Address_ZipCode,
            Address_Country,
            Address_StAddress,
            DeliveryAddress_City,
            DeliveryAddress_Name,
            DeliveryAddress_CareOf,
            DeliveryAddress_ZipCode,
            DeliveryAddress_Country,
            DeliveryAddress_StreetAddress
        }
        public enum OrderField
        {
            None,
            Customer_No,
            Name,
            Org_no,
            Contact_Email,
            Contact_Phone,
            Address_ZipCode,
            Address_City,
            DeliveryAddress_Name,
            DeliveryAddress_ZipCode,
            DeliveryAddress_City,
            Created_At,
            Updated_At
        }
    }
}
