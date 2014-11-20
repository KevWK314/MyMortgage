using System;
using MyMortgage.RestApi.Specflow.Test.Context;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace MyMortgage.RestApi.Specflow.Test.Steps
{
    [Binding]
    public class MonthlyPaymentSteps
    {
        public readonly ClientContext _client;

        private const string MonthlyPayments = "MonthlyPayments";

        public MonthlyPaymentSteps()
        {
            _client = new ClientContext();
        }

        [When(@"I calculate the monthly payments for")]
        public void WhenICalculateTheMonthlyPaymentsFor(Table table)
        {
            if (table.RowCount != 1)
            {
                throw new ArgumentException("There must be 1 row of details for the mortgage");
            }

            var principle = double.Parse(table.Rows[0]["Principle"]);
            var rate = double.Parse(table.Rows[0]["Rate"]);
            var durationInYears = int.Parse(table.Rows[0]["DurationInYears"]);

            var res = _client.GetMonthlyPayments(principle, rate, durationInYears);
            ScenarioContext.Current[MonthlyPayments] = res;
        }

        [Then(@"the monthly payments should be (.*)")]
        public void ThenTheMonthlyPaymentsShouldBe(double monthlyPayments)
        {
            if (!ScenarioContext.Current.ContainsKey(MonthlyPayments))
            {
                throw new InvalidOperationException("Montly Payment result expected");
            }

            var res = (double)ScenarioContext.Current[MonthlyPayments];
            Assert.IsTrue(Math.Abs(monthlyPayments - res) < 0.001);
        }
    }
}
