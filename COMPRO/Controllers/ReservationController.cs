using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Drawing;
using System.Web.Helpers;
using System.Globalization;
using System.Web.Configuration;
using COMPRO.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace COMPRO.Controllers
{
    public class ReservationController : Controller
    {
        GsportDBDataContext dc = null;
        // GET: Reservation
        DataModels listdata = new DataModels();

        List<Harga> msharga;
        List<MsJadwal> msjadwal;

        public void ListJadwal()
        {
            dc = new GsportDBDataContext();
            msjadwal = new List<MsJadwal>();
            try
            {
                var query = dc.MsJadwal_View("1");
                foreach (var res in query)
                {
                    MsJadwal mjadwal= new MsJadwal();

                    mjadwal.KodeSchedule = res.KodeSchedule;
                    mjadwal.Keterangan= res.Keterangan;

                    msjadwal.Add(mjadwal);
                }
            }
            catch
            {
                msjadwal = null;
            }
        }
        [HttpPost]
        public ActionResult ShowPrice(string RsvDate, string RsvSchedule)
        {
            dc = new GsportDBDataContext();
            msharga = new List<Harga>();
            string price = "";
            try
            {
                var query = dc.Price_View("P", RsvDate, RsvSchedule);
                foreach (var res in query)
                {
                    Harga harga = new Harga();
                    harga.KodeHari = res.KodeHari;
                    harga.Schedule = res.Schedule;
                    harga.Price = res.Price.ToString();
                    Session["Harga"] = res.Price.ToString();
                    price = res.Price.ToString();
                    msharga.Add(harga);
                }
            }
            catch(Exception ex)
            {
                msharga= null;
            }
            return Json(new {success = true, Price = price }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetBookingSchedule(DateTime? startdate, DateTime? enddate, string tipe)
        {
            dc = new GsportDBDataContext();
            var fromDate = Convert.ToDateTime(startdate);
            var toDate = Convert.ToDateTime(enddate);
            string s = fromDate.ToString("yyyy-MM-dd");
            string e = toDate.ToString("yyyy-MM-dd");
            List<BookingCalendar> book = new List<BookingCalendar>();
            try
            {
                var query = dc.TrxBookingCalendar(s, e, tipe);
                foreach (var res in query)
                {
                    BookingCalendar books = new BookingCalendar();
                    books.title = res.NamaTeam;
                    books.Start = res.StartDate;
                    books.End = res.EndDate;
                    if (res.Status == "APP")
                        books.backgroundColor = "#ff0000";
                    else
                        books.backgroundColor = "#0000ff";
                    book.Add(books);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);
            }
            var Output = JsonConvert.SerializeObject(book);
            return Json(Output, JsonRequestBehavior.AllowGet);
        }
        private static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }
        public ActionResult Index()
        {
            if (TempData["RsvSchedule"] != null)
            {
                if (TempData["RsvSchedule"].ToString() == "")
                {
                    ViewData["RsvSchedule"] = TempData["RsvSchedule"];
                    Session["RsvSchedule"] = TempData["RsvSchedule"].ToString();
                    
                }
            }
            else
            {
                ViewData["RsvSchedule"] = "XXX";
                Session["RsvSchedule"] = "XXX";
                
            }

            if (TempData["RsvDate"] != null)
            {
                if (TempData["RsvDate"].ToString() == "")
                {
                    ViewData["RsvDate"] = TempData["RsvDate"];
                    Session["RsvDate"] = TempData["RsvDate"].ToString();

                }
            }
            else
            {
                ViewData["RsvDate"] = DateTime.Now.ToString("dd/MM/yyyy");
                Session["RsvDate"] = DateTime.Now.ToString("dd/MM/yyyy");
            }

            if (TempData["Harga"] != null)
            {
                if (TempData["Harga"].ToString() == "")
                {
                    ViewData["Harga"] = TempData["Harga"];
                    Session["Harga"] = TempData["Harga"].ToString();
                }
            }
            else
            {
                ViewData["Harga"] = "0";
                Session["Harga"] = "0";

            }
            
            //ShowPrice(Session["RsvDate"].ToString(), Session["RsvSchedule"].ToString());
            ListJadwal();
            listdata.ListMsJadwal = msjadwal.ToList();
            return View("Index", listdata);
        }

        [HttpPost]
        public ActionResult Reservasi(string RsvDate, string RsvSchedule)
        {
            ViewData["RsvDate"] = RsvDate;
            ViewData["RsvSchedule"] = RsvSchedule;
            
            //ShowPrice(ViewData["RsvDate"].ToString(), ViewData["RsvSchedule"].ToString());
            ListJadwal();
            listdata.ListMsJadwal = msjadwal.ToList();
            return View("Index", listdata);
        }
        [HttpPost]
        public ActionResult SaveBook(string date, string team, string slot, string nama, string harga, string alamat, string email, string notlp, string ket)
        {

        }
    }
}