using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UnderstandingMVC.Data;
using UnderstandingMVC.Models;
using UnderstandingMVC.Models.Entities;

namespace UnderstandingMVC.Controllers
{
    public class FacultyController : Controller
    {
        private readonly ApplicationDBContext dbContext;

        public FacultyController(ApplicationDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(FacultyViewModel viewModel)
        {
            var faculty = new Faculty
            {
                Name = viewModel.Name,
                Phone = viewModel.Phone,
                SubjectF = viewModel.SubjectF,
                SubjectS = viewModel.SubjectS,
                Branch = viewModel.Branch,
                Address = viewModel.Address,
            };

            await dbContext.Faculties.AddAsync(faculty);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("List", "Faculty");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var faculties = await dbContext.Faculties.ToListAsync();
            return View(faculties);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var faculty = await dbContext.Faculties.FirstOrDefaultAsync(x => x.Id == id);
            if(faculty is not null)
            {
                dbContext.Faculties.Remove(faculty);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Faculty");
        }
    }
}
