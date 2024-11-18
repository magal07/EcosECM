﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProductionOrderSEQUOR.API.Models
{
    public partial class Material
    {
        public Material()
        {
            ProductCode = new HashSet<Product>();
        }

        [Key]
        [StringLength(50)]
        [Unicode(false)]
        public string MaterialCode { get; set; }
        [Required]
        [StringLength(500)]
        [Unicode(false)]
        public string MaterialDescription { get; set; }

        [ForeignKey("MaterialCode")]
        [InverseProperty("MaterialCode")]
        public virtual ICollection<Product> ProductCode { get; set; }
    }
}