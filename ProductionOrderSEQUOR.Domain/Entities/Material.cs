using ProductionOrdersSEQUOR.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionOrdersSEQUOR.Domain.Entities
{
    public class Material
    {
        public int Id { get; private set; }
        public string MaterialCode { get; private set; } = string.Empty;

        public string MaterialDescription { get; private set; } = string.Empty;

     

        public Material(int id, string materialCode, string materialDescription)
        {
            DomainExceptionValidation.When(id < 0, "O Id do cliente deve ser positivo!");
            MaterialCode = materialCode;
            MaterialDescription = materialDescription;

            {
                Id = id;
                ValidateDomain(materialCode, MaterialDescription);
            }
        }
        public Material(string materialCode, string materialDescription) 
        { 
            ValidateDomain(materialCode, materialDescription);  
        }


        public void Update(string materialCode, string materialDescription)
        {
            ValidateDomain(materialCode, materialDescription);
        }
        public void ValidateDomain(string materialCode, string materialDescription)

        {
            DomainExceptionValidation.When(materialCode.Length != 50, "O material deve ter até no máximo 50 caracteres");
            DomainExceptionValidation.When(materialDescription.Length != 500, "Descrição máxima de 500 caracteres");

            MaterialCode = materialCode;
            MaterialDescription = materialDescription;

        }
    }
}
