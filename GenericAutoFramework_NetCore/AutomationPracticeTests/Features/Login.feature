Feature: Login
	Check if the login functionality is working
	as expected with different permutations and
	combinations of data

Background: 
	#Given I Delete employee 'AutoUser' before I start running test

@smoke @positive
Scenario: Check Login with correct username and password
	Given I have navigated to the application
	And I see the application opened
	Then I click login link
	When I enter the username and password
	| Username                 | Password   |
	| daniel.terceros@test.com | Password1$ |
	Then I click login button
	Then I should see the home page with user logged