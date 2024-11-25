using ProductionOrderSEQUOR.Domain.Validation;
using System;

namespace ProductionOrderSEQUOR.Domain.Entities
{
    public class Production
    {

        public int Id { get; private set; }
        public int ProIdUser { get; private set; }
        public int ProIdProduct { get; private set; }
        public string Email { get;  set; } 
        public DateTime Date { get; private set; }
        public DateTime DateEnd { get; private set; }
        public decimal Quantity { get; private set; }
        public string MaterialCode { get; private set; }
        public decimal CycleTime { get; private set; }

        public User User { get; set; }
        public Product Product { get; set; }

        public ICollection<Product> Products { get;  set; }

        // Construtor padrão necessário para o AutoMapper
        public Production()
        {
            /*Inicialize as propriedades com valores padrão
            Email = string.Empty;
            MaterialCode = string.Empty;*/ 
        }

        // Construtor com parâmetros para inicialização completa
        public Production(int id, int proIdUser, int proIdProduct, DateTime date, DateTime dateEnd, string email, decimal quantity, string materialCode, decimal cycleTime)
        {
            DomainExceptionValidation.When(id < 0, "Id do produto deve ser positivo.");
            Id = id;
            ValidateDomain(proIdUser, proIdProduct, date, dateEnd, email, quantity, materialCode, cycleTime); // Corrigido: Incluído `materialCode` e `dateEnd`

            
            ProIdUser = proIdUser;
            ProIdProduct = proIdProduct;
            Date = date;
            DateEnd = dateEnd;
            Email = email;
            Quantity = quantity;
            MaterialCode = materialCode;
            CycleTime = cycleTime;
        }

        // Construtor para inserção, com parâmetros sem id
        public Production(int proIdUser, int proIdProduct, DateTime date, DateTime dateEnd, string email, decimal quantity, string materialCode, decimal cycleTime)
        {
            ValidateDomain(proIdUser, proIdProduct, date, dateEnd, email, quantity, materialCode, cycleTime);
        }

        // Método de atualização
        public void Update(int proIdUser, int proIdProduct, DateTime date, DateTime dateEnd, string email, decimal quantity, string materialCode, decimal cycleTime)
        {
            ValidateDomain(proIdUser, proIdProduct, date, dateEnd, email, quantity, materialCode, cycleTime);
        }

        // Validação de domínio
        public void ValidateDomain(int proIdUser, int proIdProduct, DateTime date, DateTime dateEnd, string email, decimal quantity, string materialCode, decimal cycleTime)
        {
            DomainExceptionValidation.When(email.Length > 100, "O Email deve ter no máximo 100 caracteres.");
            DomainExceptionValidation.When(proIdUser < 0, "O usuário não pode ter um ID negativo.");
            DomainExceptionValidation.When(proIdProduct < 0, "O produto não pode ter um ID negativo.");
            DomainExceptionValidation.When(materialCode.Length > 200, "O código do material deve ter no máximo 200 caracteres.");
            DomainExceptionValidation.When(date == DateTime.MinValue, "Data inicial incorreta!");
            DomainExceptionValidation.When(dateEnd == DateTime.MinValue, "Horário Inválido!");
            DomainExceptionValidation.When(cycleTime <= 0, "O tempo de ciclo deve ser maior que zero.");
            DomainExceptionValidation.When(quantity <= 0, "A quantidade deve ser maior que zero.");

            ProIdUser = proIdUser;
            ProIdProduct = proIdProduct;
            Date = date;
            DateEnd = dateEnd;
            Email = email;
            Quantity = quantity;
            MaterialCode = materialCode;
            CycleTime = cycleTime;
        }
    }
}
