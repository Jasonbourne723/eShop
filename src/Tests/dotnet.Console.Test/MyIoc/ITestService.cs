using System;

namespace dotnet.ConsoleTest
{
    public interface ITestService
    {
        void printf();
    }

    public class TestService : ITestService
    {
        private readonly IVipService _vipService;
        private readonly IStudentService _studentService;

        public TestService(IVipService vipService)
        {
            _vipService = vipService;
        }

        public TestService(IVipService vipService, IStudentService studentService)
        {
            _vipService = vipService;
            _studentService = studentService;
        }

        public void printf()
        {
            _vipService.printf();
            _studentService.printf();
            Console.WriteLine($"{this.GetType().Name} , { this.GetHashCode()}");
        }
    }
}
