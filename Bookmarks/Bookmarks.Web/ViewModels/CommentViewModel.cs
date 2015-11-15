namespace Issues.Web.ViewModels
{
    using Issues.Models;

    using Issues.Common.Mappings;

    public class CommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public User User { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentViewModel>()
                .ForMember(m => m.User, cfg => cfg.MapFrom(e => e.User));
        }
    }
}
