using Microsoft.AspNetCore.Mvc;
using Hairdresser.Models;
using hair.Models;


namespace hair.Controllers { 

     public class ManController : Controller
{
    Context c = new Context();
    public IActionResult Index()
    {
        var degerler = c.Islems.ToList();

        return View(degerler);
    }


    public IActionResult PersonelDetay(int id)
    {
        var degerler = c.Personels.Where(x => x.IslemId == id).ToList();


        var brmad = c.Islems.Where(x => x.ID == id).Select(y => y.IslemAdi).FirstOrDefault();

        ViewBag.brm = brmad;
        return View(degerler);
    }



     




    }
}