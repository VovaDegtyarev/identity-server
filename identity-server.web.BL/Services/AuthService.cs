using AutoMapper;
using identity_server.web.BL.Common;
using identity_server.web.BL.Models;
using identity_server.web.DAL.Models;
using identity_server.web.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace identity_server.web.BL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;
        private readonly IHashing hashing;

        public AuthService(IRepository repository, IMapper mapper, IHashing hashing)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.hashing = hashing;
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

        public void Login(UserBL user)
        {
            var _user = mapper.Map<User>(user);
            var us = repository.GetUser(_user.Id);

            //bool isValidPassword = BCrypt.Net.BCrypt.Verify(_user.Password, u.Password);
            bool isV = hashing.isValidPassword(_user.Password, us.Hash);

            if (isV)
            {
                // TODO: token!
            } 
            else
            {
                // TODO: что-то другое
            }
        }

        public UserView UpdateUser(UserBL user)
        {
            var newUser = mapper.Map<User>(user);
            repository.UpdateUser(newUser);
            return null;
        }
    }
}
