using Microsoft.EntityFrameworkCore;
using mvc6.Models.Entities;

namespace mvc6.Data
{
    public class ApplicationDbContext : DbContext   //connection string + tables
    {
        //connection string:
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //table:
        public DbSet<Product> Products { get; set; }
    }
