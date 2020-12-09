namespace Billogram.Structures.Item
{
    public class List
    {
        public string status { get; set; }
        public Meta meta { get; set; }
        public Data[] data { get; set; }
    
        public class Meta
        {
            public int total_count { get; set; }
        }
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
