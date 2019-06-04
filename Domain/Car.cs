using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Car : BaseEntity
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Src { get; set; }

        public string Alt { get; set; }

        public int EngineId { get; set; }

        public int ModelId { get; set; }

        public int FuelId { get; set; }

        public int TransmissionId { get; set; }

        public Engine Engine { get; set; }

        public Fuel Fuel { get; set; }

        public Model Model { get; set; }

        public Transmission Transmission { get; set; }

        public ICollection<CarEquipment> CarEquipment { get; set; }
    }
}
