namespace TodoSystem.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using TodoSystem.Models;
    using System.Data.Entity;
    using Migrations;

    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public IDbSet<Task> Tasks { get; set; }

        public IDbSet<Comment> Comments { get; set; }
    }
}
