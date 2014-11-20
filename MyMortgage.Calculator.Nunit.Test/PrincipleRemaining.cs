using System;
using NUnit.Framework;

namespace MyMortgage.Calculator.Nunit.Test
{
    [TestFixture]
    public class PrincipleRemaining
    {
        [TestCase(new object[] { 125000, 3, 9, 3, 1322.117, 87017.622 })]
        [TestCase(new object[] { 250000, 4, 25, 22, 1319.592, 44695.595 })]
        [TestCase(new object[] { 5232567, 6, 30, 18, 31371.882, 3214825.645 })]
        public void PrincipleRemainingShouldBeCalculated(double principle, double rate,
            int durationInYears, int yearsAlreadyPaid, double monthlyPayment, double expectedRemaining)
        {
            var remaining = Mortgage
                .HowMuchIsLeftToPay()
                .WithPrinciple(principle)
                .WithRate(rate)
                .WithDurationInYears(durationInYears)
                .WithYearsAlreadyPaid(yearsAlreadyPaid)
                .WithMonthlyPaymentsOf(monthlyPayment)
                .Calculate();

            Assert.AreEqual(principle, remaining.Principle);
            Assert.AreEqual(rate, remaining.Rate);
            Assert.AreEqual(durationInYears, remaining.DurationInYears);
            Assert.AreEqual(durationInYears * 12, remaining.DurationInMonths);
            Assert.AreEqual(yearsAlreadyPaid, remaining.YearsAlreadyPaid);
            Assert.AreEqual(yearsAlreadyPaid * 12, remaining.MonthsAlreadyPaid);
            Assert.AreEqual(monthlyPayment, remaining.MonthlyPayment);
            Assert.IsTrue(Math.Abs(expectedRemaining - remaining.PrincipleRemaining) < 0.001);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void MonthlyPaymentsShouldFailWithNoPrinciple()
        {
            var remaining = Mortgage
                .HowMuchIsLeftToPay()
                .WithRate(3)
                .WithDurationInYears(25)
                .WithYearsAlreadyPaid(19)
                .WithMonthlyPaymentsOf(1855)
                .Calculate();
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void MonthlyPaymentsShouldFailWithNoRate()
        {
            var remaining = Mortgage
                .HowMuchIsLeftToPay()
                .WithPrinciple(250000)
                .WithDurationInYears(25)
                .WithYearsAlreadyPaid(19)
                .WithMonthlyPaymentsOf(1855)
                .Calculate();
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void MonthlyPaymentsShouldFailWithNoDuration()
        {
            var remaining = Mortgage
                .HowMuchIsLeftToPay()
                .WithPrinciple(250000)
                .WithRate(3)
                .WithYearsAlreadyPaid(19)
                .WithMonthlyPaymentsOf(1855)
                .Calculate();
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void MonthlyPaymentsShouldFailWithNoAlreadyPaid()
        {
            var remaining = Mortgage
                .HowMuchIsLeftToPay()
                .WithPrinciple(250000)
                .WithRate(3)
                .WithDurationInYears(25)
                .WithMonthlyPaymentsOf(1855)
                .Calculate();
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void MonthlyPaymentsShouldFailWithNoMonthlyPayment()
        {
            var remaining = Mortgage
                .HowMuchIsLeftToPay()
                .WithPrinciple(250000)
                .WithRate(3)
                .WithDurationInYears(25)
                .WithYearsAlreadyPaid(19)
                .Calculate();
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void MonthlyPaymentsShouldFailWithInvalidPrinciple()
        {
            var remaining = Mortgage
                .HowMuchIsLeftToPay()
                .WithPrinciple(-250000)
                .WithRate(3)
                .WithDurationInYears(25)
                .WithYearsAlreadyPaid(19)
                .WithMonthlyPaymentsOf(1855)
                .Calculate();
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void MonthlyPaymentsShouldFailWithInvalidRate()
        {
            var remaining = Mortgage
                .HowMuchIsLeftToPay()
                .WithPrinciple(250000)
                .WithRate(0)
                .WithDurationInYears(25)
                .WithYearsAlreadyPaid(19)
                .WithMonthlyPaymentsOf(1855)
                .Calculate();
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void MonthlyPaymentsShouldFailWithInvalidDuration()
        {
            var remaining = Mortgage
                .HowMuchIsLeftToPay()
                .WithPrinciple(250000)
                .WithRate(3)
                .WithDurationInYears(0)
                .WithYearsAlreadyPaid(19)
                .WithMonthlyPaymentsOf(1855)
                .Calculate();
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void MonthlyPaymentsShouldFailWithInvalidAlreadyPaid()
        {
            var remaining = Mortgage
                .HowMuchIsLeftToPay()
                .WithPrinciple(250000)
                .WithRate(3)
                .WithDurationInYears(25)
                .WithYearsAlreadyPaid(-19)
                .WithMonthlyPaymentsOf(1855)
                .Calculate();
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void MonthlyPaymentsShouldFailWithInvalidMonthlyPayment()
        {
            var remaining = Mortgage
                .HowMuchIsLeftToPay()
                .WithPrinciple(250000)
                .WithRate(3)
                .WithDurationInYears(25)
                .WithYearsAlreadyPaid(19)
                .WithMonthlyPaymentsOf(-1855)
                .Calculate();
        }
    }
}
