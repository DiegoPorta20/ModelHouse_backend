using Microsoft.EntityFrameworkCore;
using ModelHouse.Interest.Domain.Models;
using ModelHouse.Profile.Domain.Models;
using ModelHouse.Security.Domain.Models;
using ModelHouse.Shared.Extensions;

namespace ModelHouse.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Area> Areas { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Service> Services { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Users
        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(p => p.Id);
        builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(p => p.Username).IsRequired().HasMaxLength(30);
        builder.Entity<User>().Property(p => p.FirstName).IsRequired();
        builder.Entity<User>().Property(p => p.LastName).IsRequired();
        
        builder.Entity<User>()
            .HasMany(p => p.Projects)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);
        
        builder.Entity<User>()
            .HasMany(p => p.Orders)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);
        
        // Areas
        builder.Entity<Area>().ToTable("Areas");
        builder.Entity<Area>().HasKey(p => p.Id);
        builder.Entity<Area>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Area>().Property(p => p.Name).IsRequired().HasMaxLength(30);
        builder.Entity<Area>().Property(p => p.Check).IsRequired();
        
        // Rooms
        builder.Entity<Room>().ToTable("Rooms");
        builder.Entity<Room>().HasKey(p => p.Id);
        builder.Entity<Room>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Room>().Property(p => p.Name).IsRequired().HasMaxLength(30);
        builder.Entity<Room>().Property(p => p.Check).IsRequired();
        
        // Services
        builder.Entity<Service>().ToTable("Services");
        builder.Entity<Service>().HasKey(p => p.Id);
        builder.Entity<Service>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Service>().Property(p => p.Name).IsRequired().HasMaxLength(30);
        builder.Entity<Service>().Property(p => p.Check).IsRequired();

        builder.Entity<Project>().ToTable("Projects");
        builder.Entity<Project>().HasKey(p => p.Id);
        builder.Entity<Project>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Project>().Property(p => p.Title).IsRequired().HasMaxLength(50);
        builder.Entity<Project>().Property(p => p.Price).IsRequired();
        builder.Entity<Project>().Property(p => p.Category).IsRequired().HasMaxLength(40);
        builder.Entity<Project>().Property(p => p.Location).IsRequired().HasMaxLength(120);
        builder.Entity<Project>().Property(p => p.Description).IsRequired().HasMaxLength(300);
        builder.Entity<Project>().Property(p => p.Photo).IsRequired();
        
        builder.Entity<Order>().ToTable("Orders");
        builder.Entity<Order>().HasKey(p => p.Id);
        builder.Entity<Order>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Order>().Property(p => p.Title).IsRequired().HasMaxLength(30);
        builder.Entity<Order>().Property(p => p.Description).IsRequired().HasMaxLength(200);
        // Apply Naming Conventions
        builder.UseSnakeCaseNamingConvention();


    }
}