using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACPOnline.Models
{
    public class AcpViewModel
    {
        public Acp Acp { get; set; }

        public IList<Acp> AcpList { get; set; }

        public IEnumerable<TypeInfo> AcpTypeOptions =
        new List<TypeInfo>
        {
            new TypeInfo { TypeID = 1, Type = "RFP"},
            new TypeInfo { TypeID = 2, Type = "Portfolio Based Arch Group (PBAG)" },
            new TypeInfo { TypeID = 3, Type = "Enterprise Architecture" },
            new TypeInfo { TypeID = 4, Type = "Governance" }
        };

        public IEnumerable<CategoryInfo> AcpCategoryOptions =
        new List<CategoryInfo>
        {
            new CategoryInfo { CategoryId = 1, TypeID = 1, CategoryName = "Solutioning" },
            new CategoryInfo { CategoryId = 2, TypeID = 1, CategoryName = "Solution Review" },
            new CategoryInfo { CategoryId = 3, TypeID = 2, CategoryName = "Mentoring and Trainings" },
            new CategoryInfo { CategoryId = 4, TypeID = 2, CategoryName = "Application Architecture and design" },
            new CategoryInfo { CategoryId = 5, TypeID = 3, CategoryName = "Repositories" },
            new CategoryInfo { CategoryId = 6, TypeID = 3, CategoryName = "NextGen and POCs" },
            new CategoryInfo { CategoryId = 7, TypeID = 4, CategoryName = "Planning and maintenance" },
            new CategoryInfo { CategoryId = 8, TypeID = 4, CategoryName = "Evangelization and adoption" },
            new CategoryInfo { CategoryId = 9, TypeID = 4, CategoryName = "Team Building and sustenance" },
            new CategoryInfo { CategoryId = 10, TypeID = 4, CategoryName = "Status tracking and Reporting" },
        };

        public IEnumerable<Status> AcpStatusOptions =
        new List<Status>
        {
            new Status { StatusId = 1, StatusName = "Active"},
            new Status { StatusId = 2, StatusName = "Closed"}
        };

        public IEnumerable<User> ProposedByOptions =
        new List<User>
        {
            new User { UserId = 359951, UserName = "Sakthi"},
            new User { UserId = 446086, UserName = "Sandeep"}
        };

        public IEnumerable<User> AcpLeadOptions =
        new List<User>
        {
            new User { UserId = 359951, UserName = "Sakthi"},
            new User { UserId = 446086, UserName = "Sandeep"}
        };

    }
}
