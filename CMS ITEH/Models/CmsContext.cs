using CMS_ITEH.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_ITEH.Models
{
    public class CmsContext : DbContext 
    {
        public  DbSet<User> Users { get; set; }
        public static DbSet<Post> Posts { get; set; }
        public static DbSet<Role> Roles { get; set; }
        public static DbSet<Permission> Permissions { get; set; }

        private static CmsContext instance;
        public static CmsContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CmsContext();
                }
                return instance;
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Cms;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PermissionRole>().HasKey(e => new { e.PermissionId, e.RoleId });
            modelBuilder.Entity<Post>()
             .HasOne(p => p.User)
             .WithMany(b => b.Posts)
             .HasForeignKey("UserId");
            Seed(modelBuilder);
        }
        private static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role
            {
                RoleId = 1,
                RoleName = "Admin",
                RoleDescription = "Write and edit content, change other user information",
            });
            modelBuilder.Entity<Role>().HasData(new Role
            {
                RoleId = 2,
                RoleName = "Writer",
                RoleDescription = "Write and edit content"
            });

            modelBuilder.Entity<Permission>().HasData(new Permission
            {
                PermissionId = 1,
                PermissionName = "User management"
            });
            modelBuilder.Entity<Permission>().HasData(new Permission
            {
                PermissionId = 2,
                PermissionName = "Post management"
            });
            modelBuilder.Entity<PermissionRole>().HasData(new PermissionRole
            {
                RoleId = 1,
                PermissionId = 1
            });
            modelBuilder.Entity<PermissionRole>().HasData(new PermissionRole
            {
                RoleId   = 1,
                PermissionId =2
             
            });
            modelBuilder.Entity<PermissionRole>().HasData(new PermissionRole
            {
                RoleId = 2,
                PermissionId = 2
            });
        }
    }
}
