namespace Billogram.Structures
{
    public class Settings
    {
        public Data data { get; set; }
        public class Data
        {
            public string name { get; set; }
            public string org_no { get; set; }
            public string registration_email { get; set; }
            public Contact contact { get; set; }
            public Address address { get; set; }
            public InvoiceAddress invoice_address { get; set; }
            public RegisteredOfficeAddress registered_office_address { get; set; }
            public ReturnAddress return_address { get; set; }
            public VisitingAddress visiting_address { get; set; }
            public Payment payment { get; set; }
            public Tax tax { get; set; }
            public BookKeeping bookkeeping { get; set; }
            public Invoices invoices { get; set; }
            public class Contact
            {
                public string name { get; set; }
                public string email { get; set; }
                public string phone { get; set; }
                public string www { get; set; }

            }
            public class Address
            {
                public string street_address { get; set; }
                public string careof { get; set; }
                public string zipcode { get; set; }
                public string city { get; set; }
                public string country { get; set; }
            }
            public class InvoiceAddress
            {
                public string street_address { get; set; }
                public string careof { get; set; }
                public string zipcode { get; set; }
                public string city { get; set; }
                public string country { get; set; }
                public string email { get; set; }
            }
            public class RegisteredOfficeAddress
            {
                public string name { get; set; }
                public string street_address { get; set; }
                public string careof { get; set; }
                public string zipcode { get; set; }
                public string city { get; set; }
                public string country { get; set; }
            }
            public class ReturnAddress
            {
                public string name { get; set; }
                public string street_address { get; set; }
                public string careof { get; set; }
                public string zipcode { get; set; }
                public string city { get; set; }
            }
            public class VisitingAddress
            {
                public string street_address { get; set; }
                public string careof { get; set; }
                public string zipcode { get; set; }
                public string city { get; set; }
                public string country { get; set; }
            }
            public class Payment
            {
                public string bankgiro { get; set; }
                public string plusgiro { get; set; }

                public BankAccount domestic_bank_account { get; set; }
                public InternationalBankAccount international_bank_account { get; set; }

                public class BankAccount
                {
                    public string account_no { get; set; }
                    public string clearing_no { get; set; }
                }
                public class InternationalBankAccount
                {
                    public string bank { get; set; }
                    public string iban { get; set; }
                    public string bic { get; set; }
                    public string swift { get; set; }
                }
            }
            public class Tax
            {
                public bool is_vat_registered { get; set; }
                public bool has_fskatt { get; set; }
                public string vat_no { get; set; }
            }
            public class BookKeeping
            {
                public string income_account_for_vat_25 { get; set; }
                public string income_account_for_vat_12 { get; set; }
                public string income_account_for_vat_6 { get; set; }
                public string income_account_for_vat_0 { get; set; }
                public string reversed_vat_account { get; set; }
                public string vat_account_for_vat_25 { get; set; }
                public string vat_account_for_vat_12 { get; set; }
                public string vat_account_for_vat_6 { get; set; }
                public string sie_serie { get; set; }
                public string sie_continuous_numbering { get; set; }
                public string financial_year_start { get; set; }
                public int financial_year_months { get; set; }
                public string account_receivable_account { get; set; }
                public string client_funds_account { get; set; }
                public string banking_account { get; set; }
                public string interest_fee_account { get; set; }
                public string reminder_fee_account { get; set; }
                public string rounding_account { get; set; }
                public string factoring_receivable_account { get; set; }
                public string non_allocated_account { get; set; }
                public string income_payout_account { get; set; }
                public string written_down_receivables_account { get; set; }
                public string expected_loss_account { get; set; }
                public string debt_collection_funds_account { get; set; }
                public string liabilities_customers_account { get; set; }
                public RegionalSweden regional_sweden { get; set; }
                public class RegionalSweden
                {
                    public string rotavdrag_account { get; set; }
                }

            }
            public class Invoices
            {
                public string default_message { get; set; }
                public double default_interest_rate { get; set; }
                public double default_reminder_fee { get; set; }
                public double default_invoice_fee { get; set; }
                public AutomaticReminders[] automatic_reminders { get; set; }
                public double automatic_reminders_minimum_principal_sum { get; set; }
                public AutomaticWriteOff automatic_writeoff { get; set; }
                public AutomaticCollection automatic_collection { get; set; }
                public bool show_item_gross_prices { get; set; }
                public bool show_new_account_notice { get; set; }
                public bool use_automatic_reminders_partly_paid { get; set; }
                public PDF pdf { get; set; }
                public class AutomaticReminders
                {
                    public int delay_days { get; set; }
                    public string message { get; set; }
                }
                public class AutomaticWriteOff
                {
                    public string settings { get; set; }
                    public int? amount { get; set; }
                }
                public class AutomaticCollection
                {
                    public int delay_days { get; set; }
                    public int amount { get; set; }
                }
                public class PDF
                {
                    public string template { get; set; }
                }
            }
        }
    }
}
