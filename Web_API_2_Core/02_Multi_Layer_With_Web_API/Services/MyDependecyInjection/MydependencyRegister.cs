using Infrastructure.Implementation;
using Infrastructure.Interface;
using Microsoft.Extensions.DependencyInjection;
using Services.Implementation;
using Services.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.MyDependecyInjection
{
    public class MydependencyRegister 
    {
       
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();


            // here we can add multiple

        }
    }

}
