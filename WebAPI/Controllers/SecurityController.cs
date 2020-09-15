using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        // GET: api/Security
        [HttpGet]
        public string Get(string name)
        {
            return GenerateJSONWebToken(name);
        }

        // POST: api/Security
        [HttpPost]
        public IActionResult Post([FromBody] string name)
        {
            if (name.Equals("issuer"))
            {
                string token = GenerateJSONWebToken(name);
                return Ok(token);
            }
            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized);
            }
        }

        // PUT: api/Security/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }

        private string GenerateJSONWebToken(string x)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("myKeyforjwtdemopurposeonfriday"));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim("Issuer","issuer"),
                new Claim("Admin", "true"),
                new Claim(JwtRegisteredClaimNames.UniqueName, x)
            };
            var token = new JwtSecurityToken("issuer", "aissuer", claims, expires: DateTime.Now.AddMinutes(20), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}













