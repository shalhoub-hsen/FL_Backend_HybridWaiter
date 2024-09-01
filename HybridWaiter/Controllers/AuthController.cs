
using HybridWaiterServiceLayer.UIModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HybridWaiterDataLayer.Models;
using HybridWaiterServiceLayer.DTO;
using HybridWaiterServiceLayer.Services;

namespace SimpleJWT.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IConfiguration configuration;
        IClientService clientService;
        public AuthController(IConfiguration configuration, IClientService clientService)
        {
            this.configuration = configuration;
            this.clientService = clientService;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
           if (loginModel != null)
            {
                (bool, int, string) result = await clientService.IsValidClient(loginModel.Email, loginModel.Password);
                if (result.Item1)
                {
                    var claims = new List<Claim>
                    {
                        new Claim("ClientId", result.Item2.ToString())
                    };

                    var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("CJKFOGk-9E0aI8Gv09mD-8utzSyLQx_yrJKi1fXc6Y7CeYszLzcmMA2C0_Ej3K7BQdsCW9zoqW3a-5L1ZNRytFC0BeA6dZLsCjoTrFoI9guwvEmJ0gbN9yHQ0fDYbkwGUyJbP6eNEzKbWHMarSx7RWGKaGsxy0qguEMSO3OUWU8"));
                    var jwtInfo = new JwtSecurityToken(
                            issuer: "localhost",
                            audience: "audience1",
                            claims: claims,
                            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(4)),
                            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                            );
                    var Token = new JwtSecurityTokenHandler().WriteToken(jwtInfo);
                    return Ok(new LoginResult() { IsValid = true, Token = Token, Username = result.Item3 });
                }
            }

            return Ok(new LoginResult() { IsValid = false, LoginErrorMessage = "Email or Password is not correct"});
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register(Client client)
        {
            Client? clientByMail = await clientService.GetClientByMail(client.Email);

            if(clientByMail != null)
            {
                return Ok(false);
            }

            bool result = await clientService.SaveClient(client);

            return Ok(result);
        }


    }
}