using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Personels.ToList();
            return View(degerler);
        }
        [Authorize(Roles = "A")]
        [HttpGet]
        public ActionResult YeniPersonel()
        {
            List<SelectListItem> deger1 = (from x in c.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.DepartmanID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [Authorize(Roles = "A")]
        [HttpPost]
        public ActionResult YeniPersonel(Personel p)
        {
            if (Request.Files.Count > 0)
            {
                string dosya = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "/Image/" + dosya + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersoneGorsel = "/Image/" + dosya + uzanti;
            }
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("index");
        }
        [Authorize(Roles = "A")]
        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.DepartmanID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var prs = c.Personels.Find(id);
            return View("PersonelGetir", prs);
        }
        [Authorize(Roles = "A")]
        public ActionResult PersonelGuncelle(Personel p)
        {
            if (Request.Files.Count > 0)
            {
                string dosya = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "/Image/" + dosya + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersoneGorsel = "/Image/" + dosya + uzanti;
            }
            var prsn = c.Personels.Find(p.PersonelID);
            prsn.PersoneAd = p.PersoneAd;
            prsn.PersoneSoyad = p.PersoneSoyad;
            prsn.PersoneGorsel = p.PersoneGorsel;
            prsn.Departmanid = p.Departmanid;
            c.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult PersonelListe()
        {
            var list = c.Personels.ToList();
            return View(list);
        }
    }
}