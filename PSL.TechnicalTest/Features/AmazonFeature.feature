Feature: AmazonSearch

A short summary of the feature

@AddTestCaseTagForReporting
Scenario Outline: User has the ability to navigate to a product and add this to the basket
	Given the user navigates to the homepage 
	And the user searches a razor and clicks a product
	When the user adds the item to the basket
	Then the item is successfully added to the basket 
