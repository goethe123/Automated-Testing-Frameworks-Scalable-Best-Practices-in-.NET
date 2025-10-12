Feature: GlobalSearch Functionality

In order to find open job positions
as a user on the EPAM Website
I want to be able to search positions by keywords

@Search
Scenario Outline: Validate user can search positions
	Given I navigate to the EPAM website
	And I accept cookies if present
	When  I navigate to the Careers section
	And I search for the "<keyword>" position
	And I open the first View And Apply Button
	Then the search Results should contain "<keyword>"

	Examples: 
	| keyword |
	| java    |
	| python  |
