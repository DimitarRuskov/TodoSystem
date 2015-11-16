namespace Issues.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Issues.Data.IssuesDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(IssuesDbContext context)
        {
            //var passwordHash = new PasswordHasher();
            //string password = passwordHash.HashPassword("123123");
            //context.Users.AddOrUpdate(u => u.UserName,
            //    new User
            //    {
            //        FirstName = "Klark",
            //        LastName = "Kent",
            //        UserName = "root",
            //        Email = "root@abv.bg",
            //        PasswordHash = password
            //    });
        }
    }
}
