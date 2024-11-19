using System;
using Microsoft.EntityFrameworkCore;
using ProductionOrderSEQUOR.API.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


// using System.Security.Claims;

namespace ProductionOrderSEQUOR.API.DTOs
{
    public class UserDTO // Transferência de dados objetivos pelo DTO: DATA TRANSFER OBJECT 
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        [StringLength(50)]
        [Unicode(false)]
        [Required]
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        [Unicode(false)]

        

        public virtual ICollection<Production> Production { get; set; } = new List<Production>();

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