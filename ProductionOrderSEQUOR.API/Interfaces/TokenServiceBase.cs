/* using Microsoft.IdentityModel.Tokens;
using ProductionOrderSEQUOR.API.Models;
using System.IdentityModel.Tokens.Jwt;
/* 
namespace ProductionOrderSEQUOR.API.Interfaces
{
    public class TokenServiceBase
    {

        public string CreateToken(User user)

        {
            var claims = new List<Claim>
            {
                new Claim
                (JwtRegisteredClaimNames.NameId,
                user.UserName)
            };

            var credenciais = new SigningCredentials(_chave, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}

*/