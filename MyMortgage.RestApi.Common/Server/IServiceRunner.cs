namespace MyMortgage.RestApi.Common.Server
{
    public interface IServiceRunner
    {
        string Name { get; }

        void Start();
        void Stop();
    }
}
