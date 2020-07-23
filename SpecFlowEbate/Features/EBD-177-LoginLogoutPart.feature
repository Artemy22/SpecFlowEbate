Feature: EBD-177-LoginLogoutPart
	Login / logout flow

@testCasesFromTestBoard
Scenario: Go through Login flow
	Given Open e-bate
	And Login to e-bate
	And I choose FirstTenant and click Save btn
	Then Log out of e-bate
	