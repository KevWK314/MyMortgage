using MyMortgage.Calculator.Builder;

namespace MyMortgage.Calculator
{
    public static class Mortgage
    {
        public static MonthlyPaymentBuilder WhatDoIPayPerMonth()
        {
            return new MonthlyPaymentBuilder();
        }

        public static PrincipleRemainingBuilder HowMuchIsLeftToPay()
        {
            return new PrincipleRemainingBuilder();
        }
    }
}
