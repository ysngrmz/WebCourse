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

        public IActionResult Update(int villaNumberID)
        {
            VillaNumberVM villaNumberVM = new()
            {
                VillaList = db_.VillaDB.ToList().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                }),

                VillaNumber = db_.VillaNumberDB.FirstOrDefault(u=>u.Villa_Number == villaNumberID)

            };

            if (villaNumberVM.VillaNumber == null)
            {
                return RedirectToAction("Error", "Home");
            }
          

            return View(villaNumberVM);
        }

        [HttpPost]
        public IActionResult Update(VillaNumberVM villaNumberVM)
        {
         
            if (ModelState.IsValid)
            {
                db_.VillaNumberDB.Update(villaNumberVM.VillaNumber);
                db_.SaveChanges();
                TempData["success"] = "Villa Number Updated Succesfuly";
                return RedirectToAction("Index", "VillaNumber");
            }

            villaNumberVM.VillaList = db_.VillaDB.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            return View(villaNumberVM);
        }

        public IActionResult Delete(int villaNumberID)
        {
            VillaNumberVM villaNumberVM = new()
            {
                VillaList = db_.VillaDB.ToList().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                }),

                VillaNumber = db_.VillaNumberDB.FirstOrDefault(u => u.Villa_Number == villaNumberID)

            };

            if (villaNumberVM.VillaNumber == null)
            {
                return RedirectToAction("Error", "Home");
            }


            return View(villaNumberVM);
        }

        [HttpPost]
        public IActionResult Delete(VillaNumberVM villaNumberVM)
        {
            VillaNumber? villaObjFromDB = db_.VillaNumberDB.FirstOrDefault(u => u.Villa_Number == villaNumberVM.VillaNumber.Villa_Number);

            if (villaObjFromDB is not null)
            {
                db_.VillaNumberDB.Remove(villaObjFromDB);
                db_.SaveChanges();
                TempData["success"] = "Villa Object Deleted Successfuly";
                return RedirectToAction("Index", "VillaNumber");
            }

            TempData["error"] = "Data Could not Be Delted";
            return View();
            

        }
    }
}
