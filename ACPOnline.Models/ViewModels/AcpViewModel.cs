using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACPOnline.Models
{
    public class AcpViewModel
    {
        public Acp Acp { get; set;  }

        public IEnumerable<TypeInfo> AcpTypeOptions =
        new List<TypeInfo>
        {
            new TypeInfo { TypeID = 0, Type = "Payroll Deduction"},
            new TypeInfo { TypeID = 1, Type = "Bill Me"}
        };

        public IEnumerable<CategoryInfo> AcpCategoryOptions =
        new List<CategoryInfo>
        {
            new CategoryInfo { CategoryId = 0, CategoryName = "Payroll Deduction"},
            new CategoryInfo { CategoryId = 1, CategoryName = "Bill Me"}
        };

        public IEnumerable<Status> AcpStatusOptions =
        new List<Status>
        {
            new Status { StatusId = 0, StatusName = "Payroll Deduction"},
            new Status { StatusId = 1, StatusName = "Bill Me"}
        };

        public IEnumerable<User> ProposedByOptions =
        new List<User>
        {
            new User { UserId = 0, UserName = "Payroll Deduction"},
            new User { UserId = 1, UserName = "Bill Me"}
        };

        public IEnumerable<User> AcpLeadOptions =
        new List<User>
        {
            new User { UserId = 0, UserName = "Payroll Deduction"},
            new User { UserId = 1, UserName = "Bill Me"}
        };

    }
}
