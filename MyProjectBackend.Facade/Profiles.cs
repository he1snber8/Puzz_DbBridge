
using AutoMapper;
using MyProjectBackend.DTO;
using MyProjectBackend.Facade.Models;

namespace MyProjectBackend.Facade;

public class Profiles : Profile
{
    public Profiles()
    {
        CreateMap<User, UserModel>();
        CreateMap<UserModel, User>();
        CreateMap<Interest, InterestModel>();
        CreateMap<Match, MatchModel>();
    }
}
