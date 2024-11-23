using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionOrderSEQUOR.Application.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [MaxLength(ErrorMessage = "Máximo de 50 caracteres")]
        [Required(ErrorMessage = "O código do produto é obrigatório!")]
        public string ProductCode { get; set; } = string.Empty;

        [MaxLength(ErrorMessage = "Máximo de 200 caracteres")]
        [Required(ErrorMessage = "A descrição do produto é obrigatória!")]
        public string ProductDescription { get; set; } = string.Empty;


        /* [Required(ErrorMessage = "Erro CycleTime, verifique o ítem <ProductDTO.cs>")]
        public Decimal CycleTime { get; set; }
        */ 

        /*[MaxLength(ErrorMessage = "Imagem < code >")]
       public string Image { get; set; } = string.Empty; */

        /* [MaxLength(ErrorMessage = "Máximo de 50 caracteres")]
        [Required(ErrorMessage = "O código do produto é obrigatório!")]
        public int IDProdut { get; set; } */

    }
}
