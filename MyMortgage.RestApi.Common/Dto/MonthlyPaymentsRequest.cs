namespace MyMortgage.RestApi.Common.Dto
{
    public class MonthlyPaymentsRequest
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
    }
}
