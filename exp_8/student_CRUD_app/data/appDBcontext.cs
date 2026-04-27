using Microsoft.EntityFrameworkCore;
using student_CRUD_app.models;

namespace StudentCRUDApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; } //connecting to the student table in the database

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\MSSQLLocalDB;Database=StudentDB;Trusted_Connection=True;");
        } }
}
