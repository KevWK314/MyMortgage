namespace MyMortgage.RestApi.Common.Dto
{
    public class PrincipleRemainingResponse
    {
        public double Principle
        {
            get;
            set;
        }

        public double PrincipleRemaining
        {
            get;
            set;
        }

        public double Rate
        {
            get;
            set;
        }

        public int DurationInMonths
        {
            get;
            set;
        }

        public int MonthsAlreadyPaid
        {
            get;
            set;
        }

        public double MonthlyPayment
        {
            get;
            set;
        }
    }
}
