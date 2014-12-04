using System;
using System.Threading.Tasks;

namespace MyMortgage.Common.Task
{
    public static class TaskExtensions
    {
        public static void ContinueWith<T>(this Task<T> task, Action<T> resultAction, Action<Exception> errorAction)
        {
            task.ContinueWith<T>(resultAction, errorAction, null);
        }

        public static void ContinueWith<T>(this Task<T> task, Action<T> resultAction, Action<Exception> errorAction, Action finallyAction)
        {
            task.ContinueWith(t =>
            {
                try
                {
                    if (resultAction != null)
                    {
                        resultAction(t.Result);
                    }
                }
                catch (Exception ex)
                {
                    if (errorAction != null)
                    {
                        errorAction(ex);
                    }
                }
                finally
                {
                    if (finallyAction != null)
                    {
                        finallyAction();
                    }
                }
            });
        }
    }
}
