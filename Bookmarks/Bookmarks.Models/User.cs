namespace Issues.Models
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Security.Claims;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.ComponentModel.DataAnnotations;

    public class User : IdentityUser
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Admin Status")]
        public bool IsAdmin { get; set; }

        private ICollection<Issue> createdIssues;
        private ICollection<Issue> assignedIssues;

        //Use to User can see his Issue and Comments ???
        //private ICollection<Issue> tickets;
        //private ICollection<Comment> comments;

        //public User()
        //{
        //    this.tickets = new HashSet<Issue>();
        //    this.comments = new HashSet<Comment>();
        //}
        //public virtual ICollection<Issue> Tickets
        //{
        //    get { return this.tickets; }
        //    set { this.tickets = value; }
        //}

        //public virtual ICollection<Comment> Comments
        //{
        //    get { return this.comments; }
        //    set { this.comments = value; }
        //}
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
