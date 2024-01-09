using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MvcEgitimPortalı.Models
{
    public class AppDbContext : IdentityDbContext<AppUser,AppRole,string>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }

        public DbSet<Instructor> Instructors { get; set; }

        public DbSet<Lesson> Lessons { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        
        
    }
}
