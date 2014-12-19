MyMortgage
==========

This is a project used as a testing ground for numerous techs and libraries. It revolves around a couple of very simple calculations for Mortgages. It uses a REST service (written with both WCF and Nancy) and a WPF UI. It's a simple implementation but uses a number of technologies / libraries that have been fun to play with.

I've added a lot of testing to the solution to show the wonders of Specflow and BDD testing. There is room for improvement but I think it shows the approach well enough.

Running the REST Service
------------------------

To Run the self hosted WCF Rest service you'll have to give yourself permission:
netsh http add urlacl url=http://+:8000/mymortgage user=DOMAIN\user
(Details here: http://msdn.microsoft.com/en-us/library/ms733768.aspx)

You can switch between WCF and Nancy by configuring ServiceType in app.config (MsHttp and Nancy respectively). This goes for both the MyMortgage.RestApi.Runner project and MyMortgage.RestApi.Specflow.Test.

Packages
--------
- Microsoft HTTP Client Libraries : Create the Rest Api service
- Nancy: Create the other Rest Api service
- NewtonSoft.Json: Json serialization and deserialization
- Ninject: Used as the IOC container in the UI project
- WPFThemes.DarkBlend: for themeing of the UI
- NUnit: for testing
- Specflow: for testing