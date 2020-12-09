namespace Billogram.Structures
{
    namespace Customer
    {
        public class List
        {
            public string status { get; set; }
            public Data[] data { get; set; }
            public Meta meta { get; set; }
            public class Data
            {
                public uint customer_no { get; set; }
                public string name { get; set; }
                public string notes { get; set; }
                public string org_no { get; set; }
                public string vat_no { get; set; }
                public string language { get; set; }
                public Contact contact { get; set; }
                public Address address { get; set; }
                public DeliveryAdress delivery_address { get; set; }
                public PaymentSettings payment_settings { get; set; }
                public string created_at { get; set; }
                public string updated_at { get; set; }
                public string company_type { get; set; }


                public class Contact
                {
                    public string name { get; set; }
                    public string email { get; set; }
                    public string phone { get; set; }
                }
                public class Address
                {
                    public string careof { get; set; }
                    public bool use_careof_as_attention { get; set; }
                    public string street_address { get; set; }
                    public string zipcode { get; set; }
                    public string city { get; set; }
                    public string country { get; set; }
                }
                public class DeliveryAdress
                {
                    public string name { get; set; }
                    public string street_address { get; set; }
                    public string careof { get; set; }
                    public string zipcode { get; set; }
                    public string city { get; set; }
                    public string country { get; set; }
                }
                public class PaymentSettings
                {
                    public string recurring_payment_type { get; set; }
                }
            }
            public class Meta
            {
                public string total_count { get; set; }
            }
        }
    }

  
}
