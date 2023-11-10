using Business.Manager;
using DataAccessLayer.Concrete.EfRepository;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PresentationLayer.Controllers
{
    public class RaporlarController:Controller
    {
        KasaManager _kasaManager = new KasaManager(new EfKasaRepository());
        [HttpGet]
        public IActionResult Kasa()
        {
            var dokumler = _kasaManager.GetList();
            return View(dokumler);
        }
        public IActionResult GelirEkle(Kasa dokum)
        {
            dokum.Tur = "Gelir";
            dokum.Düzenli = false;
            _kasaManager.Add(dokum);
            var values = JsonConvert.SerializeObject(dokum);
            return Json(values);
        }

        public IActionResult GiderEkle(Kasa dokum)
        {
            dokum.Tur = "Gider";
            dokum.Düzenli = false;
            _kasaManager.Add(dokum);
            var values = JsonConvert.SerializeObject(dokum);
            return Json(values);
        }
    }
}
