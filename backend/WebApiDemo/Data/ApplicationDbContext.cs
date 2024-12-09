using Microsoft.EntityFrameworkCore;
using WebApiDemo.Models;

namespace WebApiDemo.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Shirt> Shirts { get; set; }
    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Data seeding for Shirt
        modelBuilder.Entity<Shirt>().HasData(
            new Shirt() { ShirtId = 1, Brand = "Brand1", Color = "Red", Gender = "Male", Price = 200, Size = 8 },
            new Shirt() { ShirtId = 2, Brand = "Brand2", Color = "Blue", Gender = "Female", Price = 300, Size = 10 },
            new Shirt() { ShirtId = 3, Brand = "Brand3", Color = "Green", Gender = "Unisex", Price = 1000, Size = 12 }
        );

        // Data seeding for Employee
        modelBuilder.Entity<Employee>().HasData(
            new Employee() { Id = 1, FirstName = "John", LastName = "Doe", Role = "Developer", DateOfJoining = "2023-01-01", Manager = "Jane Smith" },
            new Employee() { Id = 2, FirstName = "Jane", LastName = "Smith", Role = "Manager", DateOfJoining = "2020-03-15", Manager = "N/A" },
            new Employee() { Id = 3, FirstName = "Alice", LastName = "Johnson", Role = "Developer", DateOfJoining = "2022-07-10", Manager = "Jane Smith" }
        );
    }
}
