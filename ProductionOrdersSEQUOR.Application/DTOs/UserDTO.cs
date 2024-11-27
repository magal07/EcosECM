using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

// using System.Security.Claims;

namespace ProductionOrderSEQUOR.Application.DTOs
{
    public class UserDTO // Transferência de dados objetivos pelo DTO: DATA TRANSFER OBJECT 
    {
        [IgnoreDataMember]

        public int Id { get; set; }
        [Required]

        [StringLength(50, ErrorMessage = "O seu nome não pode ter mais de 50 caracteres.")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Column("CPF")]
        [StringLength(11, ErrorMessage = "O seu cpf não pode ter mais de 11 caracteres.")]
        [MinLength(11, ErrorMessage = "O seu cpf não pode ter mais de 11 caracteres.")]
        [Unicode(false)]
        public string Cpf { get; set; } = string.Empty;


        [Required]
        [StringLength(100, ErrorMessage = "O seu Email não pode ter mais de 100 caracteres.")]
        public string Email { get; set; } = string.Empty;

        [JsonIgnore]
        public bool IsAdmin { get; set; }

    }
}