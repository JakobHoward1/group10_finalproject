
using Group10_FinalProject.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Group10_FinalProject.API.Data;

public class AppDbContext : DbContext
{
    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<Customer> Customers { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

 
        modelBuilder.Entity<MenuItem>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.Price).HasPrecision(10, 2).IsRequired();
            entity.Property(e => e.CreatedAt).IsRequired();

            entity.HasIndex(e => e.Category);
            entity.HasIndex(e => e.Price);
            entity.HasIndex(e => e.CreatedAt);
        });

       
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Review).HasMaxLength(1000);
            entity.Property(e => e.Rating).IsRequired();
            entity.Property(e => e.CreatedAt).IsRequired();

            entity.HasIndex(e => e.Rating);
            entity.HasIndex(e => e.CreatedAt);
        });

        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
   
        var menuItemGuids = new[]
        {
            Guid.Parse("11111111-1111-1111-1111-111111111111"),
            Guid.Parse("22222222-2222-2222-2222-222222222222"),
            Guid.Parse("33333333-3333-3333-3333-333333333333"),
            Guid.Parse("44444444-4444-4444-4444-444444444444"),
            Guid.Parse("55555555-5555-5555-5555-555555555555"),
            Guid.Parse("66666666-6666-6666-6666-666666666666"),
            Guid.Parse("77777777-7777-7777-7777-777777777777"),
            Guid.Parse("88888888-8888-8888-8888-888888888888"),
            Guid.Parse("99999999-9999-9999-9999-999999999999"),
            Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa")
        };

        var customerGuids = new[]
        {
            Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
            Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc"),
            Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd"),
            Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"),
            Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff"),
            Guid.Parse("10101010-1010-1010-1010-101010101010"),
            Guid.Parse("20202020-2020-2020-2020-202020202020"),
            Guid.Parse("30303030-3030-3030-3030-303030303030"),
            Guid.Parse("40404040-4040-4040-4040-404040404040"),
            Guid.Parse("50505050-5050-5050-5050-505050505050")
        };

        var baseDate = new DateTime(2024, 1, 1);


        modelBuilder.Entity<MenuItem>().HasData(
            new { Id = menuItemGuids[0], Name = "Pan-Seared Steak", Category = "Main Course", Price = 30.00m, CreatedAt = baseDate.AddDays(1) },
            new { Id = menuItemGuids[1], Name = "Mushroom Risotto", Category = "Vegetarian", Price = 24.00m, CreatedAt = baseDate.AddDays(2) },
            new { Id = menuItemGuids[2], Name = "Grilled Salmon", Category = "Main Course", Price = 28.00m, CreatedAt = baseDate.AddDays(3) },
            new { Id = menuItemGuids[3], Name = "Margherita Pizza", Category = "Vegetarian", Price = 20.00m, CreatedAt = baseDate.AddDays(4) },
            new { Id = menuItemGuids[4], Name = "Vegan Buddha Bowl", Category = "Vegetarian", Price = 22.00m, CreatedAt = baseDate.AddDays(5) },
            new { Id = menuItemGuids[5], Name = "Chicken Alfredo Pasta", Category = "Main Course", Price = 25.00m, CreatedAt = baseDate.AddDays(6) },
            new { Id = menuItemGuids[6], Name = "Garden Salad", Category = "Vegetarian", Price = 18.00m, CreatedAt = baseDate.AddDays(7) },
            new { Id = menuItemGuids[7], Name = "Beef Burger", Category = "Main Course", Price = 21.00m, CreatedAt = baseDate.AddDays(8) },
            new { Id = menuItemGuids[8], Name = "Spicy Tofu Stir-Fry", Category = "Vegetarian", Price = 23.00m, CreatedAt = baseDate.AddDays(9) },
            new { Id = menuItemGuids[9], Name = "Lobster Bisque", Category = "Main Course", Price = 27.00m, CreatedAt = baseDate.AddDays(10) }
        );

    
        modelBuilder.Entity<Customer>().HasData(
            new { Id = customerGuids[0], Name = "John Simpson", Review = "Lovely establishment and the food was great", Rating = 5, CreatedAt = baseDate.AddDays(11) },
            new { Id = customerGuids[1], Name = "Susie Thomas", Review = "Great service", Rating = 4, CreatedAt = baseDate.AddDays(12) },
            new { Id = customerGuids[2], Name = "Michael Lee", Review = "The steak was amazing", Rating = 5, CreatedAt = baseDate.AddDays(13) },
            new { Id = customerGuids[3], Name = "Emma Johnson", Review = "Friendly staff but a bit slow", Rating = 3, CreatedAt = baseDate.AddDays(14) },
            new { Id = customerGuids[4], Name = "Carlos Ramirez", Review = "Excellent atmosphere and drinks", Rating = 5, CreatedAt = baseDate.AddDays(15) },
            new { Id = customerGuids[5], Name = "Sophia Brown", Review = "Portions were small", Rating = 3, CreatedAt = baseDate.AddDays(16) },
            new { Id = customerGuids[6], Name = "Daniel Kim", Review = "Loved the pasta dishes", Rating = 4, CreatedAt = baseDate.AddDays(17) },
            new { Id = customerGuids[7], Name = "Olivia Martinez", Review = "Cozy place and tasty meals", Rating = 5, CreatedAt = baseDate.AddDays(18) },
            new { Id = customerGuids[8], Name = "Liam Davis", Review = "Could improve on the wait times", Rating = 3, CreatedAt = baseDate.AddDays(19) },
            new { Id = customerGuids[9], Name = "Ava Wilson", Review = "Fantastic experience overall", Rating = 5, CreatedAt = baseDate.AddDays(20) }
        );
    }

 
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Modified)
            .Where(e => e.Entity is MenuItem || e.Entity is Customer);

        foreach (var entry in entries)
        {
            if (entry.Entity is MenuItem menuItem)
                menuItem.GetType().GetProperty("UpdatedAt")?.SetValue(menuItem, DateTime.Now);

            if (entry.Entity is Customer customer)
                customer.GetType().GetProperty("UpdatedAt")?.SetValue(customer, DateTime.Now);
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}
