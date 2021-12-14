using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using StudentCourseApp.Models;
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

        public async Task<IActionResult> Dashboard(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;
            int pageSize = 10;
            var result = await this._studentRL.GetStudents(sortOrder, searchString,pageNumber ?? 1,pageSize);
            return View(result);
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(StudentModel student)
        {
            if (!ModelState.IsValid)
            {
                return View("RegisterStudent", student);
            }
            Student email = _studentRL.CheckEmail(student.EmailAddress);
                
            if (email != null)
            {
                ModelState.AddModelError("EmailAddress", "Mail already exists");
                return View("RegisterStudent", student);
            }

            return RedirectToAction("Dashboard");
        }


        public IActionResult RegisterStudent(StudentModel student)
        {
             return View(student);
        }
    }
}
