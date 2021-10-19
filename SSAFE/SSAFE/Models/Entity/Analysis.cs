using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSAFE.Models.Entity
{
    public class Analysis
    {
        public int Analysis_ID { get; set; }

        public string Analysis_Value { get; set; }

        public bool Analysis_IsChecked { get; set; }
    }
}