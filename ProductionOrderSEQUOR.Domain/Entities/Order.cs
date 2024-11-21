using ProductionOrdersSEQUOR.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProductionOrdersSEQUOR.Domain.Entities
{
    public class Order
    {
        public int Id { get; private set; }

        public int OrderID { get; private set; }

        public decimal Quantity { get; private set; }
        public string ProductCode { get; private set; } = string.Empty;

        public ICollection<Production>? Production {  get;  set; }

        public Order(int id, int orderID, decimal quantity, string productCode)

        {
            DomainExceptionValidation.When(id < 0, "O Id do Cliente deve ser positivo!");
            OrderID = orderID;
            Quantity = quantity;
            ProductCode = productCode;
            {
                Id = id;
                ValidateDomain(orderID, quantity, productCode);
            }

        }
        public Order (int orderID, decimal quantity, string productCode)
        {
            ValidateDomain(orderID, quantity, productCode);
        }


        
        public void Update(int orderID, decimal quantity, string productCode)
        {
            ValidateDomain(orderID, quantity, productCode); 

        }
        public void ValidateDomain(int orderID, decimal quantity, string productCode)
        {
            DomainExceptionValidation.When(orderID < 0, "Null");
            DomainExceptionValidation.When(quantity > 18, "Quantidade não pode ser superior a 18. Favor, incluir como novo ítem!");
            DomainExceptionValidation.When(productCode.Length != 50, "O produto deve ter no máximo 50 caracteres");

            OrderID = orderID;
            Quantity = quantity;
            ProductCode = productCode;
        }
    }
}
