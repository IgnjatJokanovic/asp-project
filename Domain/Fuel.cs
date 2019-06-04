using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Fuel : BaseEntity
    {
        public string Type { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
