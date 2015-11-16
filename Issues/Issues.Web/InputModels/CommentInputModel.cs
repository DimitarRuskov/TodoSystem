using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Issues.Web.InputModels
{
    using Issues.Models;

    using Issues.Common.Mappings;

    public class CommentInputModel : IMapTo<Comment>
    {
        public string Content { get; set; }

        public string UserId { get; set; }

        public int IssueId { get; set; }
    }
}