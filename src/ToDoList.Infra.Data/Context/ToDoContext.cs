using System.Reflection;
using ToDoList.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ToDoList.Infra.Data.Context;

public class ToDoContext : DbContext
{
    public ToDoContext()
    {
        
    }

    public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
    {
        
        
    }
    
    private readonly string _connectionString = "Server=localhost;Database=juliano;Uid=SamuelEsdras;Pwd=05072003;";
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString));
        }
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<AssignmentList> AssignmentLists { get; set; } = null!;
    public DbSet<Assignment> Assignments { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    
    
}