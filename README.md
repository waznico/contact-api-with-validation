# Contact.API with Validation

This example shows how to use MediatR and FluentValidation to validate all incoming request params before processing them. 
Through decoupling the controller doesn't have to know how to call the validator or service. 
This example follows the [dotnet architecture scheme](https://github.com/dotnet-architecture/eShopOnContainers/tree/dev/src/Services/Ordering/Ordering.API).

## Docker Support

I added Docker support for demonstration purposes. You can see how it fits together.

### docker-compose Structure

The structure of docker-compose works as follows:
- docker-compose.yml contains all the images and relations
- docker-compose.override.yml contains the configuration for the different images
- docker-compose.debug.yml contains a debug configuration

In docker-compose.override.yml I defined a connection string to the database When I run `docker compose up`
the override file is automatically processed. In the configuration file the connection string is set and
accessible in the Startup class to setup the database connection.