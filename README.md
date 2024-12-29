# Animal Shelter Management System (Barınak-App)

## Project Overview
This project is a web application designed to manage the operations of an animal shelter, including the registration and adoption processes for animals. The application supports both admin and regular user roles, with comprehensive features for animal management and user interactions.

## Project Goals
The application aims to digitize and streamline the management of an animal shelter by providing functionalities such as:
- Animal registration and management
- User account management
- Adding comments about animals
- Filtering animals by species
- Role-based access for admins and regular users

## Technologies Used

### Backend Framework:
- **ASP.NET Core MVC**
- **Entity Framework Core** (ORM)

### Architectural and Design Patterns:
- **Repository Pattern**
- **Dependency Injection**
- **MVC (Model-View-Controller)** architecture

### Security:
- **Cookie-based authentication**
- **Role-based authorization**
- **Claims-based authentication**

## Project Structure

### Controllers:
- **AnimalsController**: Manages animal-related operations
- **UsersController**: Handles user operations (registration, login, profile management)

### Models:
- **View Models**:
  - `AnimalViewModel`: For displaying animal lists
  - `AnimalCreateViewModel`: For creating/editing animals
  - `LoginViewModel`: For user login operations
  - `RegisterViewModel`: For user registration operations
- **Entities**:
  - `Animal`: Represents animal details
  - `User`: Represents user information
  - `Breed`: Represents animal species
  - `Comment`: Represents user comments on animals

### Repository Pattern:
- **Interfaces**:
  - `IAnimalRepository`, `IUserRepository`, etc.
- **Implementations**:
  - `EfAnimalRepository`, `EfUserRepository`, etc.

## Key Features

### User Management:
- Registration
- Login
- Profile viewing
- Differentiation between admin and regular users

### Animal Management:
- Adding new animals
- Editing animal details
- Listing animals
- Filtering animals by species

### Interaction:
- Adding comments about animals
- Viewing detailed information about animals

### Security:
- Authorization checks
- Role-based access control
- Secure password management

## Database Relationships:
- A user can manage multiple animals
- An animal can have multiple species
- An animal can have multiple comments
- Each comment is associated with a user and an animal

## Summary
This web application provides a comprehensive animal shelter management system leveraging modern web technologies. Built with **ASP.NET Core MVC** and **Entity Framework Core**, it follows Clean Architecture principles to ensure a secure and scalable structure. Security features include cookie-based authentication and role-based authorization, while code reusability is achieved through the use of view components.
