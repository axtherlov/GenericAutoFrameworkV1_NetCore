Feature: Acount
	Address management

Background: 
	#Given I Delete current address from account

@smoke
Scenario: Create new address
	Given I have navigated to the application
	And I see the application opened
	Then I click login link
	When I enter the username and password
	| Username                 | Password   |
	| daniel.terceros@test.com | Password1$ |
	Then I click login button
	And I click AccountName link
	And I click MyAddresses link
	And I click AddNewAddress link
	When I Fill the create address form
	| FirstName | LastName | Address    | City     | State   | PostalCode | MobilePhone | Alias     |
	| Daniel    | Terceros | 123 Street | TestCity | Alabama | 12345      | 701234147   | MyAddress |
	And I click Save button
	Then I should see the address header MyAddress displayed

