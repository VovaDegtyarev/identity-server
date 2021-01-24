using AutoMapper;
using identity_server.web.BL.Models;
using identity_server.web.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace identity_server.web.BL.Mapper
{
    public class ViewMapper : Profile
    {
        public ViewMapper()
        {
            CreateMap<UserBL, User>();
            CreateMap<User, UserBL>();
            CreateMap<User, UserView>();
        }
    }
}
