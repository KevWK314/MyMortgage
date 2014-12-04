Feature: MainViewModel

Scenario: Application is started and server is up
	When I have started the application
	Then the MainViewModel should be
	| IsServerAvailable | ServerError | Refresh           |
	| True              |             | [CanExecute:True] |

Scenario: Application is started and server is down
	Given the mortgage server is down
	When I have started the application
	Then the MainViewModel should be
	| IsServerAvailable | ServerError                     | Refresh           |
	| False             | Unable to connect to the server | [CanExecute:True] |

Scenario: Application is started and server is down and them comes back up
	Given the mortgage server is down
	When I have started the application
	Then the MainViewModel should be
	| IsServerAvailable | ServerError                     | Refresh           |
	| False             | Unable to connect to the server | [CanExecute:True] |
	Given the mortgage server is up
	When I click refresh
	Then the MainViewModel should be
	| IsServerAvailable | ServerError | Refresh           |
	| True              |             | [CanExecute:True] |
