using ImageSaveAndReadCoreMongoDB.IRepository;
using ImageSaveAndReadCoreMongoDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ImageSaveAndReadCoreMongoDB.Controllers
{
    public class HomeController : Controller
    {
        IEmployeeRepository _empRepo = null;
        public HomeController(IEmployeeRepository empRepo)
        {
            _empRepo = empRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string SaveFile(FileUpload fileObj)
        {
            Employee emp = JsonConvert.DeserializeObject<Employee>(fileObj.Employee);

            if(fileObj.file.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    fileObj.file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    emp.Photo = fileBytes;
                    emp = _empRepo.Save(emp);
                    Console.Write("---------------"+emp);

                    if(emp.Id.Trim() != "")
                    {
                        return "Saved";
                    }
                }
            }
            return "Failed";
        }

        [HttpGet]
        public JsonResult GetSavedEmployee()
        {
            var emp = _empRepo.GetSavedEmployee();
            emp.Photo = this.GetImage(Convert.ToBase64String(emp.Photo));
            return Json(emp);
        }
        public byte[] GetImage(string sBase64String)
        {
            byte[] bytes = null;
            if (!string.IsNullOrEmpty(sBase64String))
            {
                bytes = Convert.FromBase64String(sBase64String);
            }
            return bytes;
        }
    }
}
