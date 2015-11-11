namespace Issues.Data
{
    using System;
    using System.Collections.Generic;

    using Issues.Data.Repositories;
    using Issues.Models;

    public class IssuesData : IIssuesData
    {
        private IIssuesDbContext context;
        private IDictionary<Type, object> repositories;

        public IssuesData(IIssuesDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        public IRepository<Issue> Issues
        {
            get { return this.GetRepository<Issue>(); }
        }

        public IRepository<Comment> Comments
        {
            get { return this.GetRepository<Comment>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var type = typeof(T);
            if (!this.repositories.ContainsKey(type))
            {
                var typeOfRepository = typeof(GenericRepository<T>);
                //                if (type.IsAssignableFrom(typeof(Game)))
                //                {
                //                    typeOfRepository = typeof(GamesRepository);
                //                }

                var repository = Activator.CreateInstance(typeOfRepository, this.context);
                this.repositories.Add(type, repository);
            }

            return (IRepository<T>)this.repositories[type];
        }
    }
}
