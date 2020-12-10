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
        /// <param name="page">The result page number to fetch. Set to 1 by default.</param>
        /// <param name="page_size">How many results to return per page. Settings this number too high may impact performance, we recommend values between 10 and 100. Set to 10000000 by default to retrieve all.</param>
        public QuerySearchParameter(int page = 1, int page_size = 10000000)
        {
            Page = page;
            Page_Size = page_size;
            Filter_Type = FilterType.None;
            Order_Direction = OrderDirection.Ascending;
        }

        /// <summary>
        /// The result page number to fetch.
        /// </summary>
        public readonly int Page;
        /// <summary>
        /// How many results to return per page. Settings this number too high may impact performance, we recommend values between 10 and 100.
        /// </summary>
        public readonly int Page_Size;

        /// <summary>
        /// The type of filter to be made. NOTE: Must be set to anything other than "None" in order to make filter query!
        /// </summary>
        public readonly FilterType Filter_Type;

        /// <summary>
        /// The order direction (Ascending/Descending) if ordering is being requested.
        /// </summary>
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
        /// <summary>
        /// Make no query for filter.
        /// </summary>
        None,
        /// <summary>
        /// Exact match for the given field
        /// </summary>
        Field,
        /// <summary>
        /// Match a prefix for the given field
        /// </summary>
        FieldPrefix,
        /// <summary>
        /// Match any substring in the given field
        /// </summary>
        FieldSearch,
        /// <summary>
        /// Perform a special search
        /// </summary>
        Special
    }

    /// <summary>
    /// Whether to use ascending or descending ordering for the field specified.
    /// </summary>
    public enum OrderDirection
    {
        Ascending,
        Descending
    }
}
