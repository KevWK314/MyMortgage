using System;
using MyMortgage.RestApi.MsHttp;

namespace MyMortgage.RestApi.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var runner = new MsHttpServiceRunner("http://localhost:8080/mymortgage");
            runner.Start();

            Console.WriteLine("The service is ready.");
            Console.WriteLine("Press <ENTER> to terminate service.");
            Console.WriteLine();
            Console.ReadLine();

            runner.Stop();
        }
    }
}
