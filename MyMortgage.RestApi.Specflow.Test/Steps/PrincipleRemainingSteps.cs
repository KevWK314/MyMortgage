using System;
using MyMortgage.RestApi.Specflow.Test.Context;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace MyMortgage.RestApi.Specflow.Test.Steps
{
    [Binding]
    public class PrincipleRemainingSteps
    {
        public readonly ClientContext _client;

        private const string PrincipleRemaining = "PrincipleRemaining";
        private const string PrincipleRemainingError = "PrincipleRemainingError";

        public PrincipleRemainingSteps()
        {
            _client = new ClientContext();
        }

        [When(@"I calculate the principle remaining for")]
        public void WhenICalculateThePrincipleRemainingFor(Table table)
        {
            Assert.AreEqual(1, table.RowCount, "There must be 1 row of details for the mortgage");

            try
            {
                var principle = double.Parse(table.Rows[0]["Principle"]);
                var rate = double.Parse(table.Rows[0]["Rate"]);
                var durationInYears = int.Parse(table.Rows[0]["DurationInYears"]);
                var yearsAlreadyPaid = int.Parse(table.Rows[0]["YearsAlreadyPaid"]);
                var monthlyPayments = int.Parse(table.Rows[0]["MonthlyPayments"]);

                var res = _client.GetPrincipleRemaining(principle, rate, durationInYears, yearsAlreadyPaid, monthlyPayments);
                ScenarioContext.Current[PrincipleRemaining] = res;
            }
            catch (Exception ex)
            {
                ScenarioContext.Current[PrincipleRemainingError] = ex;
            }
        }

        [Then(@"the principle remaining should be (.*)")]
        public void ThenThePrincipleRemainingShouldBe(double expectedRemaining)
        {
            Assert.IsTrue(ScenarioContext.Current.ContainsKey(PrincipleRemaining), "Principle remaining expected");

            var res = (double)ScenarioContext.Current[PrincipleRemaining];
            Assert.IsTrue(Math.Abs(expectedRemaining - res) < 0.001);
        }

        [Then(@"I should receive a principle remaining error")]
        public void ThenIShouldReceiveAPrincipleRemainingError()
        {
            Assert.IsTrue(ScenarioContext.Current.ContainsKey(PrincipleRemainingError), "Monthly Payment error expected");

            var error = ScenarioContext.Current[PrincipleRemainingError] as Exception;
            Assert.IsNotNull(error);
        }
    }
}
