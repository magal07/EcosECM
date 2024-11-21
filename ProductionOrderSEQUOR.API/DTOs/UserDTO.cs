using System;
using Microsoft.EntityFrameworkCore;
using ProductionOrderSEQUOR.API.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Runtime.ConstrainedExecution;


// using System.Security.Claims;

namespace ProductionOrderSEQUOR.API.DTOs
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

        



        // Remova propriedades desnecessárias ou aplique lógica quando necessário
        // public virtual ICollection<Production> Production { get; set; } = new List<Production>(); -- CASO QUEIRA ACRESCENTAR INFO SOBRE A PRODUÇÃO
    }
}


/* 
 * 
 * 
 * [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Unicode(false)]
        public string Email { get; set; } = string.Empty; // Inicializado com valor padrão. Versão .NET 6 não autoriza no formato padrão.

        [StringLength(50)]
        [Unicode(false)]
        public string Name { get; set; } = string.Empty; // Inicializado com valor padrão.

        [Column(TypeName = "InitialDate")]
        public DateTime? InitialDate { get; set; }

        [Column(TypeName = "EndDate")]
        public DateTime? EndDate { get; set; }

        public virtual ICollection<Production> Production { get; set; } = new List<Production>(); // Inicialização direta.

        public ClaimsIdentity? UserName { get; internal set; } // Tornado anulável.

*/ 