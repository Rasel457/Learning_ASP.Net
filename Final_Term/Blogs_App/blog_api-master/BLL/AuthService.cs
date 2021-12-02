using BEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL;

namespace BLL
{
    public class AuthService
    {
        static AuthService()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<User, UserModel>();
                cfg.CreateMap<UserModel, User>();
                cfg.CreateMap<Token, TokenModel>();
                cfg.CreateMap<TokenModel, Token>();
            });
        }
        public static TokenModel Authenticate(UserModel user)
        {
            //Do the maping and call to data access
            var data = Mapper.Map<User>(user);
            var result=DataAccessFactory.AuthdataAccess().Authenticate(data);
            var token = Mapper.Map<TokenModel>(result);
            return token;
            
        }
        public static bool IsAuthenticated(string token)
        {
            var rs=DataAccessFactory.AuthdataAccess().IsAuthenticated(token);
            return rs;
        }

        public static bool Logout(string token)
        {
            return DataAccessFactory.AuthdataAccess().Logout(token);
        }
    }
}
