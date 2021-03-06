﻿using MyMortgage.RestApi.Specflow.Test.Context;
using TechTalk.SpecFlow;

namespace MyMortgage.RestApi.Specflow.Test.Steps
{
    [Binding]
    public class CommonSteps
    {
        private const string ServiceContext = "ServiceContext";

        [AfterFeature]
        public static void AfterFeature()
        {
            StopService();
        }

        [Given(@"I have started the REST service")]
        public void GivenIHaveStartedTheRestService()
        {
            if (!FeatureContext.Current.ContainsKey(ServiceContext))
            {
                var context = new ServiceContext();
                context.StartService();

                FeatureContext.Current[ServiceContext] = context;
            }
        }

        [Given(@"I have stopped the REST service")]
        public void GivenIHaveStoppedTheRestService()
        {
            StopService();
        }

        private static void StopService()
        {
            if (FeatureContext.Current.ContainsKey(ServiceContext))
            {
                var context = FeatureContext.Current[ServiceContext] as ServiceContext;
                if (context != null)
                {
                    context.StopService();
                    FeatureContext.Current.Remove(ServiceContext);
                }
            }
        }
    }
}
