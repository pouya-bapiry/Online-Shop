using Core.IRepositories;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class DIRegister
    {
        public static void AddRepositories(this IServiceCollection services)
        {

        services.AddScoped<IProductRepository,ProductRepository>();            
        
        }

        public static void AddUnitOfWork(this IServiceCollection services) 
        {
        
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
