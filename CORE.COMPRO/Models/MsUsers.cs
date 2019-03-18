using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.COMPRO.Models
{
    public class MsUsers
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public bool isActive { get; set; }
        public string Module { get; set; }
        public string IBy { get; set; }
        public DateTime? IOn { get; set; }
        public string UBy { get; set; }
        public DateTime? UOn { get; set; }
    }
}
