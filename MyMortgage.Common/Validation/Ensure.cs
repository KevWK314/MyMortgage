using System;

namespace MyMortgage.Common.Validation
{
    public static class Ensure
    {
        public static void That(bool check, Func<Exception> exception)
        {
            if (!check)
            {
                throw exception();
            }
        }
    }
}
