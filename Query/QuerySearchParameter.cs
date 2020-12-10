using System;
using System.Collections.Generic;
using System.Text;

namespace Billogram.Query
{
    /// <summary>
    /// The base-class for any filtering and/or ordering when fetching of server.
    /// </summary>
    public class QuerySearchParameter
    {
        /// <summary>
        /// The required parameters for any query. The rest can be set later on through the provided fields. NOTE: Even if no filtering or ordering is requested; 
        /// page and page_size is required for all types of search.
        /// </summary>
        /// <param name="page">The page of being retrieved. Set to 1 by default.</param>
        /// <param name="page_size">The amount of data being retrieved per page. Set to 10000000 by default.</param>
        public QuerySearchParameter(int page = 1, int page_size = 10000000)
        {
            Page = page;
            Page_Size = page_size;
            Filter_Type = FilterType.None;
            Order_Direction = OrderDirection.Ascending;
        }

        public readonly int Page;
        public readonly int Page_Size;

        public readonly FilterType Filter_Type;
        public readonly OrderDirection Order_Direction;

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
        public virtual string Param()
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
