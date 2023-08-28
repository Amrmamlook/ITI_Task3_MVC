using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Repositry;

namespace WebApp.Controllers
{
    public class DepartmentController : Controller
    {
        DepartData db = new DepartData();
        public IActionResult Index()
        {
            var DepartmentList= db.GEtAll();
            return View(DepartmentList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Create( Department model) {
            db.Add(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == null)
                return NotFound();
            Department department = db.GEtById(id);
            return View(department);
        }
        [HttpPost]
        public IActionResult SaveEdit(int id, Department model)
        {
            if (model != null)
            {
                var updatedProperties = new Department
                {
                    Id = id,
                    NameDepart = model.NameDepart,
                    Manager = model.Manager
                };

                var updatedDepartment = db.Update(updatedProperties);
                return RedirectToAction("Index");
            }

            return View("Edit", model);
        }

        //public IActionResult SaveEdit( int id ,Department Model  )
        //{
        //    if (Model != null)
        //    {
        //        Department Olddepartment = db.GEtById(id);
        //        db.Update(Model);
        //        return RedirectToAction("Index");

        //    }
        //    return View("Edit", Model);
        //}
        public IActionResult Remove(int? id)
        {
            Department usermodel = db.GEtById(id.Value);

            return View(usermodel);
        }
        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            Department usermodel = db.GEtById(id);
            if (usermodel == null)
                return NotFound();
            db.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
