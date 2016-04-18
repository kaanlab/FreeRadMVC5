using AutoMapper;
using FreeRadMVC5.Models;
using FreeRadMVC5.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeRadMVC5.Mapper
{
    public class UAtoUserViewModel : Profile
    {
        protected override void Configure()
        {
            CreateMap<UserAttribute, UserViewModel>().ReverseMap();
        }
    }
}