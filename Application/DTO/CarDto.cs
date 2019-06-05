using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class CarDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Filed Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Field Price is required")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Field Image is required")]
        public string Src { get; set; }

        public string Alt { get; set; }

        public IEnumerable<string> EquipmentNames { get; set; }
    }
}
