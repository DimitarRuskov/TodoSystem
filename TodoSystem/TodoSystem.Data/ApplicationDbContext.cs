namespace TodoSystem.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using TodoSystem.Models;
    using System.Data.Entity;
    using Migrations;

    public class ApplicationDbContext : DbContext //IdentityDbContext<User>
    {
        public ApplicationDbContext()
            :base("TodoSystemDB")
        {

        }
        //public ApplicationDbContext()
        //    : base("DefaultConnection", throwIfV1Schema: false)
        //{
        //    Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        //}

        //public static ApplicationDbContext Create()
        //{
        //    return new ApplicationDbContext();
        //}

        public DbSet<IssueTask> IssueTask { get; set; }

        public DbSet<Comment> Comments { get; set; }
    }
}
