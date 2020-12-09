namespace Billogram.Structures
{
    public class CoverPhoto
    {
        public Data data { get; set; }
        public class Data
        {
            public string content { get; set; }
            public string file_type { get; set; }
        }
    }
}
