using basics.Models;
using Microsoft.AspNetCore.Mvc;

namespace basics.Controllers{

    public class BootcampController : Controller{

        public IActionResult Index(){
            
            return View(Repository.Bootcamps.ToList());
        }
        public IActionResult Details(int? id){
            if(id==null){
             //   return Redirect("/bootcamp/list");
                return RedirectToAction("List","Bootcamp");
            }
           var bootcamp = Repository.GetById(id);

           return View(bootcamp);
        }
        public IActionResult List(){
            return View(Repository.Bootcamps.ToList());
        }
    }
}