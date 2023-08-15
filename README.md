# Dependency Injection Lifetime: Transient, Singleton & Scoped

![image](https://github.com/abduzalam/DotNetDILifeTimeDemo/assets/32676744/983346b0-bfe3-4e31-ba3d-a091c2385ce5)

![image](https://github.com/abduzalam/DotNetDILifeTimeDemo/assets/32676744/f2652dce-e34b-4e18-bf66-4bc0849f6be6)


## Which one to use

Transient services are safest to create, as you always get the new instance. But, since the dependency injection system creates them every time they will use more memory & Resources and can have a negative impact on performance if you too many of them.

Use Transient lifetime for the lightweight service with little or no state.

Scoped services service is the better option when you want to maintain state within a request.

Singletons are created only once and not destroyed until the end of the Application. Any memory leaks in these services will build up over time. Hence watch out for the memory leaks. Singletons are also memory efficient as they are created once reused everywhere.

Use Singletons where you need to maintain application wide state. Application configuration or parameters, Logging Service, caching of data is some of the examples where you can use singletons.

## Injecting service with different lifetimes into another

Be careful, while injecting service into another service with a different lifetime

Consider the example of Singleton Service, which depends on another Service which is registered with say the transient lifetime.

When the request comes for the first time a new instance of the singleton is created. It also creates a new instance of the transient object and injects into the Singleton service.

When the second request arrives the instance of the singleton is reused. The singleton already contains the instance of the transient service Hence it is not created again. This effectively converts the transient service into the singleton.

The services with the lower lifetime injected into service with a higher lifetime would change the lower lifetime service to a higher lifetime. This will make debugging the application very difficult and should be avoided at all costs.

Hence, remember the following rules

Never inject Scoped & Transient services into Singleton service.

Never inject Transient services into scoped service


