Feature: PrincipleRemaining

Scenario: Calculate principle remaining
	Given I have started the REST service
	When I calculate the principle remaining for
	| Principle | Rate | DurationInYears | YearsAlreadyPaid | MonthlyPayments |
	| 250000    | 3    | 25              | 20               | 1185            |
	Then the principle remaining should be 65977.444

Scenario: Calculate principle remaining with invalid data
	Given I have started the REST service
	When I calculate the principle remaining for
	| Principle | Rate | DurationInYears | YearsAlreadyPaid | MonthlyPayments |
	| 250000    | 3    | 25              | -20              | 1185            |
	Then I should receive a principle remaining error

Scenario: Principle remaining server down error
	Given I have stopped the REST service
	When I calculate the principle remaining for
	| Principle | Rate | DurationInYears | YearsAlreadyPaid | MonthlyPayments |
	| 250000    | 3    | 25              | 20               | 1185            |
	Then I should receive a principle remaining error
