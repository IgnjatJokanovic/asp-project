using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Engine : BaseEntity
    {
        public string Name { get; set; }

        public int CC { get; set; }

        public IEnumerable<Engine> Engines { get; set; }
    }
}
