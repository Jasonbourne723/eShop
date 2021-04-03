using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet.Test.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace dotnet.Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly VipServiceFactory _vipServiceFactory;

        public WeatherForecastController( VipServiceFactory vipServiceFactory)
        {
            _vipServiceFactory = vipServiceFactory;
        }

        [HttpGet]
        public string Get( )
        {
          return   _vipServiceFactory.GetInstence(0).GetHashCode().ToString();
        }
    }



    public class student
    {
        /// <summary>
        /// id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
    }
}
