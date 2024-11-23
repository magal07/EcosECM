using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProductionOrderSEQUOR.Application.DTOs
{
    public class ProductionPostDTO
    {
        [Required(ErrorMessage = "A quantidade é obrigatória. ")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantidade inválida. ")]

        public decimal Quantity { get; set; }
        [Required(ErrorMessage = "Informe o código do material. ")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantidade inválida. ")]
        public string MaterialCode { get; set; } = string.Empty;

        [JsonIgnore]
        public DateTime Date { get; set; }
        [JsonIgnore]
        public DateTime DateEnd { get; set; }

        [JsonIgnore]
        public decimal CycleTime { get; set; }
      
        // public string Production { get; set; }

    }
}
