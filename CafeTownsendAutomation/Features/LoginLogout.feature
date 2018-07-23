Feature: LoginLogoutSteps
	In order to login and logout
	As a user
	I want to be able to enter valid username and password and successfully sign in/out

@smoke
@LoginLogout
Scenario Outline: Test both invalid and successfull login and logout
	Given I open browser and go to CafeTownsend home page
	Then I enter '<username>' into the 'username' field
		And I enter '<password>' into the 'password' field
	When I click on the Login button
	Then I see the greeting message 'Hello ''<username>'
	When I click on the Logout button
	When I click on the Login button
	Then I see that 'username' field is required to be filled
		And I enter 'Invalid' into the 'username' field
	When I click on the Login button
	Then I see that 'password' field is required to be filled
		And I enter 'Invalid' into the 'password' field
	When I click on the Login button
	Then I see the error message 'Invalid username or password!'
	Then I close browser
Examples: 
| username | password  |
| Luke     | Skywalker |






