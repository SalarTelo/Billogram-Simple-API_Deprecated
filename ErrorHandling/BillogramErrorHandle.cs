using System;
using System.Collections.Generic;
using System.Text;

namespace Billogram.ErrorHandling
{
    public static class ErrorHandle
    {
        public static bool Validate<T>(T data) where T : class, Structures.IStructure
        {
            
            if (typeof(T) == typeof(Structures.Customer.List))
            {
                Structures.Customer.List customerData = (Structures.Customer.List)(object)data;
                return true;
            }
            else if (typeof(T) == typeof(Structures.Invoice.List))
            {
                Structures.Invoice.List invoiceData = (Structures.Invoice.List)(object)data;
                return true;

            }
            else if (typeof(T) == typeof(Structures.Item.List))
            {
                Structures.Item.List itemData = (Structures.Item.List)(object)data;
                return true;

            }
            else
                return false;
        }
    }
}
