Here's a sample **README.md** file for your **ECommerceApp** built using **ASP.NET Core MVC** and **Entity Framework Core**.

---

# ECommerceApp

ECommerceApp is a web-based application designed to provide users with a seamless shopping experience. Users can register, log in, browse products, manage their shopping cart, and checkout. The application is built using **ASP.NET Core MVC** for the front-end logic and **Entity Framework Core** for data access and management.

## Features

1. **User Registration and Authentication**:
   - Users can register and log in to the application.
   - Authentication is managed using **cookie-based authentication**.

2. **Product Management**:
   - Authenticated users can view a list of available products.
   - Authenticated users can add new products to the store.

3. **Shopping Cart**:
   - Users can add products to their cart.
   - The shopping cart allows users to view items and the total amount.

4. **Security**:
   - User passwords are hashed using the **PBKDF2 algorithm** for security.
   - Cookie-based authentication is used to manage user sessions.

## Architecture

### Controllers

- **CartController**:  
  Manages adding products to the cart and viewing the cart. Only authenticated users can interact with the cart. All cart-related database operations are handled by this controller.

- **HomeController**:  
  Handles the home page and the error page. It provides a simple interface for navigating through the application.

- **ProductController**:  
  Responsible for managing the products. Authenticated users can add new products, and all users can view the list of available products.

- **UserController**:  
  Handles user registration, login, and logout. Manages user authentication and securely stores passwords using hashing.

### Models

- **Cart**:  
  Represents a shopping cart item, including properties like product ID, quantity, total amount, and the user ID.

- **ErrorViewModel**:  
  Used to display error messages and related information.

- **LoginViewModel**:  
  Contains the necessary fields for user login, such as username and password.

- **Product**:  
  Represents a product in the store, including details like product name, description, and price.

- **User**:  
  Represents a user with details like username, password (hashed), and email.

### Data

- **ApplicationDbContext**:  
  The Entity Framework Core context for the application. Manages database operations related to users, products, and carts.

- **ApplicationDbContextFactory**:  
  Used for design-time database context creation, aiding in migrations and database updates.

### Security

- **Password Hashing**:  
  All user passwords are hashed using the **PBKDF2 algorithm** with a salt, ensuring they are securely stored.

- **Authentication**:  
  Cookie-based authentication is used for secure session management.

## Getting Started

### Prerequisites

- **ASP.NET Core 6.0+**
- **Entity Framework Core**
- **SQL Server or SQLite** (for development)

### Setup

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/ECommerceApp.git
   cd ECommerceApp
   ```

2. Install the necessary dependencies:
   ```bash
   dotnet restore
   ```

3. Set up the database:
   ```bash
   dotnet ef database update
   ```

4. Run the application:
   ```bash
   dotnet run
   ```

### Migrations

To apply changes to the database schema, run:
```bash
dotnet ef migrations add MigrationName
dotnet ef database update
```

### Application Configuration

Modify the `appsettings.json` file to configure the database connection string:
```json
"ConnectionStrings": {
  "DefaultConnection": "YourConnectionStringHere"
}
```

## Screenshots

### Home Page
![Home Page](https://github.com/user-attachments/assets/6c19d743-d7b5-42a4-8d64-bdb070bd7992)

### Product List
![Product List](https://github.com/user-attachments/assets/83586f8f-bc88-4d68-a572-d006dae9919d)

### Shopping Cart
![Shopping Cart](https://github.com/user-attachments/assets/edeed75a-fcd7-4d1d-b5cb-d541e372e59f)

### User Registration
![User Registration](https://github.com/user-attachments/assets/bf4fe3ab-28ef-40ea-a3e1-2f318c6e27a3)

## License


---


