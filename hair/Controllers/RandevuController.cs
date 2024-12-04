using hair.Models;
using Hairdresser.Models;
using Microsoft.AspNetCore.Mvc;

namespace hair.Controllers
{
    public class RandevuController : Controller
    {
        Context c = new Context();


        public IActionResult Index()
        {
            // Islem tablosundan verileri alıyoruz.
            var degerler = c.Islems.ToList(); // Veritabanındaki tüm işlemleri al

            // İşlem listesini View'a gönderiyoruz.
            return View(degerler);
        }



        public IActionResult RandevuAl(int id)
        {
            // İşlem ve Personel Listelerini ViewBag ile gönder
            ViewBag.Islemler = c.Islems.ToList();
            ViewBag.Personeller = c.Personels.ToList();

            // İlgili işlem bilgilerini almak için
            var islem = c.Islems.FirstOrDefault(x => x.ID == id);

            if (islem == null)
            {
                return NotFound(); // Eğer işlem bulunamazsa, 404 döndür.
            }

            // Yeni randevu modelini başlat
            var randevu = new Randevu
            {
                IslemId = id,
                Islem = islem
            };

            return View(randevu); // Randevu oluşturma formunu göster
        }

        // Randevu oluşturma işlemi (POST)
        [HttpPost]
        public IActionResult YeniRandevu(Randevu r)
        {
            if (ModelState.IsValid)
            {
                // Yeni randevuyu veritabanına kaydet
                c.Randevus.Add(r);
                c.SaveChanges();

                // Kullanıcıyı randevularının listelendiği sayfaya yönlendir
                return RedirectToAction("RandevuIndex");
            }

            // Formda hata varsa, islemler ve personelleri yeniden gönder
            ViewBag.Islemler = c.Islems.ToList();
            ViewBag.Personeller = c.Personels.ToList();
            return View(r); // Formu tekrar göster
        }

        // Kullanıcının tüm randevularını listele
        public IActionResult RandevuIndex()
        {
            // Randevuları al ve listele
            var randevular = c.Randevus.ToList();
            return View(randevular);
        }

        // Randevuyu silme işlemi
        public IActionResult RandevuSil(int id)
        {
            var randevu = c.Randevus.FirstOrDefault(x => x.RandevuId == id);
            if (randevu != null)
            {
                c.Randevus.Remove(randevu);
                c.SaveChanges();
            }
            return RedirectToAction("RandevuIndex");
        }


    }
    }
