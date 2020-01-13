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
	And I click AcountName link
	And I click MyAddresses button
	Then I Fill the contactUs form for customer service
	| SubjectHeading  | EmailAddress             | OrderReference         | Product                                  | Message |
	| CustomerService | daniel.terceros@test.com | ENXYOZNNS - 08/02/2019 | Printed Dress - Color : Orange, Size : S | I need help with this product |
	And I click Send button
