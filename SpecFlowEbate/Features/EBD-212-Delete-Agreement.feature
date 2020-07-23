Feature: EBD-212-Delete-Agreement
	Go through deleting an agreement flow

@testCasesFromTestBoard
Scenario: Delete flow (with no rebates)
	Given Chrome is opened.
	And Navigate to Pricing Management > Agreements.
	And Pick agreement wich you want to delete
	When Click the button delete it
	Then Chosen agreement is deleted and driver closed