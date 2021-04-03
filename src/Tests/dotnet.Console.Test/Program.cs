using System;

namespace dotnet.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            MyIoc.Add<IVipService, ErpVipService>();
            MyIoc.Add<ITestService, TestService>();
            MyIoc.Add<IStudentService, StudentService>();

            var itestService = MyIoc.GetService<ITestService>();
            itestService.printf();

            Console.ReadLine();

        }
    }

   
}
