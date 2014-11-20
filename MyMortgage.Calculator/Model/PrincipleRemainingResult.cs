namespace MyMortgage.Calculator.Model
{
    public class PrincipleRemainingResult
    {
        public double Principle
        {
            get;
            internal set;
        }

        public double PrincipleRemaining
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

        public int MonthsAlreadyPaid
        {
            get;
            internal set;
        }

        public double YearsAlreadyPaid
        {
            get { return (double)MonthsAlreadyPaid / 12; }
        }

        public double MonthlyPayment
        {
            get;
            internal set;
        }

        internal PrincipleRemainingResult()
        {
        }
    }
}
