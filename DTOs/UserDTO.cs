using System.ComponentModel.DataAnnotations;

namespace IvanGovnov.DTOs
{
    public class UserDto
    {
        [Required(ErrorMessage = "Имя обязательно")]
        public string Name { get; set; }

        [Range(1, 120, ErrorMessage = "Возраст должен быть от 1 до 120")]
        public int Age { get; set; }
    }

    


}