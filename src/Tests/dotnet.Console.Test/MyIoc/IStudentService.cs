using System;

namespace dotnet.ConsoleTest
{
    public interface IStudentService
    {
        void printf();
    }

    public class StudentService : IStudentService
    {
        public void printf()
        {
            Console.WriteLine($"{this.GetType().Name} , { this.GetHashCode()}");
        }
    }
}
