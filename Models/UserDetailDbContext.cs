using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace SpacenditureAuthentication.Models
{
  public class UserDetailDbContext : DbContext
  {
    private readonly IConfiguration Configuration;
    public UserDetailDbContext(IConfiguration _configuration)
    {
      Configuration = _configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        optionsBuilder.UseMySql(Configuration.GetConnectionString("UserDetailDbContext"),
          mySqlOptions =>
          {
              mySqlOptions.ServerVersion(new Version(5, 7, 17), ServerType.MySql); // replace with your Server Version and Type
          }
        );
      }
    }

    public DbSet<UserDetail> Users { get; set; }
  }
}