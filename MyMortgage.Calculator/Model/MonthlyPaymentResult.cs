namespace MyMortgage.Calculator.Model
{
    public class MonthlyPaymentResult
    {
        public double Principle
        {
            get;
            internal set;
        }

        public double Rate
        {
            get;
            internal set;
        }

        public int DurationInMonths
        {
            get;
            internal set;
        }

        public double DurationInYears
        {
            get { return (double)DurationInMonths / 12; }
        }

        public double MonthlyPayment
        {
            get;
            internal set;
        }

        public double TotalPayments
        {
            get { return MonthlyPayment * DurationInMonths; }
        }

        internal MonthlyPaymentResult()
        {
        }
    }
}
