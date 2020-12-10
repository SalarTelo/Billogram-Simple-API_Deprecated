using System;
using System.Collections.Generic;
using System.Text;

namespace Billogram.Structures.Item
{
        public class Unique : IStructureUnique
    {
            public Data data { get; set; }
        public string status { get; set; }

        public class Data
            {
                public string item_no { get; set; }
                public string title { get; set; }
                public string description { get; set; }
                public string price { get; set; }
                public double vat { get; set; }
                public string unit { get; set; }
                public BookKeeping bookkeeping { get; set; }
                public string created_at { get; set; }
                public string updated_at { get; set; }

                public class BookKeeping
                {
                    public string income_account { get; set; }
                    public string vat_account { get; set; }
                }
            }
        }
    }

