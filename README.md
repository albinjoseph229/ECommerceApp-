ECommerceApp Report

ECommerceApp is a web-based application designed to provide a seamless shopping experience for users. The application allows users to register, log in, browse products, add products to their cart, and view their cart. The application is built using ASP.NET Core MVC and Entity Framework Core for data access.
Features
1.	User Registration and Authentication: Users can register and log in to the application. Authentication is handled using cookie-based authentication.
2.	Product Management: Users can view a list of products and add new products if they are authenticated.
3.	Shopping Cart: Users can add products to their cart, view the items in their cart, and see the total amount.
Architecture
Controllers
·	CartController: Manages adding products to the cart and viewing the cart. It ensures that only authenticated users can add items to their cart and handles database operations related to the cart.
·	HomeController: Handles the home page and error page. It provides a simple interface for users to navigate the application.
·	ProductController: Manages adding and viewing products. It allows authenticated users to add new products and view the list of available products.
·	UserController: Handles user registration, login, and logout. It manages user authentication and ensures secure password storage using hashing.
Models
·	Cart: Represents a shopping cart item, including product ID, quantity, total amount, and user ID.
·	ErrorViewModel: Used to display error information.
·	LoginViewModel: Used for user login, containing username and password fields.
·	Product: Represents a product in the store, including name, description, and price.
·	User: Represents a user in the application, including username, password, and email.
Data
·	ApplicationDbContext: The Entity Framework Core context for the application. It manages database operations for users, products, and carts.
·	ApplicationDbContextFactory: Used for design-time DbContext creation, facilitating migrations and database updates.
Security
·	Password Hashing: User passwords are securely hashed using a salt and the PBKDF2 algorithm to ensure that passwords are not stored in plain text.
·	Authentication: Cookie-based authentication is used to manage user sessions securely.


![image](https://github.com/user-attachments/assets/6c19d743-d7b5-42a4-8d64-bdb070bd7992)

![image](https://github.com/user-attachments/assets/83586f8f-bc88-4d68-a572-d006dae9919d)

![image](https://github.com/user-attachments/assets/edeed75a-fcd7-4d1d-b5cb-d541e372e59f)

![image](https://github.com/user-attachments/assets/bf4fe3ab-28ef-40ea-a3e1-2f318c6e27a3)

