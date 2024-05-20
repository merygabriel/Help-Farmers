using FarmerApp.Core.MapperProfiles.Common;
using FarmerApp.Core.Models.User;
using FarmerApp.Data.Entities;

namespace FarmerApp.Core.MapperProfiles.User
{
    public class UserProfile : BaseProfile<UserEntity>
    {
        public UserProfile()
        {
            CreateMap<UserModel, UserEntity>().ReverseMap();
            CreateMap<UserEntity, UserEntity>();
        }
    }
}
