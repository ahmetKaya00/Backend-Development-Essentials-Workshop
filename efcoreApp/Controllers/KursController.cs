using efcoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace efcoreApp.Controllers{

    public class KursController : Controller{
        private readonly DataContext _context;

        public KursController(DataContext context){
            _context = context;
        }

        public async Task<IActionResult>Index(){
            return View(await _context.Kurslar.ToListAsync());
        }

        public IActionResult Create(){
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>Create(Kurs model){
            _context.Kurslar.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int? id){
            if(id == null){
                return NotFound();
            }
            var ogr = await _context.Kurslar.Include(k=>k.KursKayitlari).ThenInclude(o=>o.Ogrenci).FirstOrDefaultAsync(o=>o.KursId == id);
            if(ogr == null){
                return NotFound();
            }
            return View(ogr);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Edit(int id, Kurs model){
            if(id != model.KursId){
                return NotFound();
            }
            if(ModelState.IsValid){
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                   if(!_context.Kurslar.Any(o=>o.KursId == model.KursId)){
                    return NotFound();
                   }
                   else{
                    throw;
                   }
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult>Delete(int? id){
            if(id == null){
                return NotFound();
            }
            var Kurs = await _context.Kurslar.FindAsync(id);

            if(Kurs == null){
                return NotFound();
            }
            return View(Kurs);
        }

        [HttpPost]
        public async Task<IActionResult>Delete([FromForm]int id){
            var Kurs = await _context.Kurslar.FindAsync(id);

            if(Kurs == null){
                return NotFound();
            } 
            _context.Kurslar.Remove(Kurs);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}