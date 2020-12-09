using System;
using System.Collections.Generic;
using System.Text;

namespace Billogram.Structures
{
    public class BillogramDate
    {
        private int m_day { get; set; }
        private int m_month { get; set; }
        private int m_year { get; set; }
        public string Parse()
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
