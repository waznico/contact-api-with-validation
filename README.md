# Contact.API with Validation

This example shows how to use MediatR and FluentValidation to validate all incoming request params before processing them. 
Through decoupling the controller doesn't have to know how to call the validator or service. 
This example follows the [dotnet architecture scheme](https://github.com/dotnet-architecture/eShopOnContainers/tree/dev/src/Services/Ordering/Ordering.API).
