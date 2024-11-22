using ProductionOrdersSEQUOR.Domain.Entities;
using ProductionOrdersSEQUOR.Domain.Validation;
using System;
using System.Collections.Generic;

namespace ProductionOrdersSEQUOR.Infra.Data.EntitiesConfiguration
{
    public class Order
    {
        // Propriedade principal: Chave primária
        public int Id { get; private set; }

        // Propriedades da entidade
        public decimal Quantity { get; private set; }
        public string ProductCode { get; private set; } = string.Empty;

        // Relacionamentos
        public ICollection<User>? Users { get; set; } // Relacionamento com User
        public ICollection<Production>? Productions { get; set; } // Relacionamento com Production

        // Construtor com ID
        public Order(int id, decimal quantity, string productCode)
        {
            DomainExceptionValidation.When(id < 0, "O Id do Pedido deve ser positivo!");
            Id = id;
            ValidateDomain(quantity, productCode);
        }

        // Construtor sem ID
        public Order(decimal quantity, string productCode)
        {
            ValidateDomain(quantity, productCode);
        }

        // Método de atualização
        public void Update(decimal quantity, string productCode)
        {
            ValidateDomain(quantity, productCode);
        }

        // Validações do domínio
        private void ValidateDomain(decimal quantity, string productCode)
        {
            DomainExceptionValidation.When(quantity <= 0, "A quantidade deve ser maior que zero!");
            DomainExceptionValidation.When(quantity > 18, "A quantidade não pode ser superior a 18. Favor, incluir como novo item!");
            DomainExceptionValidation.When(productCode.Length > 50, "O código do produto deve ter no máximo 50 caracteres.");

            Quantity = quantity;
            ProductCode = productCode;
        }
    }
}
