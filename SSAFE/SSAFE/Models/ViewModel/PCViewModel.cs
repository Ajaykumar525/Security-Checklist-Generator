using SSAFE.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSAFE.Models.ViewModel
{
    public class PCViewModel
    {
        public List<Analysis> Analysisvm { get; set; }
        public List<Deployment> Deploymentvm { get; set; }
        public List<Design> Designvm { get; set; }
        public List<Development> Developmentvm { get; set; }
        public List<Planning> Planningvm { get; set; }
        public List<Testing_Integration> Testing_Integrationvm { get; set; }
        public Guid userId { get; set; }
        public Guid Project_ID { get; set; }
        public string Project_Name { get; set; }
        public string Project_Description { get; set; }
        public bool Project_IsActive { get; set; }
    }
    
}