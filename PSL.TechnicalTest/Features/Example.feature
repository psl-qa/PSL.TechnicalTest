Feature: Adding items to the basket

This feature covers the scenario of adding an item to the shopping basket


Scenario: Adding items to the basket
	Given I navigate to Amazon
	When I search for SEGA Mega Drive Mini (Electronic Games)
	And I select the SEGA Mega Drive Mini (Electronic Games)
	And I choose to add  SEGA Mega Drive Mini to the basket
	Then SEGA Mega Drive Mini is added to the basket
