Feature: Customer Service
	As I logged user I want to have the ability to contact customer service
	to send them notification about a product service or status of the web app

Background: 
Given I am logged in the application with any user

@Regular
Scenario: Create message for customer service
	Given I navigated to ContactUs form
	When I fill the contactUs form for customer service
	| SubjectHeading   | Email                    | OrderReference         | Product                                  | Message                       |
	| Customer service | daniel.terceros@test.com | ENXYOZNNS - 08/02/2019 | Printed Dress - Color : Orange, Size : S | I need help with this product |
	Then The customer service message should be sent
	And I should see the message "Your message has been successfully sent to our team." displayed