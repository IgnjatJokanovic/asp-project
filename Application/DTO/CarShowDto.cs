using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class CarShowDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    
        public string Src { get; set; }

        public string Alt { get; set; }
       
        public string Engine { get; set; }
        
        public string Model { get; set; }
     
        public string Fuel { get; set; }
        public string Transmission { get; set; }

        public IEnumerable<string> EquipmentNames { get; set; }
    }
}
