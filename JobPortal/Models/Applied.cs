using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JobPortal.Models
{
    public class Applied
    {
        [Key]
        public int Id { get; set; }
        public int JobId { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> AppliedOn { get; set; }

        public string RecruiterId { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        [ForeignKey("JobId")]
        public virtual jobs Jobs { get; set; }
    }
}