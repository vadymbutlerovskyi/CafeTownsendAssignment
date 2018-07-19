Feature: LoginSteps
	In order to login
	As a user
	I want to be able to enter valid username and password and successfully sign in

@smoke
@login
Scenario: Try to insert invalid login credentials
	Given I open browser and go to CafeTownsend home page
	Then I close browser
