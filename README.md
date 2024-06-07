# BDD Sample Project

## Introduction

This project demonstrates Behavior-Driven Development (BDD) using SpecFlow and NUnit in a .NET application. It includes a sample service `GetProducts` with BDD tests.

## Getting Started

1. Clone the repository.
2. Navigate to the project directory.
3. Run `dotnet test` to execute the tests.

## Project Structure

- `Features`: Contains the feature files written in Gherkin syntax.
- `StepDefinitions`: Contains the step definition classes.
- `Product.Api`: Main API project with the `GetProducts` service.
- `Product.Api.Tests.Acceptance`: Test project for BDD tests.

## Features

- Retrieve all products:
  - Test scenarios include:
    - Product service is available and returns products.
    - Product service is available but no products exist.
    - Product service is not available.


