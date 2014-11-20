MyMortgage
==========

This is a project used as a testing ground for numerous techs and libraries. It revolves around a couple of very simple calculations for Mortgages.

Running the REST Service
------------------------

To Run the self hosted WCF Rest service you'll have to give yourself permission:
netsh http add urlacl url=http://+:8000/mymortgage user=DOMAIN\user
(Details here: http://msdn.microsoft.com/en-us/library/ms733768.aspx)