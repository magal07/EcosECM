using ProductionOrdersSEQUOR.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProductionOrdersSEQUOR.Domain.Entities
{
    public class User //RATIFICANDO QUE "User" é utilizado como "Cliente" ou ALGO/ALGUÉM EXTERNO! para Usuário, o banco é USUÁRIO
    {
        public int Id { get; private set; } 
        public string Email { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;
        public DateTime InitialDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string CPF { get; private set; } = string.Empty;

        public ICollection<Order>? Orders { get;  set; }

        public ICollection<Production>? Productions { get;  set; }

        /* Organização do Construtor c/ ID */

        public User(int id, string email, string name, DateTime initialDate, DateTime endDate, string cpf)

        {
            DomainExceptionValidation.When(id < 0, "O Id do Cliente deve ser positivo.");
            Email = email;
            Name = name;
            InitialDate = initialDate;
            EndDate = endDate;
            CPF = cpf;

            {
                Id = id;
                ValidateDomain(email, name, initialDate, endDate, cpf);
            }
        }

        /* Organização do Construtor s/ ID */

        public User(string email, string name, DateTime initialDate, DateTime endDate, string cpf)

            {
                ValidateDomain(email, name, initialDate, endDate, cpf);
            }



        public void Update(string email, string name, DateTime initialDate, DateTime endDate, string cpf)
        {
            ValidateDomain(email, name, initialDate, endDate, cpf);
        }


        public void ValidateDomain(string email, string name, DateTime initialDate, DateTime endDate, string cpf)

        {
            DomainExceptionValidation.When(email.Length > 100, "O Email deve ter no máxmimo 100 caracteres.");
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

