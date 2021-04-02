using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet.Test.Services
{
    public interface IVipService
    {
    }

    public class VipService : IVipService
    {

    }

    public interface ITestService<T>
    {
        void excute();
    }

    public class TestService<T> : ITestService <T>
    {
        private readonly IVipService _vipService;

        public TestService(IVipService vipService)
        {
            _vipService = vipService;
        }

        public void excute()
        {
            Console.WriteLine($"test {typeof(T).Name}");
        }
    }


}
