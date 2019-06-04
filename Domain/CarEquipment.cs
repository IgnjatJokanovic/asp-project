using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class CarEquipment
    {
        public int CarId { get; set; }

        public int EquipmentId { get; set; }

        public Car Car { get; set; }

        public Equipment Equipment { get; set; }
    }
}
