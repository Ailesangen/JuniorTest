using Microsoft.EntityFrameworkCore;
using EmplDBA.API.Models;

namespace EmplDBA.API.Data{
    public class DataContext : DbContext{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {}
    public DbSet<Post> Posts {get; set; }
    public DbSet<Employee> Employees {get; set;}

    }

}