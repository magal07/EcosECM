using ProductionOrdersSEQUOR.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProductionOrdersSEQUOR.Domain.Entities
{
    public class Product
    {

        public int Id { get; private set; }
        public string ProductCode { get; private set; } = string.Empty;
        public string ProductDescription { get; private set; } = string.Empty;
        public string Image { get; private set; } = string.Empty;
        public decimal CycleTime { get; private set; }


        public Product(int id, string productCode, string productDescription, string image, decimal cycleTime)

        {
            DomainExceptionValidation.When(id < 0, "O Id do Cliente deve ser positivo.");

            ProductCode = productCode;
            ProductDescription = productDescription;
            Image = image;
            CycleTime = cycleTime;

            {
                Id = id;
                ValidateDomain(productCode, productDescription, image, cycleTime);
            }
        }

        public Product(string productCode, string productDescription, string image, decimal cycleTime)
        {
                ValidateDomain(productCode, productDescription, image, cycleTime);
        }

        public void Update(string productCode, string productDescription, string image, decimal cycleTime)
        {
            ValidateDomain(productCode, productDescription, image, cycleTime);  
        }
        public void ValidateDomain(string productCode, string productDescription, string image, decimal cycleTime)
        {
            DomainExceptionValidation.When(productCode.Length != 50, "O produto deve ter no máximo 50 caracteres");
            DomainExceptionValidation.When(productDescription.Length != 50, "A descrição do produto deve ter no máximo 50 caracteres");
            DomainExceptionValidation.When(image.Length != 50, "A imagem do produto deve ter no máximo 50 caracteres");
            DomainExceptionValidation.When(cycleTime > 18, "O ciclo de tempo não pode ser maior que 18.");

            ProductCode = productCode;
            ProductDescription = productDescription;
            Image = image;
            CycleTime = cycleTime;
        }
    }
}
