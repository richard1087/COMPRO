using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.COMPRO.Models
{
    public class MsSchedule
    {
        public string KodeSchedule { get; set; }
        public DateTime? JamMulai { get; set; }
        public DateTime? JamSelesai { get; set; }
        public DateTime? MulaiBerlaku { get; set; }
        public string IBy { get; set; }
        public DateTime? IOn { get; set; }
        public string UBy { get; set; }
        public DateTime? UOn { get; set; }
    }
}
