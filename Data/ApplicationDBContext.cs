using Microsoft.EntityFrameworkCore;
using UnderstandingMVC.Models.Entities;

namespace UnderstandingMVC.Data
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
    }
}
