namespace Issues.Models
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Security.Claims;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }

        private ICollection<Issue> createdIssues;
        private ICollection<Issue> assignedIssues;

        public User()
        {

        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
