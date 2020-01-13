Feature: ContactUs
	Allow to contact customers to customer service for question about products
	and also send reports about possible problems. The message can include attachments

@smoke
Scenario: Create message for customer service
	Given I have navigated to the application
	And I see the application opened
	Then I click login link
	When I enter the username and password
	| Username                 | Password   |
	| daniel.terceros@test.com | Password1$ |
	Then I click login button
	And I click ContactUs link
	Then I Fill the contactUs form for customer service
	| SubjectHeading  | EmailAddress             | OrderReference         | Product                                  | Message |
	| Customer service | daniel.terceros@test.com | ENXYOZNNS - 08/02/2019 | Printed Dress - Color : Orange, Size : S | I need help with this product |
	And I click Send button
