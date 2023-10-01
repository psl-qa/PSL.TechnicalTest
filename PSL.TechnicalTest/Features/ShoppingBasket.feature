Feature: Shopping basket

This feature covers the correct working of the shopping basket


Scenario: Adding items to the basket
	Given I navigate to Amazon
	When I search for SEGA Mega Drive Mini (Electronic Games)
	And I select the SEGA Mega Drive Mini (Electronic Games)
	And I choose to add  SEGA Mega Drive Mini to the basket
	Then SEGA Mega Drive Mini is added to the basket

Scenario: Removing items from the basket
	Given I navigate to Amazon
	When I search for SEGA Mega Drive Mini (Electronic Games)
	And I select the SEGA Mega Drive Mini (Electronic Games)
	And I choose to add  SEGA Mega Drive Mini to the basket
	And I click the button to delete that item from the basket	
	Then The item is effectively removed from the basked



