# BankSim Project

## Overview
The **BankSim** solution is a simple banking simulation built with **.NET 9**.  
It is organized into three projects:

1. **BankSim.App**  
   - A **console application** that serves as the entry point of the solution.  
   - Responsible for running the simulation and orchestrating calls to other layers.

2. **BankSim.Domain**  
   - A **class library** containing core domain models, business rules, and abstractions.  
   - Implements the business logic of the banking system.

3. **BankSim.Infrastructure**  
   - A **class library** that provides infrastructure and persistence implementations (e.g., repositories, services).  
   - Works as the bridge between the application and external systems.

This structure follows the principles of **clean architecture**, separating concerns and keeping the domain logic independent of infrastructure.

---

## How to Run

1. Ensure you have **.NET 9 SDK** installed.  
2. Open the solution in your IDE or terminal.  
3. Navigate to the **BankSim.App** project (the console app).  
4. Run the application by executing the entry point (`Program.cs`).  

The command is run against the `BankSim.App` project since it contains the `Main` method that starts the simulation.

---

## Project Structure

```
BankSim/
│
├── BankSim.App/ # Console application (entry point)
│ └── Program.cs
│
├── BankSim.Domain/ # Domain models & business logic
│ └── (Entities, ValueObjects, Services, etc.)
│
├── BankSim.Infrastructure/ # Infrastructure & persistence
│ └── (Repositories, Data Access, etc.)
│
└── BankSim.sln # Solution file
```

## Requirements
- .NET 9 SDK  
- IDE (Visual Studio, Rider, or VS Code) or terminal with `dotnet` CLI  

---

## Notes
- The **App** project references **Domain** and **Infrastructure** projects.  
- The **Domain** project should not depend on **Infrastructure**, ensuring a clean separation of concerns. 