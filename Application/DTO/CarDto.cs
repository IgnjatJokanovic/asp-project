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
        [Required(ErrorMessage = "Field Engine is required")]
        public int EngineId { get; set; }
        [Required(ErrorMessage = "Field Model is required")]
        public int ModelId { get; set; }
        [Required(ErrorMessage = "Field Fuel is required")]
        public int FuelId { get; set; }
        [Required(ErrorMessage = "Field Transmission is required")]
        public int TransmissionId { get; set; }

        public ICollection<EquipmentDto> Equipment { get; set; } = new List<EquipmentDto> ();

    }
}
