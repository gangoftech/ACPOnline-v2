using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ACPOnline.Models
{
    public class Acp
    {
        [Display(Name= "Acp #")]
        public int ID { get; set; }

        [Display(Name = "Acp Type")]
        public int? TypeID { get; set; }

        [Display(Name = "Type")]
        public string Type { get; set; }

        [Display(Name = "Acp Category")]
        public int? CategoryId { get; set; }

        [Display(Name = "Category")]
        public string CategoryName { get; set; }

        [Display(Name = "Acp Name")]
        public string Name { get; set; }

        [Display(Name = "Proposed By")]
        public int? ProposedBy { get; set; }

        [Display(Name = "Proposed By")]
        public string ProposedByName { get; set; }

        [Display(Name = "Lead")]
        public int? Lead { get; set; }

        [Display(Name = "Lead")]
        public string LeadName { get; set; }

        [Display(Name = "Acp Description")]
        public string Description { get; set; }

        public DateTime? LeadAssnDate { get; set; }

        [Display(Name = "Impl Start Date")]
        public DateTime? ImplStartDate { get; set; }

        [Display(Name = "Impl End Date")]
        public DateTime? ImplEndDate { get; set; }

        [Display(Name = "Pl. Impl Start Date")]
        public DateTime? PlImplStartDate { get; set; }

        [Display(Name = "Pl. Impl End Date")]
        public DateTime? PlImplEndDate { get; set; }

        [Display(Name = "Launch Date")]
        public DateTime? LaunchDate { get; set; }

        [Display(Name = "Pl. Launch Date")]
        public DateTime? PlLaunchDate { get; set; }

        [Display(Name = "Status")]
        public int? StatusId { get; set; }

        [Display(Name = "Status")]
        public string StatusName { get; set; }

        public bool? IsDeleted { get; set; }

        [Display(Name = "Created Date")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Created By")]
        public int? CreatedBy { get; set; }

        [Display(Name = "Created By")]
        public string CreatedByName { get; set; }

        [Display(Name = "Updated Date")]
        public DateTime? UpdatedDate { get; set; }

        [Display(Name = "Updated By")]
        public int? UpdatedBy { get; set; }

        [Display(Name = "Updated By")]
        public string UpdatedByName { get; set; }
    }
}
