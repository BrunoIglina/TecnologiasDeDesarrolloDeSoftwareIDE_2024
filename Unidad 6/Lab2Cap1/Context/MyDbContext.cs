using Lab2Cap1.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab2Cap1.Context
{
    public class MyDbContext : DbContext
    {
        public DbSet<Alumno> Alumnoss { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }
    }
}
