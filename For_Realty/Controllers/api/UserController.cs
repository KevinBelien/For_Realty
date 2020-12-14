using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using For_Realty.Entities;
using For_Realty.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using For_Realty.Areas.Identity.Data;


namespace For_Realty.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly SignInManager<AccountUser> _signInManager;
        private readonly UserManager<AccountUser> _userManager;
        private readonly AppSettings _appSettings;

        public UserController(
            UserManager<AccountUser> userManager,
            SignInManager<AccountUser> signInManager,
            IOptions<AppSettings> appSettings
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value;
        }


        [HttpPost("authenticate")]
        public async Task<object> Authenticate([FromBody] ApiUser apiUser)
        {
            Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync(
                apiUser.Username, apiUser.Password, false, false);

            if (signInResult.Succeeded)
            {
                AccountUser accountUser = _userManager.Users.SingleOrDefault(r => r.Email == apiUser.Username);
                apiUser.Token = GenerateJwtToken(apiUser.Username, accountUser).ToString();

                return apiUser;
            }

            return BadRequest(new { message = "Gebruikersnaam of wachtwoord is incorrect!" });
        }

        private string GenerateJwtToken(string email, AccountUser user)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
