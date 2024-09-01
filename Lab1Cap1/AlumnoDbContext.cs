using Lab1Cap1;
using Microsoft.EntityFrameworkCore;

public class AlumnoDbContext : DbContext
{
    public DbSet<Alumno> Alumnos { get; set; }

    public AlumnoDbContext(DbContextOptions<AlumnoDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
