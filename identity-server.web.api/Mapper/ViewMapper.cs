using AutoMapper;
using identity_server.web.api.Models;
using identity_server.web.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace identity_server.web.api.Mapper
{
    public class ViewMapper : Profile
    {
        public ViewMapper()
        {
            CreateMap<UserData, UserBL>();
        }

        
    }
}
