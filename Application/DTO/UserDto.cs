using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class UserDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Field FirstName is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Field LastName is required")]

        public string LastName { get; set; }
        [Required(ErrorMessage = "Field UserName is required")]

        public string Username { get; set; }
        [Required(ErrorMessage = "Field Password is required")]

        public string Password { get; set; }
        [Required(ErrorMessage = "Field Email is required")]

        public string Email { get; set; }
    }
}
