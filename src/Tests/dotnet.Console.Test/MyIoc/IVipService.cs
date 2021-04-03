using System;

namespace dotnet.ConsoleTest
{
    public interface IVipService
    {
        void printf();
    }

    public class ErpVipService : IVipService
    {
        private readonly IStudentService _studentService;

        public ErpVipService(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public void printf()
        {
            _studentService.printf();
            Console.WriteLine($"{this.GetType().Name} , { this.GetHashCode()}");
        }
    }
}
