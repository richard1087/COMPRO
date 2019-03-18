using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.COMPRO.Models
{
    public class MsPrice
    {
        public string KodePrice { get; set; }
        public string KodeHari { get; set; }
        public string KodeSchedule { get; set; }
        public decimal Price { get; set; }
        public DateTime? MulaiBerlaku { get; set; }
        public string IBy { get; set; }
        public DateTime? IOn { get; set; }
        public string UBy { get; set; }
        public DateTime? UOn { get; set; }
    }
}
