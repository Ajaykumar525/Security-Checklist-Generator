using SSAFE.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSAFE.Models.Entity
{
    public class Project
    {
        public Guid Project_ID { get; set; }

        public string Project_Name { get; set; }

        public string Project_Description { get; set; }

        public bool Porject_IsActive { get; set; }

        public bool Project_IsEdit { get; set; }        
    }
}