using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSAFE.Models.Entity
{
    public class Planning
    {
        public int Planning_ID { get; set; }

        public string Planning_Value { get; set; }

        public bool Planning_IsChecked { get; set; }
    }
}