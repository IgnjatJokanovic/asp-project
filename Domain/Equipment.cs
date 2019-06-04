using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Equipment : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<CarEquipment> CarEquipment { get; set; }
    }
}
