Feature: EBD-216-View-Package
	View packages flow

@testCasesFromTestBoard
Scenario: View Package
	Given Open Chrome browser
	Then Navigate to Pricing Management > Packages
	And Pick package witch you want to view  and click the button eye
	And Received Package Details screen