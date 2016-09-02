using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACPOnline.Models
{
    public class CategoryInfo
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public int TypeID { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? UpdatedBy { get; set; }

    }
}
