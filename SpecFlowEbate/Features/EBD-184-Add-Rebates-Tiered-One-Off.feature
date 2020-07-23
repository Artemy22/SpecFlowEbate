Feature: EBD-184-Add-Rebates-Tiered-One-Off
	Adding rebate flow

@mytag
Scenario: Go through adding flow
	Given I open Chrome brows.
	Then I Navigate to the test agreement
	And I Click on ADD button to add new rebate
	Then I choose Calculation Type -> Tiered One-off rebate
	And I choose Calculate Against  ->  Invoice price
	And I fill out description
	And I Choose category -> QA_Category
	And I Set Budget and Target
	And I choose Payment frequency -> Ongoing
	And I choose currency -> Pound Sterling
	When I click SAVE button
	Then Second popup is opened and I set Tier and Rebate value
	When I click on SAVE btn one more time 
	Then My rebate is presented in the Grid
