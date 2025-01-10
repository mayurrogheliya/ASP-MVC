using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UnderstandingMVC.Data;
using UnderstandingMVC.Models;
using UnderstandingMVC.Models.Entities;

namespace UnderstandingMVC.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDBContext dBContext;

        public StudentsController(ApplicationDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel viewModel)
        {
            var student = new Student
            {
                Name = viewModel.Name,
                Phone = viewModel.Phone,
                Branch = viewModel.Branch,
                Semester = viewModel.Semester,
                Result = viewModel.Result,
                Address = viewModel.Address
            };
            await dBContext.Students.AddAsync(student);

            await dBContext.SaveChangesAsync();

            return RedirectToAction("List", "Students");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var students = await dBContext.Students.ToListAsync();
            return View(students);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var studnet = await dBContext.Students.FirstOrDefaultAsync(x=>x.Id == id);
            if (studnet is not null) 
            { 
                dBContext.Students.Remove(studnet);
                await dBContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Students");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await dBContext.Students.FirstOrDefaultAsync(x => x.Id == id);
            if(student == null)
            {
                return RedirectToAction("List", "Students");
            }
            var data = new AddStudentViewModel
            {
                Name = student.Name,
                Phone = student.Phone,
                Address = student.Address,
                Branch = student.Branch,
                Result = student.Result,
                Semester = student.Semester
            };

            ViewBag.StudentId = student.Id;
            return View("Add",data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id,AddStudentViewModel data)
        {
            var student = await dBContext.Students.FirstOrDefaultAsync(x => x.Id == id);
            if(student!=null)
            {
                student.Name = data.Name;
                student.Phone = data.Phone;
                student.Branch = data.Branch;
                student.Semester = data.Semester;
                student.Result = data.Result;
                student.Address = data.Address;

                dBContext.Students.Update(student);
                await dBContext.SaveChangesAsync();

                return RedirectToAction("List", "Students");
            }
            return RedirectToAction("List", "Students");
        }
    }
}
