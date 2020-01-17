Feature: Login
	As a regular user, I want to have the ability to
	log in in the application

#--------------------------------------------------------------------------------
@smoke
Scenario Outline:  Login with valid credentials
	Given I navigated to the login page
	When I Try to login with valid credentials <Username> and <Password>
	Then I should see the home page with user <LoggedUser> logged
	
	Examples: 
	| Testcase | Username                 | Password   | LoggedUser      |
	| A        | daniel.terceros@test.com | Password1$ | Daniel Terceros |
	| B        | danielt@test.com         | Password1$ | D Terceros      |

#--------------------------------------------------------------------------------
@acceptance
Scenario: Try to login with invalid credentials
	Given I navigated to the login page
	When I try to login with invalid credentials
	| Username     | Password |
	| asd@test.com | asdf1234 |
	Then I should not login the application
	And  I should see the message "Authentication failed." displayed	