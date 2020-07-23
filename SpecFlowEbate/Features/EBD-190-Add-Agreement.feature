Feature: EBD-190-Add-Agreement
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@testCasesFromTestBoard
Scenario: Add Agreement flow
	Given Open chrome
	And  Open Package
	And Add agreement to the package
	When Save the Agreement
	Then An added agreement is presented in the grid
	And chrome is closed
