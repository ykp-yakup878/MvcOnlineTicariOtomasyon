using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class CariController : Controller
    {
        // GET: Cari
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Carilers.Where(x => x.Durum == true).ToList();
            return View(degerler);
        }
        [Authorize(Roles = "A")]
        [HttpGet]
        public ActionResult YeniCari()
        {
            return View();
        }
        [Authorize(Roles = "A")]
        [HttpPost]
        public ActionResult YeniCari(Cariler p)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniCari");
            }
            p.Durum = true;
            c.Carilers.Add(p);
            c.SaveChanges();
            return RedirectToAction("index");
        }
        [Authorize(Roles = "A")]
        public ActionResult CariSil(int id)
        {
            var cari = c.Carilers.Find(id);
            cari.Durum = false;
            c.SaveChanges();
            return RedirectToAction("index");
        }
        [Authorize(Roles = "A")]
        public ActionResult CariGetir(int id)
        {
            var cari = c.Carilers.Find(id);
            return View("CariGetir", cari);
        }
        [Authorize(Roles = "A")]
        public ActionResult CariGuncelle(Cariler p)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            var cari = c.Carilers.Find(p.CariID);
            cari.CariAd = p.CariAd;
            cari.CariSoyad = p.CariSoyad;
            cari.CariSehir = p.CariSehir;
            cari.CariMail = p.CariMail;
            c.SaveChanges();
            return RedirectToAction("index");
        }
        [Authorize(Roles = "A")]
        public ActionResult MusteriSatis(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.Cariid == id).ToList();
            var dpt = c.Carilers.Where(x => x.CariID == id).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.cr = dpt;
            return View(degerler);
        }
    }
}