namespace Billogram.Query
{
    public class ItemParamQuery : QueryParameter
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
                case SearchField.Item_No:
                    temp += "&filter_field=item_no";
                    break;
                case SearchField.Title:
                    temp += "&filter_field=title";
                    break;
                case SearchField.Description:
                    temp += "&filter_field=description";
                    break;
                case SearchField.Price:
                    temp += "&filter_field=price";
                    break;
                case SearchField.Book_Keeping_IncomeAccount:
                    temp += "&filter_field=bookkeeping:income_account";
                    break;
                case SearchField.Book_Keeping_VatAccount:
                    temp += "&filter_field=bookkeeping:vat_account";
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

                case OrderField.Item_No:
                    temp += "&order_field=item_no";
                    break;

                case OrderField.Title:
                    temp += "&order_field=title";
                    break;

                case OrderField.Price:
                    temp += "&order_field=price";
                    break;

                case OrderField.Created_At:
                    temp += "&order_field=created_at";
                    break;

                case OrderField.Update_At:
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
            Item_No,
            Title,
            Description,
            Price,
            Book_Keeping_IncomeAccount,
            Book_Keeping_VatAccount
        }
        public enum OrderField
        {
            None,
            Item_No,
            Title,
            Price,
            Created_At,
            Update_At
        }
    }
}
