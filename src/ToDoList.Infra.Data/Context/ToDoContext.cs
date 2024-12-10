using System.Reflection;
using ToDoList.Domain.Entities;
using ToDoList.Infra.Data.Mappings;
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
    
    private readonly string _connectionString = "Server=localhost;Database=todoapi;Uid=SamuelEsdras;Pwd=05072003;";
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString));
        }
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<AssignmentList> AssignmentLists { get; set; }
    public DbSet<Assignment> Assignments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    
    
}