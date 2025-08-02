using RESTtraining.Models;

namespace IvanGovnov.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Content { get; set; } = null!;

        public int UserId { get; set; }

        public User User { get; set; } = null!;
    }
}
