Feature: Address Management
	As a logged user I want to have the ability to asign new addresses to my account

Background: 
	Given I am logged in the application with any user

@smoke
Scenario: Create new address
	Given I navigated to Address creation form
	When I Fill the create address form
	| FirstName | LastName | Address    | City     | State   | PostalCode | MobilePhone | Alias     |
	| Daniel    | Terceros | 123 Street | TestCity | Alabama | 12345      | 701234147   | MyAddress |	
	Then The address should be created