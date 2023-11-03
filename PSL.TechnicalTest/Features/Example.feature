Feature: Example

Coding Ability Test
Test Designed by Victor Mayomi


Scenario: Search Functionallity Test
	Given I Navigate to bbc homepage
	And I click on searchField
	Then I should be on the SearchPAge
	When I enter Chorley in the searchfiled and click search
	Then the top five results contain 'Chorley' in the title
