Feature: EBD-211-Edit-Agreement
	Editing flow

@testCasesFromTestBoard
Scenario: Go to editing flow for Agreement
	Given Chrome browser opened
	Then Navigate to Agreements page
	And Choose your Agreement
	Then Click Edit button
	Then Edit popup is opened
	And  Change e.g. a description value
	And Click Save button
	Then An agreement with changed values is saved and correctly shown.