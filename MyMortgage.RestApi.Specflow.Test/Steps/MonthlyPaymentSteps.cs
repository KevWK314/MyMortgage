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
        private const string MonthlyPaymentsError = "MonthlyPaymentsError";

        public MonthlyPaymentSteps()
        {
            _client = new ClientContext();
        }

        [When(@"I calculate the monthly payments for")]
        public void WhenICalculateTheMonthlyPaymentsFor(Table table)
        {
            Assert.AreEqual(1, table.RowCount, "There must be 1 row of details for the mortgage");

            try
            {
                var principle = double.Parse(table.Rows[0]["Principle"]);
                var rate = double.Parse(table.Rows[0]["Rate"]);
                var durationInYears = int.Parse(table.Rows[0]["DurationInYears"]);

                var res = _client.GetMonthlyPayments(principle, rate, durationInYears);
                ScenarioContext.Current[MonthlyPayments] = res;
            }
            catch (Exception ex)
            {
                ScenarioContext.Current[MonthlyPaymentsError] = ex;
            }
        }

        [Then(@"the monthly payments should be (.*)")]
        public void ThenTheMonthlyPaymentsShouldBe(double monthlyPayments)
        {
            Assert.IsTrue(ScenarioContext.Current.ContainsKey(MonthlyPayments), "Monthly Payment expected");

            var res = (double)ScenarioContext.Current[MonthlyPayments];
            Assert.IsTrue(Math.Abs(monthlyPayments - res) < 0.001);
        }

        [Then(@"I should receive a monthly payments error")]
        public void ThenIShouldReceiveAMonthlyPaymentsError()
        {
            Assert.IsTrue(ScenarioContext.Current.ContainsKey(MonthlyPaymentsError), "Monthly Payment error expected");

            var error = ScenarioContext.Current[MonthlyPaymentsError] as Exception;
            Assert.IsNotNull(error);
        }
    }
}
