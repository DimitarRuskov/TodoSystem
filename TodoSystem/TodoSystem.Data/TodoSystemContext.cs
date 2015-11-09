using System.Data.Entity;
using TodoSystem.Models;

namespace TodoSystem.Data
{
    public class TodoSystemContext : DbContext
    {
        public TodoSystemContext()
            : base("TodoSystemDB")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<IssueTask> Issues { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
