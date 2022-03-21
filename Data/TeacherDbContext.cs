using Microsoft.EntityFrameworkCore;
using Rating.Models;

namespace Rating.Data
{
    public class TeacherDbContext : DbContext
    {

        public TeacherDbContext(DbContextOptions<TeacherDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        //entities
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Ratings> Ratings { get; set; }
    }
}
