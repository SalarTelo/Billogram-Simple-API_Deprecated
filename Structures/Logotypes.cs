namespace Billogram.Structures
{
    public class Logotypes: IStructureUnique, IFetchable
    {
        public Data data { get; set; }
        public class Data {
            public string content { get; set; }
            public string file_type { get; set; }
        }
    }
}
