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

        public int? TypeID { get; set; }

        public int? CategoryId { get; set; }

        [Display(Name = "Acp Name")]
        public string Name { get; set; }

        public int? ProposedBy { get; set; }

        public int? Lead { get; set; }

        [Display(Name = "Acp Description")]
        public string Description { get; set; }

        public DateTime? LeadAssnDate { get; set; }

        [Display(Name = "Impl Start Date")]
        public DateTime? ImplStartDate { get; set; }

        [Display(Name = "Impl End Date")]
        public DateTime? ImplEndDate { get; set; }

        [Display(Name = "Pl. Impl End Date")]
        public DateTime? PlImplEndDate { get; set; }

        [Display(Name = "Launch Date")]
        public DateTime? LaunchDate { get; set; }

        [Display(Name = "Pl. Launch Date")]
        public DateTime? PlLaunchEndDate { get; set; }

        public int? StatusId { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? UpdatedBy { get; set; }
    }
}
