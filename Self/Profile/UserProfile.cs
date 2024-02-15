using Self.DTO;
using AutoMapper;
using Self.Entity;

namespace Self.Profiles
{
        public class UserProfile : AutoMapper.Profile
        {
            public UserProfile()
            {
                CreateMap<User, UserDTO>();
                CreateMap<UserDTO, User>();
            }
        }
}
