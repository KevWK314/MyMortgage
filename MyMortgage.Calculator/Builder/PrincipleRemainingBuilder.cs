using System;
using MyMortgage.Calculator.Calculator;
using MyMortgage.Calculator.Model;

namespace MyMortgage.Calculator.Builder
{
    public class PrincipleRemainingBuilder
    {
        private double? _rate;
        private double? _principle;
        private double? _monthlyPayment;
        private int? _durationInMonths;
        private int? _monthsAlreadyPaid;

        internal PrincipleRemainingBuilder()
        {
        }

        public PrincipleRemainingBuilder WithRate(double rate)
        {
            _rate = rate;
            return this;
        }

        public PrincipleRemainingBuilder WithPrinciple(double principle)
        {
            _principle = principle;
            return this;
        }

        public PrincipleRemainingBuilder WithDurationInMonths(int duration)
        {
            _durationInMonths = duration;
            return this;
        }

        public PrincipleRemainingBuilder WithDurationInYears(int duration)
        {
            _durationInMonths = duration * 12;
            return this;
        }

        public PrincipleRemainingBuilder WithMonthlyPaymentsOf(double monthlyPayment)
        {
            _monthlyPayment = monthlyPayment;
            return this;
        }

        public PrincipleRemainingBuilder WithMonthsAlreadyPaid(int monthsAlreadyPaid)
        {
            _monthsAlreadyPaid = monthsAlreadyPaid;
            return this;
        }

        public PrincipleRemainingBuilder WithYearsAlreadyPaid(int yearsAlreadyPaid)
        {
            _monthsAlreadyPaid = yearsAlreadyPaid * 12;
            return this;
        }

        public PrincipleRemainingResult Calculate()
        {
            Validate();

            var remaining = MortgageCalculations.CalculateRemaining(
                _principle.Value, 
                _rate.Value, 
                _durationInMonths.Value,
                _monthsAlreadyPaid.Value, 
                _monthlyPayment.Value);

            return new PrincipleRemainingResult
                {
                    Principle = _principle.Value,
                    Rate = _rate.Value,
                    DurationInMonths = _durationInMonths.Value,
                    MonthlyPayment = _monthlyPayment.Value,
                    MonthsAlreadyPaid = _monthsAlreadyPaid.Value,
                    PrincipleRemaining = remaining
                };
        }

        private void Validate()
        {
            if ((_principle ?? 0) <= 0)
            {
                throw new ArgumentException("Principle is invalid");
            }
            if ((_rate ?? 0) <= 0)
            {
                throw new ArgumentException("Rate is invalid");
            }
            if ((_durationInMonths ?? 0) <= 0)
            {
                throw new ArgumentException("Duration is invalid");
            }
            if ((_monthlyPayment ?? 0) <= 0)
            {
                throw new ArgumentException("Monthly payment is invalid");
            }
            if ((_monthsAlreadyPaid ?? 0) <= 0)
            {
                throw new ArgumentException("Months passed is invalid");
            }
        }
    }
}
