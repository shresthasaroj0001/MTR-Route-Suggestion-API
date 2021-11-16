using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using WebApplication3_Core.Model;

namespace WebApplication3_Core.Repositories
{
    public class JwtTokenManager : IJwtTokenManager
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;

        public JwtTokenManager(IConfiguration configuration, ApplicationDbContext dbContext)
        {
            _configuration = configuration;
            _context = dbContext;
        }

        public string Authenticate(string userName, string password)
        {
            //database
            var v = _context.UserCredentials.Where(userr => userr.Username == userName).FirstOrDefault();
            if(v == null)
            return null; //user not found;

            if (string.Compare(Crypto.Hash(password), v.Password) != 0)
                return null; //invalid password

            var key = _configuration.GetValue<string>("JwtConfig:Key");
            var keyBytes = Encoding.ASCII.GetBytes(key);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[] {
                new Claim(ClaimTypes.NameIdentifier, userName) }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public bool IsUserExist(string userName)
        {
            var v = _context.UserCredentials.Any(userr => userr.Username == userName);
            return v;
        }

        public async Task<GenericResponseObject<string>> Registration(UserCredential user)
        {
            GenericResponseObject<string> responseObject = new GenericResponseObject<string>();
            responseObject.IsSuccess = false;
            
            #region //email is already exist
            var isExist = IsUserExist(user.Username);
            if (isExist)
            {
                responseObject.Message = "Duplicate Username";
                return responseObject;
            }
            #endregion

            #region//password  hashing
            user.Password = Crypto.Hash(user.Password);
            #endregion

            #region save to database
            try
            {
                _context.Add(new UserCredential() { Username = user.Username, Password = user.Password });
                 await _context.SaveChangesAsync();
                responseObject.IsSuccess = true;
                responseObject.Message = "Registration Sucessfull";
            }
            catch (Exception dbEx)
            {
                responseObject.Message = "Error while saving data.";
            }
            #endregion
            return responseObject;
        }
    }
}
