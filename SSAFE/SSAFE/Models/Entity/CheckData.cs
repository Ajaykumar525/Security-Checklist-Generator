using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SSAFE.Models.Entity
{
    public class CheckData
    {
        [Display(Name = "Id")]
        public Guid User_ID { get; set; }
        public Guid Checklist_ID { get; set; }
        public string Checklist_Name { get; set; }
        public string[] Checks_list { get; set; }
    }
}