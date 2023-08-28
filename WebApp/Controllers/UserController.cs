using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using WebApp.Repositry;

namespace WebApp.Controllers
{
    public class UserController : Controller
    {
        IUser userData;
        public UserController( IUser _userdata)
        {
                userData = _userdata;
        }

        public IActionResult Index(int id)
        {
            User user = userData.GetById(id);
            if (user== null)
            {
                return NotFound();
            }
            return View(user);
        }
        [HttpGet]
        public IActionResult Create()
        {
            DepartData departData = new DepartData();//Bussiness layer
            ViewBag.departData = departData.GEtAll();
            return View();
        }
        [HttpPost]
        #region OldVersionCreate
        //public IActionResult Create( User Model, IFormFile photo) 
        //{

        //    if(photo != null)
        //    {
        //        using (var memoryStream = new MemoryStream())
        //        {
        //            photo.CopyTo(memoryStream);
        //            Model.Image = memoryStream.ToArray();
        //        }
        //    }
        //    userData.Add(Model);
        //    return RedirectToAction("Show");
        //} 
        #endregion
        [HttpPost]
        public IActionResult Create(User model, IFormFile photo)
        {
             DepartData departData = new DepartData(); // Business layer
            if (photo != null)
            {
                // File size validation (limit to 100 KB)
                const int maxSizeBytes = 100 * 1024; // 100 KB in bytes
                if (photo.Length > maxSizeBytes)
                {
                    ModelState.AddModelError("Photo", "Uploaded file size exceeds the limit of 100 KB.");
                    ViewBag.departData = departData.GEtAll();
                    return View(model);
                }

                using (var memoryStream = new MemoryStream())
                {
                    photo.CopyTo(memoryStream);
                    model.Image = memoryStream.ToArray();
                }
            }
            if(ModelState.IsValid)
            {
               userData.Add(model);
               return RedirectToAction("Show");
            }
            ViewBag.departData = departData.GEtAll();
            return View(model);

            }

        public IActionResult Show()
        {
            List<User> users = userData.GetAll();
            return View(users);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            
            User usermodel = userData.GetById(id);
            DepartData departData = new DepartData();
            ViewBag.departData = departData.GEtAll();
            return View(usermodel);
        }
        [HttpPost]
        public IActionResult SaveEdit(int id, User model, IFormFile photo)
        {
            User oldUser = dataContext.Users.FirstOrDefault(e => e.Id == id);
            DepartData departData = new DepartData();
            if (photo != null)
            {
                // File size validation (limit to 100 KB)
                const int maxSizeBytes = 100 * 1024; // 100 KB in bytes
                if (photo.Length > maxSizeBytes)
                {
                    ModelState.AddModelError("Photo", "Uploaded file size exceeds the limit of 100 KB.");
                    ViewBag.departData = departData.GEtAll();
                    return View("Edit", model);
                }

                // File extension validation
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
                var fileExtension = Path.GetExtension(photo.FileName).ToLowerInvariant();

                if (!allowedExtensions.Contains(fileExtension))
                {
                    ModelState.AddModelError("Photo", "Invalid file format. Only JPG, JPEG, and PNG are allowed.");
                    ViewBag.departData = departData.GEtAll();
                    return View("Edit", model);
                }

                using (var memoryStream = new MemoryStream())
                {
                    photo.CopyTo(memoryStream);
                    oldUser.Image = memoryStream.ToArray();
                }
            }

            oldUser.Name = model.Name;
            oldUser.Age = model.Age;

            // Update department only if a different department is selected
            if (oldUser.DeparId != model.DeparId)
            {
                oldUser.DeparId = model.DeparId;
            }

            dataContext.SaveChanges();
            return RedirectToAction("Show");
        }

        [HttpGet]
        public IActionResult Remove(int? id )
        {
            User usermodel= userData.GetById(id.Value);

            return View(usermodel);
        }
        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            User usermodel = userData.GetById(id);
            if (usermodel == null)
                return NotFound();
            userData.Delete(id);
            return RedirectToAction("Show");
        }
































        DataContext dataContext = new DataContext();

    }
}
