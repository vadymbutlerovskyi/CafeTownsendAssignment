Feature: CreateEmployeeSteps
	As a user
	I want to be able to create a new employee

@regression
@CreateEmployee
Scenario Outline: Create a new employee
	Given I open browser and go to CafeTownsend home page
	Then I enter '<username>' into the 'username' field
		And I enter '<password>' into the 'password' field
	When I click on the Login button
	Then I click on the Create button
		And I click on the Cancel button
		And I click on the Create button
	When I fill in new employee data with the following:
	| field      | value   |
	| First name | Robo    |
	| Last name  | Cop     |
	#The custom date format is YYYY-MM-DD or Today as a string
	| Start date | Today   |
	| Email      | m@m.com |
	Then I click on the Add button
		And I see and select the new employee listed
		And I close browser

Examples: 
| username | password  |
| Luke     | Skywalker |



@regression
@CreateEmployee
Scenario Outline: Create a new employee with invalid data
	Given I open browser and go to CafeTownsend home page
	Then I enter '<username>' into the 'username' field
		And I enter '<password>' into the 'password' field
	When I click on the Login button
	Then I click on the Create button
	When I fill in new employee data with the following:
	| field      | value      |
	| First name | Robo       |
	| Last name  | Cop        |
	#The custom date format is YYYY-MM-DD or Today as a string
	| Start date | 2000-13-32 |
	| Email      | m@m.com    |
	Then I click on the Add button
		And I wait for '3' second(s)
		And I accept the alert message '<alert>'
		And I see 'Start date' field invalid
	When I fill in new employee data with the following:
	| field      | value     |
	| First name | Robo      |
	| Last name  | Cop       |
	| Start date | 7/22/2018 |
	| Email      | @mcom     |
	Then I see 'Start date' field invalid
		And I see 'Email' field invalid
	When I fill in new employee data with the following:
	| field      | value  |
	| First name | Robo   |
	| Last name  | Cop    |
	| Start date | Today  |
	| Email      | m@mcom |
	#NOTE: This test will fail in purpose as email 'm@mcom' should not be accepted by regex as this email is invalid, but it is
	Then I click on the Add button
		And I see 'Email' field invalid
		And I close browser

Examples: 
| username | password  | alert                                                                     |
| Luke     | Skywalker | Error trying to create a new employee: {"start_date":["can't be blank"]}) |
