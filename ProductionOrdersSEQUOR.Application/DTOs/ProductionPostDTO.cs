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

        [Required(ErrorMessage = "O usuário é obrigatório")]
         [Range(1, int.MaxValue, ErrorMessage = "O identificador do usuário é invalido!")]
        public int ProIdUser { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "O identificador do usuário é invalido!")]

        [Required(ErrorMessage = "O produto é obrigatório")]
        public int ProIdProduct{ get; set; }


        [Required(ErrorMessage = "A quantidade é obrigatória. ")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantidade inválida. ")]
        public decimal Quantity { get; set; }

        
        //[Required(ErrorMessage = "Informe o código do material. ")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantidade inválida. ")]
        public string MaterialCode { get; set; }

        [JsonIgnore]
        public decimal CycleTime { get; set; }

        [JsonIgnore]
        public DateTime Date { get; set; }


        [JsonIgnore]
        public DateTime DateEnd { get; set; }

        /*
        [JsonIgnore]
        public bool isAdmin { get; set; }

        */
    }
}
