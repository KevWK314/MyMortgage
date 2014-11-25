using System;

namespace MyMortgage.RestApi.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var runnerFactory = new ServiceRunnerFactory();
            var runner = runnerFactory.CreateServiceRunner();
            runner.Start();

            Console.WriteLine("The {0} service is ready.", runner.Name);
            Console.WriteLine("Press <ENTER> to terminate service.");
            Console.WriteLine();
            Console.ReadLine();

            runner.Stop();
        }
    }
}
