## Buy Now Pay Later Platform - ASP.NET CORE Microservices

This project is a hands-on implementation of a Buy Now Pay Later(BNPL) platform using ASP.NET Core and C#.
It is designed to simulate a real-world fintech architecture using microservices, RESTFUL APIs, and inter-service communication.

## Microservices Overview
|Service          |Description
------------------|------------------------------------------------------------------------------
| UserService     | Manages user data and exposes endpoints for user validation
| ProductService  | Handles product catalog and availability checks
| BNPLService     | Core service for BNLP logic, validating users/products via other services

## Interservice Communication
BNPLService uses HttpClient to validate:
- UserId via UserService
- ProductId via ProductService
  
This ensures that BNPL requests are only processed for valid users products

## Testing and Validation
- all endpoints are tested using **Postman**
- validation logic confirmed for:
    - Missing or invalid UserId
    - Missing or invalid ProductId
    - Proper error responses and status codes
 
## Project Structure
Each service is a stand alone ASP .NET Core Web API project with its own controller, models and configuration.

## Technologies Used
- ASP .NET Core 9
- C#
- REST APIs
- HTTPClient
- Postman(for testing)
- Git and GitHub(version control)

## Getting Started
1. Clone the repo https://github.com/NtobekoDev/BuyNowPayLaterPlatform
2. Open solution in **Visual Studio**
3. Run each service individually
4. Use Postman to test endpoints

## Next Steps
I am still to add the following functionalities to the platform
- Implement authentication and authorisation
- Introduce message queues(e.g. RabbitMQ) for async communication
- Dockerise services for deployment

## About the Developer
Built by **Ntobeko Ngwenya**, a passionate Software Developer exploring ASP .NET Core and microservices.
