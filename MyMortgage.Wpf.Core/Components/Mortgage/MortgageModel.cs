namespace MyMortgage.Wpf.Core.Components.Mortgage.Model
{
    public class MortgageDetails
    {
        public double? Principle
        {
            get;
            set;
        }

        public double? Rate
        {
            get;
            set;
        }

        public int? DurationInYears
        {
            get;
            set;
        }

        public double? MonthlyPayment
        {
            get;
            set;
        }

        public double? TotalPayment
        {
            get;
            set;
        }
    }
}
