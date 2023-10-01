Feature: Product Search

Product search related functionality is covered in the below scenarios

Scenario Outline: Filter products by max price
	Given I navigate to Amazon
	When I search for <product>
	And I filter results with a maximum price of <maxPrice>
	Then All the results returned have a maximum price of <maxPrice>
	Examples: 
	| product        | maxPrice |
	| "toys"         | "50"       |
	| "laptops"      | "500"      |
	| "sports watch" | "100"      |