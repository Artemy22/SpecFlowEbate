Feature: EBD-184-Add-Rebates-Product-Level-Value
	Add a rebate flow

@testCasesFromTestBoard
Scenario: Add Rebate Product Level Value
	Given I open Chrome br 
	Then I Navigate to test agreement
	And I Click on ADD  button to add new rebate
	Then I choose Calculation Type -> Product Level Value
	And I choose Calculate Against ->  Invoice price
	And I fill out some  description
	And I Choose Category ->  QA_Category
	And Set Budget  and Target
	And I choose Payment  Frequency -> Ongoing
	And I choose Currency  -> Pound Sterling
	And I click  on SAVE button
	Then I choose the rebate and open it
	And Click on Rates tab
	And Choose product from appropiate dropdown
	And Set Effective From date
	And Set Min Qty
	And Set Value
	Then I click on ADD configured rate button
	And My rate is presented in grid
