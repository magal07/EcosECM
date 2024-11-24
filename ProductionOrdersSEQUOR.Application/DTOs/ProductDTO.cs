using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProductionOrderSEQUOR.Application.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [MaxLength(200, ErrorMessage = "O campo produto não pode ultrapassar 200 caracteres.")]
        [Required(ErrorMessage = "O campo produto é obrigatório.")]
        public string ProductCode { get; set; }

        [MaxLength(250, ErrorMessage = "A descrição do produto não pode ultrapassar 200 caracteres.")]
        [Required(ErrorMessage = "A descrição do produto é obrigatória.")]
        public string ProductDescription { get; set; }


        [MaxLength(500, ErrorMessage = "O campo imagem não pode ultrapassar 500 caracteres.")]
        public string Image { get; set; }


        
        [Required(ErrorMessage = "O tempo de ciclo é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O tempo de ciclo deve ser maior que zero.")]
        public decimal CycleTime { get; set; }

    }
    
}
