using System;
using MyMortgage.Calculator.Calculator;
using MyMortgage.Calculator.Model;

namespace MyMortgage.Calculator.Builder
{
    public class MonthlyPaymentBuilder
    {
        private double? _rate;
        private double? _principle;
        private int? _durationInMonths;

        internal MonthlyPaymentBuilder()
        {
        }

        public MonthlyPaymentBuilder WithRate(double rate)
        {
            _rate = rate;
            return this;
        }

        public MonthlyPaymentBuilder WithPrinciple(double principle)
        {
            _principle = principle;
            return this;
        }

        public MonthlyPaymentBuilder WithDurationInMonths(int duration)
        {
            _durationInMonths = duration;
            return this;
        }

        public MonthlyPaymentBuilder WithDurationInYears(int duration)
        {
            _durationInMonths = duration * 12;
            return this;
        }

        public MonthlyPaymentResult Calculate()
        {
            Validate();

            var monthlyPayment = MortgageCalculations.CalculateMonthlyPayments(_principle.Value, _rate.Value, _durationInMonths.Value);
            
            return new MonthlyPaymentResult
                {
                    Principle = _principle.Value,
                    Rate = _rate.Value,
                    DurationInMonths = _durationInMonths.Value,
                    MonthlyPayment = monthlyPayment
                };
        }

        private void Validate()
        {
            if ((_principle ?? 0) <= 0)
            {
                throw new ArgumentException("Principle is invalid");
            }
            if ((_rate?? 0) <= 0)
            {
                throw new ArgumentException("Rate is invalid");
            }
            if ((_durationInMonths ?? 0) <= 0)
            {
                throw new ArgumentException("Duration is invalid");
            }
        }
    }
}
