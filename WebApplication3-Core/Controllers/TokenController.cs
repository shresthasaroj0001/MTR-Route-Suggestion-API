using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3_Core.Model;
using WebApplication3_Core.Repositories;

namespace WebApplication3_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IJwtTokenManager _tokenManager;

        public TokenController(IJwtTokenManager tokenManager)
        {
            _tokenManager = tokenManager;
        }

        [Route("/api/token/authenticate")]
        public IActionResult Authenticate([FromQuery] UserCredential userCredential)
        {
            GenericResponseObject<string> responseObject = new GenericResponseObject<string>();
            if(string.IsNullOrEmpty(userCredential.Username) || string.IsNullOrEmpty(userCredential.Username))
            {
                responseObject.IsSuccess = false;
                responseObject.Message = "Invalid Username and password";
                return Ok(responseObject);
            }

            var token = _tokenManager.Authenticate(userCredential.Username, userCredential.Password);
            if (string.IsNullOrEmpty(token))
            {
                responseObject.IsSuccess = false;
                responseObject.Message = "Username and password doesnot match";
            }
            else
            {
                responseObject.IsSuccess = true;
                responseObject.Data = token;
                responseObject.Message = "Username and password match";
            }
            return Ok(responseObject);
        }

        [Route("/api/user/register")]
        public async Task<IActionResult> UserRegistration([FromQuery] UserCredential user)
        {
            GenericResponseObject<string> responseObject = new GenericResponseObject<string>();
            responseObject.IsSuccess = false;

            //model validation
            if (ModelState.IsValid)
                responseObject = await _tokenManager.Registration(user);
            else
                responseObject.Message = "Model state is not valid";
            return Ok(responseObject);
        }
    }
}
