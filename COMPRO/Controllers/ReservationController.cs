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

namespace COMPRO.Controllers
{
    public class ReservationController : Controller
    {
        GsportDBDataContext dc = null;
        Harga[] harga = null;
        // GET: Reservation
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
                ViewData["RsvSchedule"] = "SCH00001";
                Session["RsvSchedule"] = "SCH00001";
            }

            Harga[] harga = null;
            harga = ShowPrice("27/02/2019", Session["RsvSchedule"].ToString());
            return View(harga);
        }

        
        private Harga[] ShowPrice(string RsvDate, string RsvSchedule)
        {

            dc = new GsportDBDataContext();
            List<Harga> mharga = new List<Harga>();

            dc = new GsportDBDataContext();
            try
            {
                var query = dc.Price_View("P", "27/02/2019", RsvSchedule);
                foreach (var res in query)
                {
                    Harga harga = new Harga();
                    harga.KodeHari = res.KodeHari;
                    harga.Schedule = res.Schedule;
                    harga.Price = res.Price.ToString();

                    mharga.Add(harga);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return mharga.ToArray();
        }
    }
}