using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class EquipmentDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Field Name is required")]
        public string Name { get; set; }
    }
}
