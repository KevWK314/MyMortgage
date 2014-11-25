﻿using MyMortgage.RestApi.Common.Server;
using MyMortgage.RestApi.MsHttp;
using MyMortgage.RestApi.Nancy;

namespace MyMortgage.RestApi.Specflow.Test.Context
{

    public class ServiceContext
    {
        public const string BaseUri = "http://localhost:8000/mymortgage/";

        private IServiceRunner _serviceRunner;

        public void StartService()
        {
            _serviceRunner = new MsHttpServiceRunner(BaseUri);
            //_serviceRunner = new NancyServiceRunner(BaseUri);

            _serviceRunner.Start();
        }

        public void StopService()
        {
            _serviceRunner.Stop();
        }
    }
}
