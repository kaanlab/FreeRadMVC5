using AutoMapper;
using FreeRadMVC5.Models;
using FreeRadMVC5.ViewModels;
using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FreeRadMVC5
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // adds all the dependency resolvers for MySql classes
            DbConfiguration.SetConfiguration(new MySqlEFConfiguration());

            // Unity.MV5 DI
            UnityConfig.RegisterComponents();

            // Automapper for ViewModel
                       
            //Mapper.Initialize(config => 
                //config.CreateMap<User, UserViewModel>().ReverseMap();
                //config.CreateMap<UserAttribute, UserViewModel>().ReverseMap();
                //config.CreateMap<Group, GroupViewModel>().ReverseMap();
                //config.CreateMap<GroupAttribute, GroupAttributeViewModel>().ReverseMap();
            //);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
