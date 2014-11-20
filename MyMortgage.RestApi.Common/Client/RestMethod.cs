namespace MyMortgage.RestApi.Common.Client
{
    public class RestMethod
    {
        public static readonly RestMethod Get = new RestMethod("GET");
        public static readonly RestMethod Post = new RestMethod("POST");

        public string Method
        {
            get;
            private set;
        }

        private RestMethod(string method)
        {
            Method = method;
        }
    }
}
