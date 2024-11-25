using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionOrderSEQUOR.Application.DTOs
{
    public class ProductionPutDTO
    {
        [Required(ErrorMessage = "O identificador da produção é obrigatória.")]
        [Range(1, int.MaxValue, ErrorMessage = "O identificador da produção é inválido.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O email do operador é obrigatório.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "A quantidade é obrigatória.")]
        public decimal Quantity { get; set; }
    }
}
