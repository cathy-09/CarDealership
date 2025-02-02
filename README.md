# CarDealership

![image](https://github.com/user-attachments/assets/d806e93c-29a7-44da-9918-4f7b43244d41)

```sql
CREATE DATABASE CarDealership1;
USE CarDealership1;

CREATE TABLE Cars (
    CarId INT PRIMARY KEY IDENTITY,
    Brand VARCHAR(20),
    Model VARCHAR(20),
    Year INT NOT NULL,
    FuelType VARCHAR(10) NOT NULL,
    Kilometers VARCHAR(10) NOT NULL,
    HorsePower INT NOT NULL,
    Description VARCHAR(500) NOT NULL,
    Price DECIMAL(18, 2) NOT NULL
);
CREATE TABLE Dealerships (
    DealershipId INT PRIMARY KEY IDENTITY,
    Name VARCHAR(100) NOT NULL,
    Location VARCHAR(200) NOT NULL
);
CREATE TABLE Employees (
    EmployeeId INT PRIMARY KEY IDENTITY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    PhoneNumber VARCHAR(15),
    HireDate DATE NOT NULL,
    Salary DECIMAL(18, 2) NOT NULL,
    DealershipId INT NOT NULL,
    CONSTRAINT FK_Employees_Dealerships FOREIGN KEY (DealershipId) REFERENCES Dealerships(DealershipId)
);
CREATE TABLE DealershipCars (
    DealershipId INT NOT NULL,
    CarId INT NOT NULL,
    CONSTRAINT PK_DealershipCars PRIMARY KEY (DealershipId, CarId),
    CONSTRAINT FK_DealershipCars_Dealerships FOREIGN KEY (DealershipId) REFERENCES Dealerships(DealershipId),
    CONSTRAINT FK_DealershipCars_Cars FOREIGN KEY (CarId) REFERENCES Cars(CarId)
);
```
