# BurgerClash

I am excited to present BurgerClash, developed with great enthusiasm using ASP.NET 7.0 API, MVC, SignalR, and Javascript.

## Project Features

- **Real-time Communication and Statistics:**

  - Using SignalR in the project, instant communication is established with customers and staff. Order statuses and reservation updates are shared instantly, and business owners have immediate access to statistics.

- **Table Status and Order Notifications:**

  - The restaurant's table status is virtually displayed in real-time, and when new orders arrive, immediate notifications are sent to business owners or service personnel, enabling quick and efficient service to customers.

- **Statistics Display:**

  - Dynamic statistics displays added to the project provide business owners with visual access to important data such as sales trends, popular products, and income reports.

- **Notifications and Updates:**
  - Both customers and staff receive instant notifications for reservation confirmations, order statuses, special offers, and promotions.

## Technologies Used

- **Technological Platform:**

  - ASP.NET Core API 7.0: Used to create and manage web APIs.
  - SignalR: Utilized for real-time communication and sending instant updates to customers and staff.
  - QR Code Library (QRCoder): Integrated to generate QR codes representing orders.

- **Docker and Database Management:**

  - Docker and Docker Compose: Used to deploy and manage the project quickly and seamlessly in different environments.
  - Microsoft SQL Server (MSSQL): Chosen for reliable and scalable database management.

- **Project Architecture:**

  - N-tier Architecture: Based on the principles of N-tier architecture, the project has a modular structure, separating the application into different layers (presentation, business logic, data access, etc.).
  - Repository Pattern: Used for database interactions, abstracting database operations and making the code more organized and easier to maintain.

- **Frontend and Security:**
  - JavaScript and Ajax: Used on the frontend to create an interactive user interface.
  - Model-View-Controller (MVC) Architecture: Used as a fundamental architectural structure in both the frontend and backend.
  - JWT (JSON Web Token): Used for user authentication processes.
 

## Best Practices Implemented

### 1. Custom Response DTO
   - A Custom Response DTO is used to standardize and organize data sent to clients.
   - Benefits: Ensures a cleaner user experience by formatting and filtering unnecessary information.

### 2. DTO Usage
   - Data Transfer Objects (DTOs) are employed to efficiently structure data exchanged with clients.
   - Benefits: Optimizes data transfer and enhances communication with clients.

### 3. Mapping with Automapper
   - Automapper is utilized for seamless mapping between DTOs, automating object mapping.
   - Benefits: Reduces code redundancy, simplifies maintenance, and ensures consistent data mapping.

### 4. Custom ControllerBase
   - A specialized ControllerBase class is created for API controllers.
   - Benefits: Encapsulates common functionalities (e.g., business logic, error handling) to reduce repetition across controllers.

### 5. Validator and Validate Filters
   - Custom validator classes ensure the accuracy of incoming data.
   - Validate filters are used to verify requests pre or post-processing.
   - Benefits: Standardizes error messages, minimizes code repetition, and enhances data validation.
     
## CashLayer and Caching

In the project, CashLayer is utilized to enhance performance and avoid redundant database calls for products. CashLayer caches specific data points, providing quick access to the data and consequently improving the overall performance of the application.

### How to Use?

CashLayer caches data obtained from specific service calls for a defined period. This enables sections of the application that frequently access the same data to benefit from improved performance.

## Project Guide

This project brings together innovative features using modern technologies. Welcome to BurgerClash, where technology meets flavor!

## Images

![](/Frontent/WebUI/wwwroot/Burgerclash/1.png))

![](/Frontent/WebUI/wwwroot/Burgerclash/2.png)
![](/Frontent/WebUI/wwwroot/Burgerclash/3.png))

![](/Frontent/WebUI/wwwroot/Burgerclash/4.png)
![](/Frontent/WebUI/wwwroot/Burgerclash/5.png))

![](/Frontent/WebUI/wwwroot/Burgerclash/6.png)
![](/Frontent/WebUI/wwwroot/Burgerclash/7.png))

![](/Frontent/WebUI/wwwroot/Burgerclash/8.png)
![](/Frontent/WebUI/wwwroot/Burgerclash/9.png))

![](/Frontent/WebUI/wwwroot/Burgerclash/10.png)
![](/Frontent/WebUI/wwwroot/Burgerclash/11.png))

![](/Frontent/WebUI/wwwroot/Burgerclash/12.png)
![](/Frontent/WebUI/wwwroot/Burgerclash/13.png))

![](/Frontent/WebUI/wwwroot/Burgerclash/14.png)

![](/Frontent/WebUI/wwwroot/Burgerclash/15.png)
![](/Frontent/WebUI/wwwroot/Burgerclash/16.png))

![](/Frontent/WebUI/wwwroot/Burgerclash/17.png)
![](/Frontent/WebUI/wwwroot/Burgerclash/18.png))

![](/Frontent/WebUI/wwwroot/Burgerclash/19.png)

![](/Frontent/WebUI/wwwroot/Burgerclash/20.png))

![](/Frontent/WebUI/wwwroot/Burgerclash/21.png)
