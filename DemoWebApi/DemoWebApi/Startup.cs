﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(DemoWebApi.Startup))]
namespace DemoWebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}