Feature: EBD-214-Edit-Package
	Editing an existing package

@testCasesFromTestBoard
Scenario: Edit package
	Given Chrome browser is opened
	And I Navigate to Pricing Management > Packages
	When I pick a package to change and click the EDIT button
	Then Modify package popup appears
	And I change e.g. a description value
	When I click save button
	Then Changes saved successfully