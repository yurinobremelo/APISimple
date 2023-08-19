using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Commands;
using Application.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() {
            CreateMap<UserGetByIdViewModel, User>();
            CreateMap<User, UserGetByIdViewModel>();
            CreateMap<UserGetAllViewModel, User>();
            CreateMap<User,UserGetAllViewModel>();
            CreateMap<UserModifyViewModel,User>();
            CreateMap<User, UserModifyViewModel>();
            CreateMap<UserModifyCommand, User>();
            CreateMap<User,UserModifyCommand>();

        }
    }
}
