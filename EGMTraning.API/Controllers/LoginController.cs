using EGMTraning.Common.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace EGMTraning.API.Controllers
{
    public class LoginController : BaseApiController
    {

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthenticationModel loginModel)
        {

            if (loginModel is null)
                return BadRequest("Invalid client Request");
            #region CreateToken

            var bytes = Encoding.UTF8.GetBytes("EgmTraningSecon2");
            SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            JwtSecurityToken token = new JwtSecurityToken
                (
                        issuer: "http://localhost",
                        audience: "http://localhost",
                        expires: DateTime.Now.AddMinutes(5),
                        signingCredentials: credentials
                );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            var tokens = handler.WriteToken(token);

            var returnModel = new AuthenticationResponseModel
            {
                Token = tokens,
                Name ="ApiCreateToken"
            };

            if (token!=null)
            {
                var data = await Task.FromResult(CustomResponseDto<AuthenticationResponseModel>.Success(200, returnModel));
                return CreateActionResult(data);
            }
            else
            {
                var data = await Task.FromResult(CustomResponseDto<AuthenticationResponseModel>.Fail(401, "not Authorize"));
                return CreateActionResult(data);
            }
            #endregion
        }
    }
}
