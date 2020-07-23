Feature: EBD-204-Copy-Package-To-Another-Client
	Copy package flow

@testCasesFromTestBoard
Scenario: Copy package
	Given Chrome opened
	When I navigate to Pricing Management > Packages
	And I pick test package for copying
	And I Click on COPY button
	When Copy popup is opened
	And I enter all required data and click on COPY button
	Then Copied package is presented in grid