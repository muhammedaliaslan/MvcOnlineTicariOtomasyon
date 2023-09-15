using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        Context c = new Context();
        public ActionResult Faturalar()
        {
            var liste = c.Faturalars.ToList();
            return View(liste);
        }
        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Faturalar f)
        {
            c.Faturalars.Add(f);
            c.SaveChanges();

            return RedirectToAction("Faturalar");
        }
        public ActionResult FaturaGetir(int id)
        {
            var fatura = c.Faturalars.Find(id);
            return View("FaturaGetir", fatura);
        }
        public ActionResult FaturaGuncelle(Faturalar f)
        {
            var fatura = c.Faturalars.Find(f.FaturaID);
            fatura.FaturaSeriNo = f.FaturaSeriNo;
            fatura.FaturaSıraNo = f.FaturaSıraNo;
            fatura.saat = f.saat;
            fatura.FaturaTarih = f.FaturaTarih;
            fatura.TeslimAlan = f.TeslimAlan;
            fatura.TeslimEden = f.TeslimEden;
            fatura.VergiDairesi = f.VergiDairesi;
            c.SaveChanges();

            return RedirectToAction("Faturalar");
        }
        public ActionResult FaturaDetay(int id)
        {
            var degerler = c.FaturKalems.Where(x => x.Faturaid == id).ToList();

            var fat = c.Faturalars.Where(x => x.FaturaID == id).Select(y => y.FaturaSeriNo).FirstOrDefault();
            ViewBag.f = fat;

            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }
        public ActionResult YeniKalem(FaturKalem p)
        {
            c.FaturKalems.Add(p);
            c.SaveChanges();

            return RedirectToAction("Faturalar");
        }
    }
}