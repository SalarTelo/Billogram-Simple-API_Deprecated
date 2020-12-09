using System;
using System.Collections.Generic;
using System.Text;

namespace Billogram.Query
{
    public class QueryParameter
    {
        public QueryParameter()
        {
            Page = 1;
            Page_Size = int.MaxValue;
            Filter_Type = FilterType.None;
            Order_Direction = OrderDirection.Ascending;
        }

        public QueryParameter(int page, int page_size)
        {
            Page = page;
            Page_Size = page_size;
            Filter_Type = FilterType.None;
            Order_Direction = OrderDirection.Ascending;
        }
       
        public int Page { get; set; }
        public int Page_Size { get; set; }

        public FilterType Filter_Type { get; set; }
        public OrderDirection Order_Direction { get; set; }

        protected string GetOrderDirection
        {
            get
            {
                switch (Order_Direction)
                {
                    case OrderDirection.Ascending:
                        return "&order_direction=asc";
                    case OrderDirection.Descending:
                        return "&order_direction=desc";
                }
                return "";
            }
        }
        public virtual string GetParam()
        {
            return $"?page={Page}&page_size={Page_Size}";   
        }
    }
    public enum FilterType
    {
        None,
        Field,
        FieldPrefix,
        FieldSearch,
        Special
    }
    public enum OrderDirection
    {
        Ascending,
        Descending
    }
}
