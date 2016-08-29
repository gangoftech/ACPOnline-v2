using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACPOnline.Models
{
    public class Info
    {
        public int ID { get; set; }

        public int? TypeID { get; set; }

        public int? CategoryId { get; set; }

        public string Name { get; set; }

        public int? ProposedBy { get; set; }

        public int? Lead { get; set; }

        public string Description { get; set; }

        public DateTime? LeadAssnDate { get; set; }

        public DateTime? ImplStartDate { get; set; }

        public DateTime? ImplEndDate { get; set; }

        public DateTime? PlImplEndDate { get; set; }

        public DateTime? LaunchDate { get; set; }

        public DateTime? PlLaunchEndDate { get; set; }

        public int? StatusId { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? UpdatedBy { get; set; }
    }
}
