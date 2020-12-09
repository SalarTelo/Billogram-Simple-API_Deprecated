namespace Billogram.Query
{
    public sealed class ReportsParamQuery : QuerySearchParameter
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
                case SearchField.Filename:
                    temp += "&filter_field=filename"; 
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
                case OrderField.Filename:
                    temp += "&order_field=filename";
                    break;
                case OrderField.Created_At:
                    temp += "&order_field=created_at";
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
            Filename
        }
        public enum OrderField
        {
            None,
            Filename,
            Created_At
        }
    }
}
