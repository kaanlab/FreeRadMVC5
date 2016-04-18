using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using FreeRadMVC5.Models;
using AutoMapper.Unity;
using FreeRadMVC5.ViewModels;
using FreeRadMVC5.Mapper;
using System.Data.Entity;
using System.Data;
using System.Data.Common;
using AutoMapper;


namespace FreeRadMVC5
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IMappingEngine, MappingEngine>();
            container.RegisterType<IFreeRadRepository, FreeRadRepository>();

            container.RegisterMappingProfile<GroupToGroupViewModel>();
            container.RegisterMappingProfile<UserToUserViewModel>();
            container.RegisterMappingProfile<GAtoGroupViewModel>();
            container.RegisterMappingProfile<UAtoUserViewModel>();
            container.RegisterMappingProfile<UGtoUGViewModel>();
            container.RegisterMappingProfile<NasToNasViewModel>();
            container.RegisterMapper();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}