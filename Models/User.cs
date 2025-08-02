using System.ComponentModel.DataAnnotations;

namespace RESTtraining.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name обязателен")]
        public string Name { get; set; } = string.Empty;

        [Range(1, 120, ErrorMessage = "Возраст должен быть от 1 до 120")]
        public int Age { get; set; }

        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
