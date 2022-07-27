using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SameDayAuth.Startup))]

namespace SameDayAuth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           
            ConfigureAuth(app);
            
        }





     
    }

  
}
