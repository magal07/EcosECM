﻿using ProductionOrderSEQUOR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionOrderSEQUOR.Application.DTOs
{
    public class ProductionDTO
    {
        
        public int Id { get;  set; }

        public int ProIdUser { get; set; }

        public int ProIdProduct { get; set; }

        public string Email { get; set; } = string.Empty;
        public string MaterialCode { get; set;  }

        public UserDTO UserDTO { get; set; }

        public ProductDTO ProductDTO { get; set; }


        [Column(TypeName = "datetime")]
        public DateTime Date { get;  set; } = DateTime.UtcNow;
        [Column(TypeName = "hourtime")]
        public DateTime DateEnd { get;  set; } 
        public decimal Quantity { get;  set; }
        public decimal CycleTime { get;  set; }

    }
}
