using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapi.Models
{
    public class Expenses
    {
        public string cdate { get; set; }

        public int cyear { get; set; }

        public int cmonth { get; set; }

        public int expensecodeid { get; set; }

        public string comments { get; set; }

        public float Value { get; set; }

        public int deleted { get; set; }

        public string guid { get; set; }

    }
}