Feature: EBD-195-Criteria
	Set criteria

@testCasesFromTestBoard
Scenario: Add Criteria
	Given Open up the Package Screen
	Then Go the Tab criteria
	And Click on the Add criteria button
	Then Add Criteria
	And Go to the Agreement in the Package check if the same criteria was added on the Agreement
	Then Click on the rebate within same Package/Agreement check if the same criteria is displayed on the Rebate Criteria Tab
	And On the Rebate Screen deselect one criteria ( for exemple if you have selected four Product Codes deselect one
	Then Go to the Rebate tab and check if the Accruals were recalculated according to the deselected criteria