using Microsoft.EntityFrameworkCore;
using IvanGovnov.Models;
using RESTtraining.Models; // �������� ���� namespace � ������� User

namespace IvanGovnov.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }

        // ��������� ��� EF CLI
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=users.db");
            }
        }
    


    
    }
}
