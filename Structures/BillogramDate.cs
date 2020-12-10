using System;
using System.Collections.Generic;
using System.Text;

namespace Billogram.Structures
{
    /// <summary>
    /// Object to parse the correct format for the date being sent to server.
    /// </summary>
    public class BillogramDate
    {
        private int m_day { get; set; }
        private int m_month { get; set; }
        private int m_year { get; set; }
        /// <summary>
        /// Format the data into the correct structure when sending to the server.
        /// </summary>
        /// <returns>YYYY-MM-DD</returns>
        public string Format()
        {
            return $"{m_year}-{m_month}-{m_day}";
        }
        public BillogramDate(int year, int month, int day)
        {
            m_year = year;
            m_month = month;
            m_day = day;
        }
    }
}
