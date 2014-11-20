using System;
using NUnit.Framework;

namespace MyMortgage.Calculator.Nunit.Test
{
    [TestFixture]
    public class MonthlyPayments
    {
        [TestCase(new object[] { 125000, 3, 9, 1322.117 })]
        [TestCase(new object[] { 250000, 4, 25, 1319.592 })]
        [TestCase(new object[] { 5232567, 6, 30, 31371.882 })]
        public void MonthlyPaymentsShouldBeCalculated(double principle, double rate, int durationInYears, double expectedMonthlyPayments)
        {
            var payments = Mortgage.WhatDoIPayPerMonth()
                .WithPrinciple(principle)
                .WithRate(rate)
                .WithDurationInYears(durationInYears)
                .Calculate();

            Assert.AreEqual(principle, payments.Principle);
            Assert.AreEqual(rate, payments.Rate);
            Assert.AreEqual(durationInYears, payments.DurationInYears);
            Assert.AreEqual(durationInYears * 12, payments.DurationInMonths);
            Assert.IsTrue(Math.Abs(expectedMonthlyPayments - payments.MonthlyPayment) < 0.001);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void MonthlyPaymentsShouldFailWithNoPrinciple()
        {
            var payments = Mortgage.WhatDoIPayPerMonth()
                .WithRate(3)
                .WithDurationInYears(25)
                .Calculate();
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void MonthlyPaymentsShouldFailWithNoRate()
        {
            var payments = Mortgage.WhatDoIPayPerMonth()
                .WithPrinciple(250000)
                .WithDurationInYears(25)
                .Calculate();
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void MonthlyPaymentsShouldFailWithNoDuration()
        {
            var payments = Mortgage.WhatDoIPayPerMonth()
                .WithPrinciple(250000)
                .WithRate(3)
                .Calculate();
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void MonthlyPaymentsShouldFailWithInvalidPrinciple()
        {
            var payments = Mortgage.WhatDoIPayPerMonth()
                .WithPrinciple(-250000)
                .WithRate(3)
                .WithDurationInYears(25)
                .Calculate();
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void MonthlyPaymentsShouldFailWithInvalidRate()
        {
            var payments = Mortgage.WhatDoIPayPerMonth()
                .WithPrinciple(250000)
                .WithRate(-3)
                .WithDurationInYears(25)
                .Calculate();
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void MonthlyPaymentsShouldFailWithInvalidDuration()
        {
            var payments = Mortgage.WhatDoIPayPerMonth()
                .WithPrinciple(250000)
                .WithRate(3)
                .WithDurationInYears(-25)
                .Calculate();
        }
    }
}
