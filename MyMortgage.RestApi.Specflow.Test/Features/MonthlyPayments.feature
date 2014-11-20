Feature: MonthlyPayments

Scenario: Calculate Monthly payments
	Given I have started the REST service
	When I calculate the monthly payments for
	| Principle | Rate | DurationInYears |
	| 250000    | 3    | 25              |
	Then the monthly payments should be 1185.528
