Feature: ServicesAi

In order to accaess a specific AI feature 
from the EPAM website
i want to be able to slect each featur in a parameterized way

@services
Scenario Outline: validate user can access different AI articles
	Given I navigate to EPAM website
	And I accept cookies
	When I go to the services section
	And I go to the Artificial Inteligence section
	And I click the "<ServiceName>" Button
	Then I should see the page title "<ExpectedTitle>"
	And the section "Our related Expertise" should be visible in the page

	Examples: 
	| ServiceName    | ExpectedTitle  |
	| Responsible AI | Responsible AI |
	| Generative AI  | Generative AI  |
