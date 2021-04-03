using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet.Test.Services
{
    public interface IVipService
    {
    }

    public class ErpVipService : IVipService
    {

    }

    public class WxVipService : IVipService
    {

    }
    public class VipServiceFactory
    {
        private readonly Func<int, IVipService> _func;
        public VipServiceFactory(Func<int, IVipService> func)
        {
            _func = func;
        }
        public IVipService GetInstence(int type)
        {
            return _func(type);
        }
    }
    public static class VipServiceExtensions
    {
        public static IServiceCollection AddVipService(this IServiceCollection services)
        {
            services.AddScoped<ErpVipService>();
            services.AddScoped<WxVipService>();
            services.AddScoped(serviceProvider =>
            {
                Func<int, IVipService> func = type =>
                {
                    if (type == 0) return (IVipService)serviceProvider.GetService<ErpVipService>();
                    else
                        return (IVipService)serviceProvider.GetService<WxVipService>();
                };
                return func;
            });
            services.AddScoped<VipServiceFactory>();
            return services;
        }
    }
 

}
