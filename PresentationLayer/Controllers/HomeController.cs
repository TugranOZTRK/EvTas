using Business.Manager;
using DataAccessLayer.Concrete.EfRepository;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PresentationLayer.Models;

namespace PresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        AraclarManager _araclarManager = new AraclarManager(new EfAracRepository());

        public IActionResult Araclar()
        {
            var values = _araclarManager.GetList();
            var aktifAraclar = values.Where(a => a.Aktif).ToList();
            var model = new AraclarViewModel()
            {
                Araclar = aktifAraclar
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult AracEkle(Araclar araclar)
        {
            araclar.Aktif = true;
            _araclarManager.Add(araclar);
            var values = JsonConvert.SerializeObject(araclar);
            return Json(values);
        }


        [HttpPost]
        public ActionResult AracDuzenle([FromBody] Araclar araclar)
        {
            var arac = _araclarManager.GetById(araclar.AracId);
            arac.Plaka = araclar.Plaka;
            arac.Marka = araclar.Marka;
            arac.Model = araclar.Model;
            arac.Aktif = true;
            _araclarManager.Update(arac);
            return RedirectToAction("Araclar", "Home");
        }

        [HttpPost]
        public ActionResult AracSil(int aracId)
        {
            var arac = _araclarManager.GetById(aracId);
            arac.Aktif = false;
            _araclarManager.Update(arac);
            return RedirectToAction("Araclar", "Home");
        }
    }
}