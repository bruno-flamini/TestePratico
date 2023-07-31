using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TestePratico.Application.ViewModels;

namespace TestePratico.WebUI.API.Configurations
{
    public class GeracaoToken
    {
        public string GerarToken(UsuarioViewModel usuario)
        {
            var configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json").AddEnvironmentVariables().Build().GetRequiredSection("AppSettings");
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configurationBuilder["Secret"]);
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Nome.ToString()),
                    new Claim(ClaimTypes.Role, usuario.Funcao.ToString())
                }),

                Expires = DateTime.UtcNow.AddHours(Convert.ToInt32(configurationBuilder["ExpiracaoHoras"])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
