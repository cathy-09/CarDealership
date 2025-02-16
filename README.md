# CarDealership

##
Тема

Темата на проектната ни работа е: Интернет Програмиране: „Автокъщи“. Той трябва да предоставя удобен и ефективен начин за управление на автокъщи. Основната цел на проекта е да се създаде уеб приложение, което да улеснява потребителите в намирането на перфектната кола, а управителят на всички автокъщи (реализиран под името администратор) да може да „зарежда“ нови коли в съответната автокъща.
Нашият софтуер предоставя функционалности от тип CRUD (Create, Read, Update, Delete), описани по-долу в документацията. Приложението се базира на MVC модела и съдържа:
- Слой за данни, отговарящ за работата с базата данни.
- Слой за услуги, където се обработва логиката на приложението.
- Презентационен слой (уеб интерфейс), чрез който потребителите взаимодействат с платформата.
Приложението използва база данни за съхранение на информацията и представя връзка от тип N:M (много към много) между колите и автокъщите, като всяка кола може да бъде налична в повече от една автокъща.


##
DB

![image](https://github.com/user-attachments/assets/db863d10-49a4-4463-8776-bac7d6aa746c)

##
DB с MySQL Workbench 

![image](https://github.com/user-attachments/assets/c33c14d4-179e-4b4f-8d6d-61e50d333c4a)

##
DB code

```sql
CREATE DATABASE CarDealership;
USE CarDealership;

CREATE TABLE Brands (
    BrandId INT PRIMARY KEY,
    BrandName NVARCHAR(20) NOT NULL
);

CREATE TABLE Dealerships (
    DealershipId INT PRIMARY KEY,
    Name NVARCHAR(25) NOT NULL,
    Location NVARCHAR(200) NOT NULL
);

CREATE TABLE Cars (
    CarId INT PRIMARY KEY,
    BrandId INT NOT NULL,
    Model NVARCHAR(30) NOT NULL,
    CarImageURL NVARCHAR(250),
    Year INT NOT NULL,
    FuelType NVARCHAR(50) NOT NULL,
    Kilometers INT NOT NULL,
    HorsePower INT NOT NULL,
    Description NVARCHAR(250),
    Price DECIMAL(18,2) NOT NULL,
    UserId NVARCHAR(450) NOT NULL,
    FOREIGN KEY (BrandId) REFERENCES Brands(BrandId)
);

CREATE TABLE DealershipsCars (
    CarId INT NOT NULL,
    DealershipId INT NOT NULL,
    PRIMARY KEY (CarId, DealershipId),
    FOREIGN KEY (CarId) REFERENCES Cars(CarId) ON DELETE CASCADE,
    FOREIGN KEY (DealershipId) REFERENCES Dealerships(DealershipId) ON DELETE CASCADE
);

CREATE TABLE GeneralManagers (
    GeneralManagerId INT PRIMARY KEY,
    FirstName NVARCHAR(35) NOT NULL,
    LastName NVARCHAR(35) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    PhoneNumber NVARCHAR(15) NOT NULL,
    HireDate DATE NOT NULL,
    Salary DECIMAL(18,2) NOT NULL,
    DealershipId INT NOT NULL,
    FOREIGN KEY (DealershipId) REFERENCES Dealerships(DealershipId) ON DELETE CASCADE
);
```
##
Authors

- [@Petio0](https://github.com/Petio0)
- [@cathy-09](https://github.com/cathy-09)
- [@Lemon1069](https://www.github.com/Lemon1069)
