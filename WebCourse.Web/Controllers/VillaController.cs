using Microsoft.AspNetCore.Mvc;
using WebCourse.Domain.Entities;
using WebCourse.Infrastructure.Data;

namespace WebCourse.Web.Controllers
{
    public class VillaController : Controller
    {

        private readonly ApplicationDbContext db_;

        public VillaController(ApplicationDbContext db)
        {
            db_ = db;
        }
        public IActionResult Index()
        {
            var villas = db_.VillaDB.ToList();
            return View(villas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Villa villa)
        {

            if (villa.Name == villa.Description)
            {
                ModelState.AddModelError("Name", "Name ve Description aynı olamaz");
            }


            if (ModelState.IsValid)
            {
                db_.VillaDB.Add(villa);
                db_.SaveChanges();

                return RedirectToAction("Index", "Villa");
            }

            

            return View(villa);
            
        }

        public IActionResult Update(int villaID)
        {
            Villa? villaObj = db_.VillaDB.FirstOrDefault(u => u.Id == villaID);

            if (villaObj is null)
            {
                return RedirectToAction("Error", "Home");
            }


            return View(villaObj);
        }

        [HttpPost]
        public IActionResult Update(Villa villa)
        {

            if (villa.Name == villa.Description)
            {
                ModelState.AddModelError("Name", "Name ve Description aynı olamaz");
            }


            if (ModelState.IsValid)
            {
                db_.VillaDB.Update(villa);
                db_.SaveChanges();

                return RedirectToAction("Index", "Villa");
            }

            return View(villa);
        }

        public IActionResult Delete(int villaID)
        {
            Villa? villaObj = db_.VillaDB.FirstOrDefault(u => u.Id == villaID);


            if (villaObj is null)
            {

                TempData["error"] = "Villa Object is Null";

                return RedirectToAction("Error", "Home");
            }


            return View(villaObj);
        }

        [HttpPost]
        public IActionResult Delete(Villa villa)
        {
            Villa? villaObjFromDB = db_.VillaDB.FirstOrDefault(u => u.Id == villa.Id);

            if (villaObjFromDB is not null)
            {
                db_.VillaDB.Remove(villaObjFromDB);
                db_.SaveChanges();
                TempData["success"] = "Villa Object Deleted Successfuly";
            }    

            return RedirectToAction("Index", "Villa");
         
        }


    }
}
