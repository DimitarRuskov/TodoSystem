namespace TodoSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<TodoSystem.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.ContextKey = "TodoSystem.Data.ApplicationDbContext";
            this.AutomaticMigrationDataLossAllowed = true;
        }
    }
}
