Feature: EBD-192-Add-Documents
	Adding documents to packages, agreements, rebate

@testCasesFromTestBoard
Scenario: Add document to a package
	Given Chrome is opened
	And Navigate to Packages
	Then Choose a Package 
	And Add a document to chosen package
	Then Check if it is added to package


Scenario: Add document to an agreement
	Given Chrome is opened
	And Navigate to agreements
	Then Choose a agreement 
	And Add a document to chosen agreement
	Then Check if it is added to agreement


Scenario: Add document to a rebate
	Given Chrome is opened
	And Navigate to rebate
	Then Choose a rebate 
	And Add a document to chosen rebate
	Then Check if it is added to rebate