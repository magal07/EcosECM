using ProductionOrdersSEQUOR.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProductionOrdersSEQUOR.Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string Email { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;
        public DateTime InitialDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string CPF { get; private set; } = string.Empty;

        public ICollection<Order>? Orders { get; set; }
        public ICollection<Production>? Productions { get; set; }

        // Construtor padrão exigido pelo EF Core
        public User() { }

        // Construtor com ID
        public User(int id, string email, string name, DateTime initialDate, DateTime endDate, string cpf)
        {
            DomainExceptionValidation.When(id < 0, "O Id do Cliente deve ser positivo.");

            Id = id;
            ValidateDomain(email, name, initialDate, endDate, cpf);
        }

        // Construtor sem ID
        public User(string email, string name, DateTime initialDate, DateTime endDate, string cpf)
        {
            ValidateDomain(email, name, initialDate, endDate, cpf);
        }

        public void Update(string email, string name, DateTime initialDate, DateTime endDate, string cpf)
        {
            ValidateDomain(email, name, initialDate, endDate, cpf);
        }

        private void ValidateDomain(string email, string name, DateTime initialDate, DateTime endDate, string cpf)
        {
            DomainExceptionValidation.When(email.Length > 100, "O Email deve ter no máximo 100 caracteres.");
            DomainExceptionValidation.When(name.Length > 50, "O Nome deve ter no máximo 50 caracteres.");
            DomainExceptionValidation.When(cpf.Length != 11, "O CPF deve ter 11 caracteres.");

            Email = email;
            Name = name;
            InitialDate = initialDate;
            EndDate = endDate;
            CPF = cpf;
        }
    }
}

