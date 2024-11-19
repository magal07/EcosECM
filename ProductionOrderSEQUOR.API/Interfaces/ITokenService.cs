/* using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ProductionOrderSEQUOR.API.Models;

    */ 

/*  
namespace ProductionOrderSEQUOR.API.Interfaces
{


    public interface ITokenService
    {
        string CreateToken(User user);
    }

    public class TokenService : ITokenService


    {
        private readonly SymmetricSecurityKey _chave;
        public TokenService
        (IConfiguration config)
        {
            _chave = new SymmetricSecurityKey
                (Encoding.UTF8.GetBytes
                (config["chaveSecreta"]));
        }

        public string CreateToken(User user)

        {
            var claims = new List<Claim>
            {
                new Claim
                (JwtRegisteredClaimNames.NameId,
                user.UserName)
            };

            var credenciais = new SigningCredentials(_chave, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = credenciais,
            };
            var TokenHandler = new JwtSecurityTokenHandler();

            var token = TokenHandler.CreateToken(tokenDescriptor);
            return TokenHandler.WriteToken(token);

        }
    }

    services.AddScoped<ITokenService,TokenService>();
    services.AddAuthentication(JwtBearerDefaults.AuthenticatationScheme)
}

    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigninKey = true;
            IssuerSigningKey = new
            SymmetricSecurityKey(Encoding.UTF8.
                GetBytes(config["chaveSecreta"])),
            ValidateIssuer = false,
            ValidateAudience = false,


        };
    });

app.UseAuthentication();
                         
        

        
        /* {   
                                                          \/ Acrescentados no program.cs   

                                                         services.AddScoped<ITokenService,
                                                         TokenService>();

                                                             services.AddAuthentication(JwtBearerDefaults.
                                                             AuthenticatationScheme) }  */


/* */ 