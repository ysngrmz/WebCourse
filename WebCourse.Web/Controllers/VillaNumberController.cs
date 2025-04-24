using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebCourse.Domain.Entities;
using WebCourse.Infrastructure.Data;
using WebCourse.Web.ViewModels;

namespace WebCourse.Web.Controllers
{
    public class VillaNumberController : Controller
    {
        private readonly ApplicationDbContext db_;

        public VillaNumberController(ApplicationDbContext db)
        {
            db_ = db;
        }
        public IActionResult Index()
        {
            var villaNumbers = db_.VillaNumberDB.Include(u => u.Villa).ToList();

            return View(villaNumbers);
        }

        public IActionResult Create()
        {

            VillaNumberVM villaNumberVM = new()
            {
                VillaList = db_.VillaDB.ToList().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                })

            };

            return View(villaNumberVM);
        }

        [HttpPost]
        public IActionResult Create(VillaNumberVM villaNumberVM)
        {
            bool roomNumberExist = db_.VillaNumberDB.Any(
                u => u.Villa_Number == villaNumberVM.VillaNumber.Villa_Number);

            if (ModelState.IsValid && !roomNumberExist)
            {
                db_.VillaNumberDB.Add(villaNumberVM.VillaNumber);
                db_.SaveChanges();

                return RedirectToAction("Index", "VillaNumber");
            }

            if (roomNumberExist)
            {
                TempData["error"] = "Villa Number Already Exist";
            }

            villaNumberVM.VillaList = db_.VillaDB.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            return View(villaNumberVM);

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
