Feature: MonthlyPayments

Scenario: Calculate Monthly payments
	Given I have started the REST service
	When I calculate the monthly payments for
	| Principle | Rate | DurationInYears |
	| 250000    | 3    | 25              |
	Then the monthly payments should be 1185.528

Scenario: Calculate Monthly payments with invalid data
	Given I have started the REST service
	When I calculate the monthly payments for
	| Principle | Rate | DurationInYears |
	| 250000    | 0    | 25              |
	Then I should receive a monthly payments error

Scenario: Monthly payments Server down error
	Given I have stopped the REST service
	When I calculate the monthly payments for
	| Principle | Rate | DurationInYears |
	| 250000    | 3    | 25              |
	Then I should receive a monthly payments error
