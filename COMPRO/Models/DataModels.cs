using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COMPRO.Models
{
    public class DataModels
    {
        public List<MsJadwal> ListMsJadwal { get; set; }
        public List<Harga> ListHarga { get; set; }
    }

    public class Harga
    {
        public string KodeHari { get; set; }
        public string Schedule { get; set; }
        public string Price { get; set; }
    }

    public class MsJadwal
    {
        public string KodeSchedule { get; set; }
        public string JamMulai { get; set; }
        public string JamSelesai { get; set; }
        public string MulaiBerlaku { get; set; }
        public string Keterangan { get; set; }
    }
    public class BookingCalendar
    {
        public string title { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public string backgroundColor { get; set; }
    }
    public class IUD_Status
    {
        public string Status { get; set; }
    }

}