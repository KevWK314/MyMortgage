using System;

namespace MyMortgage.Common.Validation
{
    public static class Guard
    {
        public static void Ensure(bool check, Func<Exception> exception)
        {
            if (!check)
            {
                throw exception();
            }
        }
    }
}
