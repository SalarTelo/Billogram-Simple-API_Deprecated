using System;
using System.Collections.Generic;
using System.Text;

namespace Billogram.Structures.Customer
{

    //TODO: The data objects are mixed up between customer and invoice. Change this back to normal
    public class List : IStructureList, ICustomerStructure
    {
        public string status { get; set; }
        public Data[] data { get; set; }
        public Meta meta { get; set; }
        public class Meta
        {
            public string total_count { get; set; }
        }
        public class Data
            {
                public string id { get; set; }
                public string invoice_no { get; set; }
                public string state { get; set; }
                public string flags { get; set; }
                public string invoice_date { get; set; }
                public string due_date { get; set; }
                public string currency { get; set; }
                public string ocr_number { get; set; }
                public string creditor_unique_value { get; set; }
                public double remaining_sum { get; set; }
                public string total_sum { get; set; }
                public string created_at { get; set; }
                public string updated_at { get; set; }
                public Customer customer { get; set; }
                public class Customer
                {
                    public int number { get; set; }
                    public string org_no { get; set; }
                    public string name { get; set; }
                    public string email { get; set; }
                }
            }
    }
}
