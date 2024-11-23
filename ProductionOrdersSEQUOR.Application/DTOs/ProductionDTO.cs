using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionOrderSEQUOR.Application.DTOs
{
    public class ProductionDTO
    {
        public int Id { get;  set; }
        public string Email { get;  set; } = string.Empty;
        // public string Order { get;  set; } = string.Empty;

        public DateTime Date { get;  set; }

        public DateTime DateEnd { get;  set; }
        public decimal Quantity { get;  set; }

        public string MaterialCode { get;  set; } = string.Empty;

        public decimal CycleTime { get;  set; }

        public UserDTO UserDTO { get; set; }

        public ProductDTO ProductDTO { get; set; } 
    }
}
