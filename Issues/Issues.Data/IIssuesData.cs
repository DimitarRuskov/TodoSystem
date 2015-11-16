namespace Issues.Data
{
    using System.Text.RegularExpressions;

    using Issues.Data.Repositories;
    using Issues.Models;

    public interface IIssuesData
    {
        IRepository<User> Users { get; }
        
        IRepository<Issue> Issues { get; }

        IRepository<Comment> Comments { get; }

        int SaveChanges();
    }
}
