namespace Billogram.Structures.Logotypes
{
    public class Unique: IStructureUnique
    {
        public Data data { get; set; }
        public string status { get; set; }

        public class Data {
            public string content { get; set; }
            public string file_type { get; set; }
        }
    }
}
