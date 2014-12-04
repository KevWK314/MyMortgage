using System.Linq;

using MyMortgage.Wpf.Core.Common.ViewModel;

using NUnit.Framework;

using TechTalk.SpecFlow;

namespace MyMortgage.Wpf.Specflow.Test.Steps
{
    public static class StepExtensions
    {
        public static Table ToTable(this ViewModelBase vm)
        {
            var snapshot = vm.GetSnapshot(false);
            var table = new Table(snapshot.Keys.Where(k => !string.IsNullOrEmpty(k)).ToArray());
            table.AddRow(snapshot);
            return table;
        }

        public static void CompareTo(this Table expected, Table actual)
        {
            var result = expected != null && actual != null
                && expected.Header.Count == actual.Header.Count
                && expected.Header.SequenceEqual(actual.Header)
                && expected.RowCount == actual.RowCount; ;
            if (result)
            {
                for (int loop = 0; loop < expected.RowCount; loop++)
                {
                    result &= expected.Rows[loop].SequenceEqual(actual.Rows[loop]);
                }
            }

            Assert.IsTrue(result, "Invalid data:\n{0}", actual);
        }

    }
}
