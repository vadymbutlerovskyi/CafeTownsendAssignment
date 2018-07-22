Feature: CreateUserSteps
	As a user
	I want to be able to create another user

@regression
@CreateUser
Scenario Outline: Create a new user
	Given I open browser and go to CafeTownsend home page
	Then I wait for '1' second(s)
		And I enter '<username>' into the 'username' field
		And I enter '<password>' into the 'password' field
	When I click on the 'Login' button
	Then I click on the 'Create' button
		And I click on the 'Cancel' button
		And I click on the 'Create' button
	When I fill in new user data with the following:
	| field      | value   |
	| First name | Robo    |
	| Last name  | Cop     |
	#The custom date format is YYYY-MM-DD or Today as a string
	| Start date | Today   |
	| Email      | m@m.com |
Examples: 
| username | password  |
| Luke     | Skywalker |
