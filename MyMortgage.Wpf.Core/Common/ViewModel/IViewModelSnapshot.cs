using System.Collections.Generic;

namespace MyMortgage.Wpf.Core.Common.ViewModel
{
    public interface IViewModelSnapshot
    {
        List<Dictionary<string, string>> GetSnapshot(bool full);
    }
}
