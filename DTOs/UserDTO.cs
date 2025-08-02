using System.ComponentModel.DataAnnotations;

namespace IvanGovnov.DTOs
{
    public class UserDto
    {
        [Required(ErrorMessage = "��� �����������")]
        public string Name { get; set; }

        [Range(1, 120, ErrorMessage = "������� ������ ���� �� 1 �� 120")]
        public int Age { get; set; }
    }

    


}