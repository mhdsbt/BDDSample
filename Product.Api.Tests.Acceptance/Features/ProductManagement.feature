
Feature: Retrive All Products
	As a user of the product service
	I want to retrieve a list of all products
	So that I can view the available products

Scenario: Successfully retrieve all products
	Given the product service is available
	When I request to get all products
	Then the response should contain a list of products
	And the response status code should be 200

Scenario: No Product Avaiable 
	 Given  the product servuice is avaibale 
	 When i request to get all productcs
	 Then  the response should  contain contain Empty list
	 And the response status code should be 200

Scenario: service is down 
	Given  the product servuice is unavaibale 
	When i request to get all productcs
	Then  the response status code should be 503
	And the response Message "Service is not Avaiable"