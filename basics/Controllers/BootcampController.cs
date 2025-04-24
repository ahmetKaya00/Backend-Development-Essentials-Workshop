using basics.Models;
using Microsoft.AspNetCore.Mvc;

namespace basics.Controllers{

    public class BootcampController : Controller{

        public IActionResult Index(){
            var bootcamp = new Bootcamp();
            bootcamp.Id = 1;
            bootcamp.Title = "Backend Bootcamp";
            bootcamp.Description = "Eğitimimiz 24 Nisan'da başladı.";
            bootcamp.Image = "1.png";
            return View(bootcamp);
        }
        public IActionResult List(){
            var bootcamps = new List<Bootcamp>(){
                new Bootcamp(){Id = 1, Title= "Backend Bootcamp",Description="Güzel başladı",Image="1.png"},
                new Bootcamp(){Id = 2, Title= "Game Bootcamp",Description="Güzel başladı",Image="2.png"},
                new Bootcamp(){Id = 3, Title= "React Bootcamp",Description="Güzel başladı",Image="3.jpg"},
            };
            return View(bootcamps);
        }
    }
}