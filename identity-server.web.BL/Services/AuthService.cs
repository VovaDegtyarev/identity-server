using AutoMapper;
using identity_server.web.BL.Common;
using identity_server.web.BL.Models;
using identity_server.web.DAL.Models;
using identity_server.web.DAL.Repository;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace identity_server.web.BL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;
        private readonly IHashing hashing;
        private readonly IOptions<AuthOptions> authOptions;

        public AuthService(IRepository repository, IMapper mapper, IHashing hashing, IOptions<AuthOptions> authOptions)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.hashing = hashing;
            this.authOptions = authOptions;
        }

        public void AddUser(UserBL user)
        {
            var _user = mapper.Map<User>(user);

            _user.Id = Guid.NewGuid();

            _user.Hash = hashing.GetHashFromPassword(_user.Password);
            //_user.Password = "emptyPassword";

            repository.AddUser(_user);
        }

        public void DeleteUser(Guid id)
        {
            repository.DeleteUser(id);
        }

        public UserView GetUser(Guid id)
        {
            var user = repository.GetUser(id);
            var _user = mapper.Map<UserView>(user);

            return _user;
        }

        public UserView GetUsers()
        {
            var list = repository.GetUsers();
            var listOfUsers = mapper.Map<UserView>(list);

            return listOfUsers;
        }

        public string Login(UserBL user)
        {
            var _user = mapper.Map<User>(user);
            var us = repository.GetUser(_user.Id);

            //bool isValidPassword = BCrypt.Net.BCrypt.Verify(_user.Password, u.Password);
            bool isPasswordValid = hashing.isValidPassword(_user.Password, us.Hash);

            if (isPasswordValid)
            {
                // TODO: token!
                var token = GenerateJWT(us);
                return token;
            } 
            else
            {
                return null;
                // TODO: что-то другое
            }
        }

        public UserView UpdateUser(UserBL user)
        {
            var newUser = mapper.Map<User>(user);
            repository.UpdateUser(newUser);
            return null;
        }


        private string GenerateJWT(User user)
        {
            var authParams = authOptions.Value;

            var securityKey = authParams.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim("role", user.Role.ToString())
            };

            var token = new JwtSecurityToken(authParams.Issuer, authParams.Audience, claims, expires: DateTime.Now.AddSeconds(authParams.TokenLifeTime), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
