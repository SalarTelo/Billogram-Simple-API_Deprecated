namespace Billogram.Structures
{
    public class Reports
    {
        public Data data { get; set; }
        public class Data
        {
            public string filename { get; set; }
            public string type { get; set; }
            public string file_type { get; set; }
            public string info { get; set; }
            public string created_at { get; set; }
            public string content { get; set; }
        }
    }
}
