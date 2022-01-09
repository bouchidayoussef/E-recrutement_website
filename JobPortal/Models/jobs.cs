using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JobPortal.Models
{
    public class jobs
    {
        [Key]
        public int JobId { get; set; }
        public string Title { get; set; }
        
        public string Skills { get; set; }
        public string RequiredDescription { get; set; }
        public string RequiredResponsibilities { get; set; }
        public string RequiredQualification { get; set; }
        public string RequiredExperience { get; set; }
        public Nullable<int> HrsPerWeek { get; set; }
        public string Salary { get; set; }
        public Nullable<int> MinExpInYr { get; set; }
        public string Location { get; set; }
        public Nullable<int> NoOfOpening { get; set; }
        
        public string Status { get; set; }
        public string UserId { get; set; }
    }
}