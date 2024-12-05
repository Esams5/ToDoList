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
    
    private readonly string _connectionString = "Server=localhost;Database=todo;Uid=SamuelEsdras;Pwd=05072003;";
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString));
        }
    }
    
    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserMap());
    }
    
    
}