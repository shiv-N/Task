using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCourseApp.Controllers
{
    public class StudentsController : Controller
    {
        private IStudentRL _studentRL;

        public StudentsController(IStudentRL studentRL)
        {
            this._studentRL = studentRL;
        }

        public IActionResult Dashboard(string sortOrder, string searchString)
        {
            ViewData["NameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentFilter"] = searchString;

            var result = this._studentRL.GetStudents(sortOrder, searchString);
            return View(result);
        }
    }
}
