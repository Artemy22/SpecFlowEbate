Feature: EBD-184-Add-Rebates-Standard-Perc-of-Turnover
	Add a rebate flow

@testCasesFromTestBoard
Scenario: Add Standard % of Turnover rebate
	Given I open  Chrome
	Then Navigate  to test agreement
	And Click  on ADD  button to add new rebate
	Then I choose  Calculation Type -> Standard % of Turnover
	And I choose  Calculate Against -> Invoice price
	And I  fill out some description
	And I  Choose Category -> QA_Category
	And Set  Budget and Target
	And I  choose Payment Frequency -> Ongoing
	And I  choose Currency -> Pound Sterling
	When I  click on SAVE button
	Then Second  popup is opened and I set Percentage
	When I  click on SAVE button one more time 
	Then My  rebate is presented in Grid