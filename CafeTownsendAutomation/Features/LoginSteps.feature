Feature: LoginSteps
	In order to login
	As a user
	I want to be able to enter valid username and password and successfully sign in

@smoke
@login
Scenario: Try to insert invalid login credentials
	Given I open browser and go to CafeTownsend home page
	#The step below to be replaced by wait for !!!!!!!!!!!!
	Then I wait for '3' second(s)
	When I click on the Login button
	Then I see that 'username' field is required to be filled
		And I enter 'Invalid' into the 'username' field
	When I click on the Login button
	Then I see that 'password' field is required to be filled
		And I enter 'Invalid' into the 'password' field
	When I click on the Login button
	Then I see the error message 'Invalid username or password!'
	#The step below will also validate if the field's frame turned red and the exclamation icon is present
	Then I close browser
