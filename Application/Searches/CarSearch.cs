using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
    public class CarSearch
    {
        public string Name { get; set; }

        public decimal? MinPrice { get; set; }

        public decimal? MaxPrice { get; set; }

        public int EngineId { get; set; }

        public int ModelId { get; set; }

        public int FuelId { get; set; }

        public int TransmissionId { get; set; }
        public int PerPage { get; set; } = 6;
        public int PageNumber { get; set; } = 1;
    }
}
