using Microsoft.EntityFrameworkCore;
using System;
using testApp1.Back_end.Entities;

namespace testApp1.Back_end
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<MovementData> MovementDatas { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=mydb;User Id=myuser;Password=mypass;");
        }
    }
}
