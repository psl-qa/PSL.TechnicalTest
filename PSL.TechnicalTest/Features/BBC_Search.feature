Feature: BBC_Search

@search
Scenario: Verify search results
	Given the user is on bbc news website
	When the user click on search
	And the user enters search term as Chorley
	And click on search button
	Then the user can see search results related to Chorley

@search
Scenario: Verify first five search results showing search term
	Given the user is on bbc news website
	When the user click on search
	And the user enters search term as Chorley
	And click on search button
	Then the user can verify results related to Chorley on the search page
