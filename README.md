
# Florage Ecommerce Microservices

Florage is a microservices-based Ecommerce application developed with .NET. The application consists of the following services:

- **Authentication service:** allows users to register and authenticate to the application
- **Payment service:** integrates with Stripe payment gateway to process payments
- **Order service:** handles order creation and management
- **Inventory service:** manages the inventory of products
- **Product service:** provides access to product information
- **Notification service:** sends email and SMS notifications to users

The services communicate with each other through a message bus (RabbitMQ), and each service has its own MongoDB database.

## System overview diagram

![System overview diagram of Florage Microservices](https://res.cloudinary.com/dxrksxul/image/upload/v1682753571/Github/microservices-1_1_rfvib1.jpg)

## Tech stack

![enter image description here](https://res.cloudinary.com/dxrksxul/image/upload/v1682761157/Github/tech_stack_unyqu6.jpg)



## Setup Instructions

To set up the Florage application, follow these steps:

1. Clone the repository
2. Add the necessary configuration information to the `appsettings.json` file in each microservice
3. Build each microservice using `dotnet build`
4. Build the Docker images using the provided Dockerfiles
5. Push the Docker images to a Docker registry
6. Deploy the Kubernetes configurations located in the `k8s` folder to your Kubernetes cluster

## Technology Stack

Florage is built using the following technologies:

- .NET
- MongoDB
- RabbitMQ
- Stripe payment gateway
- Docker
- Kubernetes

## Contributing

To contribute to Florage, please fork the repository and submit a pull request.
