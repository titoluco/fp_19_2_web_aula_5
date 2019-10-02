using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Fiap.Api.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Fiap.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TokenController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create(TokenInfo model)
        {
            if (IsValiduserAndPassword(model))
            {
                var token = GenerateToken(model);

                return new ObjectResult(token);
            }

            return BadRequest();

        }

        private string GenerateToken(TokenInfo model)
        {
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name , model.user),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Minha chave com pelo menos 16 cara"));
            var signCredential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var header = new JwtHeader(signCredential);
            var payload = new JwtPayload(claims);
            var token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private bool IsValiduserAndPassword(TokenInfo model)
        {
            return model.user == "apiuser";
        }
    }
}