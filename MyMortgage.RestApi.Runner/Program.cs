using System;

namespace MyMortgage.RestApi.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var runnerFactory = new ServiceRunnerFactory("http://localhost:8000/mymortgage/");
            var runner = runnerFactory.CreateServiceRunner();
            runner.Start();

            Console.WriteLine("The service is ready.");
            Console.WriteLine("Press <ENTER> to terminate service.");
            Console.WriteLine();
            Console.ReadLine();

            runner.Stop();
        }
    }
}
