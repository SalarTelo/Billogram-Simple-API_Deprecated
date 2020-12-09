namespace Billogram.Structures.Customer
{

    public class Unique : IStructureUnique, ICustomerStructure
    {
        public Data data { get; set; }
        public class Data
        {
            public string id { get; set; }
            public string invoice_no { get; set; }
            public string ocr_number { get; set; }
            public string creditor_unique_value { get; set; }
            public Customer customer { get; set; }
            public ItemData[] items { get; set; }
            public string invoice_date { get; set; }
            public string due_date { get; set; }
            public int due_days { get; set; }
            public string respite_date { get; set; }
            public double invoice_fee { get; set; }
            public double invoice_fee_vat { get; set; }
            public double reminder_fee { get; set; }
            public double interest_rate { get; set; }
            public double interest_fee { get; set; }
            public string currency { get; set; }
            public InvoiceInfo info { get; set; }
            public RegionalSweden regional_sweden { get; set; }
            public string delivery_method { get; set; }
            public string state { get; set; }
            public string url { get; set; }
            public string recipient_url { get; set; }
            public string[] flags { get; set; }
            public Event[] events { get; set; }
            public double remaining_sum { get; set; }
            public double total_sum { get; set; }
            public int rounding_value { get; set; }
            public bool automatic_reminders { get; set; }
            public ReminderSettings automatic_reminders_settings { get; set; }
            public short reminder_count { get; set; }
            public string created_at { get; set; }
            public string attested_at { get; set; }
            public string updated_at { get; set; }
            public Callback callbacks { get; set; }
            public string attachment { get; set; }
            public AutomaticCollection automatic_collection { get; set; }
            public bool show_item_gross_prices { get; set; }
            public PDF pdf { get; set; }
            public OnSuccess on_success { get; set; }

            public class Customer
            {
                public int customer_no { get; set; }
                public string org_no { get; set; }
                public string name { get; set; }
                public string email { get; set; }
                public string vat_no { get; set; }
                public string phone { get; set; }
                public Address address { get; set; }
                public DeliveryAdress delivery_address { get; set; }
                public class Address
                {
                    public string street_address { get; set; }
                    public string city { get; set; }
                    public string zipcode { get; set; }
                    public string country { get; set; }
                    public string careof { get; set; }
                    public string attention { get; set; }
                }
                public class DeliveryAdress
                {
                    public string name { get; set; }
                    public string street_address { get; set; }
                    public string city { get; set; }
                    public string zipcode { get; set; }
                    public string country { get; set; }
                    public string careof { get; set; }
                }
            }
            public class InvoiceInfo
            {
                public string order_no { get; set; }
                public string order_date { get; set; }
                public string our_reference { get; set; }
                public string your_reference { get; set; }
                public string shipping_date { get; set; }
                public string delivery_date { get; set; }
                public string reference_number { get; set; }
                public string message { get; set; }
            }
            public class RegionalSweden
            {
                public double rotavdrag { get; set; }
                public string rotavdrag_personal_number { get; set; }
                public string rotavdrag_description { get; set; }
                public string rotavdrag_description_of_property { get; set; }
                public string rotavdrag_apartment_designation { get; set; }
                public string rotavdrag_housing_association_org_no { get; set; }
                public bool reversed_vat { get; set; }
                public string autogiro_betalarnummer { get; set; }
                public string autogiro_payment_date { get; set; }
                public string autogiro_status { get; set; }
                public string autogiro_full_status { get; set; }
                public double autogiro_total_sum { get; set; }
                public string efaktura_recipient_identifier { get; set; }
                public string efaktura_recipient_type { get; set; }
                public string efaktura_recipient_bank_name { get; set; }
                public short efaktura_recipient_bank_id { get; set; }
                public string efaktura_recipient_bank_code { get; set; }
                public short efaktura_recipient_id_number { get; set; }
                public short efaktura_requested_amount { get; set; }

                public EDI edi { get; set; }
                public class EDI
                {
                    public string electronic_id { get; set; }
                    public string subtype { get; set; }
                    public string reference { get; set; }
                    public string note { get; set; }
                }
            }
            public class Event
            {
                public string created_at { get; set; }
                public string event_uuid { get; set; }
                public string type { get; set; }
                public Data data { get; set; }
                public class Data
                {
                    public string invoice_no { get; set; }
                    public string delivery_method { get; set; }
                    public string original_delivery_method { get; set; }
                    public bool delivery_redirected { get; set; }
                    public string letter_id { get; set; }
                    public double amount { get; set; }
                    public string payer_name { get; set; }
                    public string[] payment_flags { get; set; }
                    public double banking_amount { get; set; }
                    public bool manual { get; set; }
                    public double reminder_fee { get; set; }
                    public short reminder_count { get; set; }
                    public double interest_rate { get; set; }
                    public string customer_email { get; set; }
                    public string customer_phone { get; set; }
                    public string ip { get; set; }
                    public string type { get; set; }
                    public string message { get; set; }
                    public string full_status { get; set; }
                    public string collector_method { get; set; }
                    public string collector_reference { get; set; }
                    public string factoring_method { get; set; }
                    public string factoring_reference { get; set; }

                    public double sells_for { get; set; }
                    public double sold_for { get; set; }
                    public string bankgiro { get; set; }
                    public string recipient_identifier { get; set; }
                    public string error_status { get; set; }
                    public double total_sum { get; set; }
                    public double remaining_sum { get; set; }
                    public bool scanning_central { get; set; }

                    public string offer_id { get; set; }
                    public string sale_type { get; set; }
                    public string accepted_at { get; set; }
                    public uint customer_no { get; set; }
                    public string item_title { get; set; }
                    public float item_price { get; set; }
                    public string item_type { get; set; }
                    public string date { get; set; }
                    public float payment_amount { get; set; }
                    public string payment_date { get; set; }
                    public string payment_update_reason { get; set; }
                    public string recurring_type { get; set; }
                    public string electronic_id { get; set; }
                    public string payment_type { get; set; }
                    public string payment_failure_reason { get; set; }


                }
            }
            public class ReminderSettings
            {
                public int delay_days { get; set; }
                public string message { get; set; }
            }
            public class Callback
            {
                public string url { get; set; }
                public string custom { get; set; }
                public string sign_key { get; set; }
            }
            public class AutomaticCollection
            {
                public int delay_days { get; set; }
                public int amount { get; set; }
                public bool use_default_settings { get; set; }
            }
            public class PDF
            {
                public string template { get; set; }
            }
            public class OnSuccess
            {
                public string command { get; set; }
                public string method { get; set; }
            }
            public class ItemData
            {
                public string item_no { get; set; }
                public string count { get; set; }
                public string title { get; set; }
                public string description { get; set; }
                public string unit { get; set; }
                public double price { get; set; }
                public short vat { get; set; }
                public string discount { get; set; }
                public BookKeeping bookkeeping { get; set; }
                public RegionalSweden regional_sweden { get; set; }
                public class RegionalSweden
                {
                    public bool rotavdrag { get; set; }
                    public ElectricityCollection electricity_collection;
                    public class ElectricityCollection
                    {
                        public short kommunkod { get; set; }
                        public bool naringsidkare { get; set; }
                        public bool avflyttad { get; set; }
                        public string avflyttad_datum { get; set; }
                        public bool frankopplad { get; set; }
                        public string frankopplad_datum { get; set; }
                        public string anladr { get; set; }
                        public string natom { get; set; }
                        public string arsforb { get; set; }
                        public string anlid { get; set; }
                        public string kravmall { get; set; }
                        public string plombkod { get; set; }
                        public bool slutfaktura { get; set; }
                        public string objtyp { get; set; }
                        public int faktorb { get; set; }
                        public int frankfrek { get; set; }
                        public string nyttighet { get; set; }
                    }
                }
                public class BookKeeping
                {
                    public string income_account { get; set; }
                    public string vat_account { get; set; }
                    public Objects[] objects { get; set; }
                    public class Objects
                    {
                        public int dimension_id { get; set; }
                        public string object_id { get; set; }
                        public string dimension_name { get; set; }
                        public string object_name { get; set; }
                    }
                }
            }
        }
    }

}
