Feature: Subscription
	In order to get benefits
	As a User
	I want to be a Washi subscriber

@subscription


Scenario: User does not have a subscription
	Given The user has not bought any subscription
	When Trying to adquire a subscription
	Then The system registers the new subscription to his/her account

Scenario: User wants to see his/her past subscriptions
	Given the user wants to see all the subscriptions he/she had
	When trying to see his subscription
	Then The system shows a list of the subscriptions

