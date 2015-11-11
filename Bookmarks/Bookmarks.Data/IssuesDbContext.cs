namespace Issues.Data
{
    using System.Data.Entity;

    using Issues.Data.Migrations;
    using Issues.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class IssuesDbContext : IdentityDbContext<User>, IIssuesDbContext
    {
        public IssuesDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<IssuesDbContext, Configuration>());
        }

        public static IssuesDbContext Create()
        {
            return new IssuesDbContext();
        }

        public IDbSet<Issue> Issues { get; set; }

        public IDbSet<Comment> Comments { get; set; }
    }
}
