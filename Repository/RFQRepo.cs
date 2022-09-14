using AuthMicroservice.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthMicroservice.Repository
{
    public class RFQRepo
    {

        private readonly IConfiguration _config;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AuthRepo));
        private readonly IAuthRepo<Auth> repo;
        public RFQRepo(IConfiguration config, IAuthRepo<Auth> _repo)
        {
            _config = config;
            repo = _repo;
        }

        public string GenerateJSONWebToken(Auth userInfo)
        {
            _log4net.Info("Token Is Generated!");

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(
              issuer: _config["Jwt:Issuer"],
              audience: _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: credentials);



            return new JwtSecurityTokenHandler().WriteToken(token);


        }

        /// <summary>
        /// Finding User with matching credentials
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>

     
        public Auth AuthenticateUser(Auth login)
        {
            _log4net.Info("Validating the User!");

            //Validate the User Credentials 
            Auth usr = repo.GetRFQCred(login);


            return usr;
        }
    }
}
