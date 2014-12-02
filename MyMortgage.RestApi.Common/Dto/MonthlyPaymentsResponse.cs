namespace MyMortgage.RestApi.Common.Dto
{
    public class MonthlyPaymentsResponse
    {
        public double Principle
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

        public double MonthlyPayment
        {
            get;
            set;
        }

        public double TotalPayments
        {
            get;
            set;
        }
    }
}
