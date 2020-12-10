namespace Billogram.Query
{
    public sealed class InvoiceParamQuery : QuerySearchParameter
    {
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
                case SearchField.Id:
                    temp += "&filter_field=id";
                    break;
                case SearchField.Invoice_No:
                    temp += "&filter_field=invoice_no";
                    break;
                case SearchField.Invoice_Date:
                    temp += "&filter_field=invoice_date";
                    break;
                case SearchField.Due_Date:
                    temp += "&filter_field=due_date";
                    break;
                case SearchField.OCR_Number:
                    temp += "&filter_field=ocr_number";
                    break;
                case SearchField.Customer_Name:
                    temp += "&filter_field=customer:name";
                    break;
                case SearchField.Customer_CustomerNo:
                    temp += "&filter_field=customer:customer_no";
                    break;
                case SearchField.Customer_OrgNo:
                    temp += "&filter_field=customer:org_no";
                    break;
                case SearchField.State:
                    temp += "&filter_field=state";
                    break;
                case SearchField.Creditor_Unique_Value:
                    temp += "&filter_field=creditor_unique_value";
                    break;
            }
            return temp;
        }
        private string OrderParam()
        {
            string temp = "";
            switch (Order_Field)
            {
                case OrderField.Invoice_No:
                    temp += "&order_field=invoice_no";
                    break;
                case OrderField.Invoice_Date:
                    temp += "&order_field=invoice_date";
                    break;
                case OrderField.Due_Date:
                    temp += "&order_field=due_date";
                    break;
                case OrderField.Customer_Name:
                    temp += "&order_field=customer:name";
                    break;
                case OrderField.Customer_CustomerNo:
                    temp += "&order_field=customer:customer_no";
                    break;
                case OrderField.State:
                    temp += "&order_field=state";
                    break;
                case OrderField.Attested_At:
                    temp += "&order_field=attested_at";
                    break;
            }
            return temp + GetOrderDirection;
        }
        public override string Param()
        {
            return base.Param() + FilterParam() + OrderParam();
        }
        public enum SearchField
        {
            Id,
            Invoice_No,
            Invoice_Date,
            Due_Date,
            OCR_Number,
            Customer_Name,
            Customer_CustomerNo,
            Customer_OrgNo,
            State,
            Creditor_Unique_Value
        }
        public enum OrderField
        {
            Invoice_No,
            Invoice_Date,
            Due_Date,
            Customer_Name,
            Customer_CustomerNo,
            State,
            Attested_At
        }


    }
}
