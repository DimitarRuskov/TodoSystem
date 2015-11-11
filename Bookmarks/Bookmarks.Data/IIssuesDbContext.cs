namespace Issues.Data
{
    using System.Data.Entity;

    using Issues.Models;

    public interface IIssuesDbContext
    {
        IDbSet<Issue> Issues { get; set; }

        IDbSet<Comment> Comments { get; set; }

        int SaveChanges();
    }
}
