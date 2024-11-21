using ProductionOrdersSEQUOR.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionOrdersSEQUOR.Domain.Entities

{
    public class ProductMaterial
    {
        public int Id { get; private set; }
        public string ProductCode { get; private set; } = string.Empty;
        public string MaterialCode { get; private set; } = string.Empty;

        public int IDProductMaterial { get; set;  }


        public ProductMaterial(int id, string productCode, string materialCode)
        {
            DomainExceptionValidation.When(id < 0, "Id do produto deve ser positivo.");

            ProductCode = productCode;
            MaterialCode = materialCode;

            {
                Id = id;
                ValidateDomain(productCode, MaterialCode);
            }
        }


        public ProductMaterial(string productCode, string materialCode)
        {
            ValidateDomain(productCode, materialCode);
        }

        public void Update(string productCode, string materialCode)
        {
            ValidateDomain(productCode, materialCode);
        }
        public void ValidateDomain(string productCode, string materialCode)
        {
            DomainExceptionValidation.When(productCode.Length != 50, "O produto deve ter no máximo 50 caracteres");
            DomainExceptionValidation.When(materialCode.Length != 50, "O material deve ter no máximo 50 caracteres");

            ProductCode = productCode;
            MaterialCode = materialCode;

        }
    }
}

