using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACPOnline.Models
{
    public class AuthResult
    {
        public bool IsSuccess { get; set; }
        public bool IsWrongPassword { get; set; }
    }
}
