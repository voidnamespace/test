using System.ComponentModel.DataAnnotations;

namespace IvanGovnov.DTOs
{

    public class PostDto
    {
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public int UserId { get; set; }
    }


}