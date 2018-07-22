Feature: EditEmployee
	As a user
	I want to be able to edit an employee

@regression
@EditEmployee
Scenario Outline: Edit an existing employee
	Given I open browser and go to CafeTownsend home page
	Then I enter '<username>' into the 'username' field
		And I enter '<password>' into the 'password' field
	When I click on the Login button
	Then I click on the Create button
	When I fill in new employee data with the following:
	| field      | value   |
	| First name | Robo    |
	| Last name  | Cop     |
	#The custom date format is YYYY-MM-DD or Today as a string
	| Start date | Today   |
	| Email      | m@m.com |
	Then I click on the Add button
		And I see and select the new employee listed
		And I click on the Edit button
	When I fill in new employee data with the following:
	| field      | value      |
	| First name | Termi      |
	| Last name  | Nator      |
	#The custom date format is YYYY-MM-DD or Today as a string
	| Start date | 2000-12-31 |
	| Email      | a@a.aa     |
	Then I click on the Update button
		And I see and select the new employee listed
		And I click on the Edit button
		And I see all the employee data is shown correctly
		And I close browser

Examples: 
| username | password  |
| Luke     | Skywalker |

@regression
@EditEmployee
Scenario Outline: Edit an existing employee with invalid data
	Given I open browser and go to CafeTownsend home page
	Then I enter '<username>' into the 'username' field
		And I enter '<password>' into the 'password' field
	When I click on the Login button
	Then I click on the Create button
	When I fill in new employee data with the following:
	| field      | value   |
	| First name | Robo    |
	| Last name  | Cop     |
	#The custom date format is YYYY-MM-DD or Today as a string
	| Start date | Today   |
	| Email      | m@m.com |
	Then I click on the Add button
		And I see and select the new employee listed
		And I click on the Edit button
	When I fill in new employee data with the following:
	| field      | value      |
	| First name | Robo       |
	| Last name  | Cop        |
	#The custom date format is YYYY-MM-DD or Today as a string
	| Start date | 2000-13-32 |
	| Email      | m@m.com    |
	Then I see 'Start date' field invalid
		And I click on the Update button
		And I wait for '3' second(s)
		And I accept the alert message '<alert>'
	#NOTE: This test will fail in purpose as the date '2000-13-32' is not valid and the Update button is disabled, but clickable. Despite the value being rejected, there is no alert
		And I close browser

Examples: 
| username | password  | alert                                                                     |
| Luke     | Skywalker | Error trying to create a new employee: {"start_date":["can't be blank"]}) |

@regression
@EditEmployee
Scenario Outline: Testing back button
	Given I open browser and go to CafeTownsend home page
	Then I enter '<username>' into the 'username' field
		And I enter '<password>' into the 'password' field
	When I click on the Login button
	Then I click on the Create button
	When I fill in new employee data with the following:
	| field      | value   |
	| First name | Robo    |
	| Last name  | Cop     |
	#The custom date format is YYYY-MM-DD or Today as a string
	| Start date | Today   |
	| Email      | m@m.com |
	Then I click on the Add button
		And I see and select the new employee listed
		And I click on the Edit button
	When I clear all the employee fields
	Then I click on the Back button
#If leaving the step below uncommented, this test will fail in purpose because after clicking the Back button,
#the employee is still selected so returning to its edition (by clicking the Edit button) eventually, should not keep all the fields blank like 
#right after Clear. However, if a click on this employee is performed, or selected is another employee and then this employee is selected again,
#then the fields will not be blank. So it seems like a bug, but at the same time can be a feature.
		And I see and select the new employee listed
		And I click on the Edit button
		And I see all the employee data is shown correctly

		And I close browser
Examples: 
| username | password  |
| Luke     | Skywalker |
