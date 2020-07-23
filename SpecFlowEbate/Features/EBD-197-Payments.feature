Feature: EBD-197-Payments
	Request payments flow

@testCasesFromTestBoard
Scenario: Request a payment
	Given Open Chrome  browser
	Then Navigate to e-bate Payments screen
	And Enter the Paeyment Description
	Then Request a payment is done
