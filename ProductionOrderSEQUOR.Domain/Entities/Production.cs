using ProductionOrderSEQUOR.Domain.Validation;
using System;

namespace ProductionOrderSEQUOR.Domain.Entities
{
    public class Production
    {
        public int Id { get; private set; }
        public string Email { get; private set; } = string.Empty;
        // public string Order { get; private set; } = string.Empty;

         public DateTime Date { get; private set; }

        public decimal Quantity { get; private set; }

        public string MaterialCode { get; private set; } = string.Empty;

        public decimal CycleTime { get; private set; }

        public User? User { get; set; }

        public Order? Order { get; set; }

       


        public Production(int id, string email, decimal quantity, string materialCode, decimal cycleTime)
        {
            DomainExceptionValidation.When(id < 0, "Id do produto deve ser positivo.");
            ValidateDomain(email, quantity, materialCode, cycleTime);
            Email = email;
            // Date = date; // Remover ou adicionar a propriedade 'Date' se necessário
            Quantity = quantity;
            MaterialCode = materialCode;
            CycleTime = cycleTime;
            {
                Id = id;
                ValidateDomain(email, quantity, materialCode, cycleTime);
            }
        }

        public Production(string email, decimal quantity, string materialCode, decimal cycleTime)
        {
            ValidateDomain(email, quantity, materialCode, cycleTime);
        }

        public void Update(string email, decimal quantity, string materialCode, decimal cycleTime)
        {

            ValidateDomain(email, quantity, materialCode, cycleTime);
        }
        public void ValidateDomain(string email, decimal quantity, string materialCode, decimal cycleTime)
        {
            DomainExceptionValidation.When(email.Length > 100, "O Email deve ter no máximo 100 caracteres.");
            Email = email;
            // Date = date; // Remover ou adicionar a propriedade 'Date' se necessário
            Quantity = quantity;
            MaterialCode = materialCode;
            CycleTime = cycleTime;

        }
    }
}
