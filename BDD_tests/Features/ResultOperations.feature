Feature: Result Operations

Scenario: Result of name is validated and retrieved successfully
	When Result validation of name is requested for "Nikita"
	Then Result is validated successfully and returned