Create Database CompanyManagement
use CompanyManagement



-- Creating the Employee Table
create table Employees
(EmpId int constraint pk_EmpId primary key,
 EmpSalary float,
 EmpName varchar(20),
 DepName varchar(20) null,
 BossNo int null constraint boss_no references Employees(EmpId))



 --Creating the Department Table
 create table Departments
 (DepName varchar(20) constraint pk_DepName primary key,
  Floor int,
  PhoneNo varchar(15),
  EmpNo int not null constraint fk_EmpId references Employees(EmpId)
 )

 -- Altering the Employee Table
 alter table Employees
 add constraint fk_depName foreign key(DepName) references Departments(DepName)


 -- Creating the Item Table
  create table Items
 (ItemName varchar(50) primary key,
  ItemType varchar(20),
  ItemColor varchar(10)
 )

 -- Creating the Sales Table
 create table Sales
 (SaleNo int primary key,
  SaleQnty int,
  ItemName varchar(50) not null constraint fk_itemName references Items(ItemName),
  DepName varchar(20) not null constraint fk_DepName_d references Departments(DepName)
 )


 -- Adding the Data in the Items Table
 
INSERT INTO Items (ItemName, ItemType, ItemColor)
VALUES 
('Pocket Knife-Nile', 'E', 'Brown'),
('Pocket Knife-Avon', 'E', 'Brown'),
('Compass', 'N', NULL),
('Geo positioning system', 'N', NULL),
('Elephant Polo stick', 'R', 'Bamboo'),
('Camel Saddle', 'R', 'Brown'),
('Sextant', 'N', NULL),
('Map Measure', 'N', NULL),
('Boots-snake proof', 'C', 'Green'),
('Pith Helmet', 'C', 'Khaki'),
('Hat-polar Explorer', 'C', 'White'),
('Exploring in 10 Easy Lessons', 'B', NULL),
('Hammock', 'F', 'Khaki'),
('How to win Foreign Friends', 'B', NULL),
('Map case', 'E', 'Brown'),
('Safari Chair', 'F', 'Khaki'),
('Safari cooking kit', 'F', 'Khaki'),
('Stetson', 'C', 'Black'),
('Tent - 2 person', 'F', 'Khaki'),
('Tent -8 person', 'F', 'Khaki');



-- Altering the Employee Table for Insertion Of data
Alter table Employees
drop constraint fk_depName

--- Now Inserting the Data to the Employees Table
-- Insert data into Employees table
INSERT INTO Employees (EmpId, EmpName, EmpSalary, DepName, BossNo)
VALUES 
(1, 'Alice', 75000, 'Management', NULL),
(2, 'Ned', 45000, 'Marketing', 1),
(3, 'Andrew', 25000, 'Marketing', 2),
(4, 'Clare', 22000, 'Marketing', 2),
(5, 'Todd', 38000, 'Accounting', 1),
(6, 'Nancy', 22000, 'Accounting', 5),
(7, 'Brier', 43000, 'Purchasing', 1),
(8, 'Sarah', 56000, 'Purchasing', 7),
(9, 'Sophile', 35000, 'Personnel', 1),
(10, 'Sanjay', 15000, 'Navigation', 3),
(11, 'Rita', 15000, 'Books', 4),
(12, 'Gigi', 16000, 'Clothes', 4),
(13, 'Maggie', 11000, 'Clothes', 4),
(14, 'Paul', 15000, 'Equipment', 3),
(15, 'James', 15000, 'Equipment', 3),
(16, 'Pat', 15000, 'Furniture', 3),
(17, 'Mark', 15000, 'Recreation', 3);

-- Adding the data in to Department Table
-- Insert data into Departments table
INSERT INTO Departments (DepName, Floor, PhoneNo, EmpNo)
VALUES 
('Management', 5, '34', 1),
('Books', 1, '81', 4),
('Clothes', 2, '24', 4),
('Equipment', 3, '57', 3),
('Furniture', 4, '14', 3),
('Navigation', 1, '41', 3),
('Recreation', 2, '29', 4),
('Accounting', 5, '35', 5),
('Purchasing', 5, '36', 7),
('Personnel', 5, '37', 9),
('Marketing', 5, '38', 2);


-- Altering the table Employee for adding the Reference of Employee Table
alter table Employees
 add constraint fk_depName foreign key(DepName) references Departments(DepName)


 -- Adding the data in to Sales Table
 -- Insert data into Sales table with non-null entries
INSERT INTO Sales (SaleNo, SaleQnty, ItemName, DepName)
VALUES 
(101, 2, 'Boots-snake proof', 'Clothes'),
(102, 1, 'Pith Helmet', 'Clothes'),
(103, 1, 'Sextant', 'Navigation'),
(104, 3, 'Hat-polar Explorer', 'Clothes'),
(105, 5, 'Pith Helmet', 'Equipment'),
(106, 2, 'Pocket Knife-Nile', 'Clothes'),
(107, 3, 'Pocket Knife-Nile', 'Recreation'),
(108, 1, 'Compass', 'Navigation'),
(109, 2, 'Geo positioning system', 'Navigation'),
(110, 5, 'Map Measure', 'Navigation'),
(111, 1, 'Geo positioning system', 'Books'),
(112, 1, 'Sextant', 'Books'),
(113, 3, 'Pocket Knife-Nile', 'Books'),
(114, 1, 'Pocket Knife-Nile', 'Navigation'),
(115, 1, 'Pocket Knife-Nile', 'Equipment'),
(116, 1, 'Sextant', 'Clothes'),
(125, 1, 'Elephant Polo stick', 'Recreation'),
(126, 1, 'Camel Saddle', 'Recreation');


select * from Employees
select * from Departments
select * from Items
select * from Sales


