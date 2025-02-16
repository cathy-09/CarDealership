# CarDealership

![image](https://github.com/user-attachments/assets/c33c14d4-179e-4b4f-8d6d-61e50d333c4a)


![image](https://github.com/user-attachments/assets/db863d10-49a4-4463-8776-bac7d6aa746c)


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
