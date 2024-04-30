create database dbEmployeeTrack
use dbEmployeeTrack

drop database dbEmployeeTrack

use master
go
drop database dbEmployeeTrack

--Create table
create Table Areas
(Area varchar(20),
Zipcode char(5))

select * from Areas

sp_help Areas



--Edit the area colum to be teh primary key
alter table Areas
alter column Area varchar(20) not null
alter table Areas
add constraint pk_Area primary key(Area)


--Drop and re create table to add primary key

drop table Areas

create Table Areas
(Area varchar(20) constraint pk_Area primary key,
Zipcode char(5))

--Alter table to add clolumn
Alter table Areas
add AreaDescription varchar(1000)

--Alter table to delete clolumn
alter table Areas
drop column AreaDescription

create table Skills
(SId int identity(1,1) constraint pk_skill primary key,Skill varchar(20) ,Skill_Description varchar(100))

sp_help skills
-- creating employee table
create table Employees1
(id int identity(101,1) constraint pk_EmployeeId primary key,
name varchar(100) ,
DateOfBirth datetime constraint chk_DOB Check(DateOfBirth<Getdate()),
EmployeeArea varchar(20) constraint fk_Area references Areas(Area),
Phone varchar(15),
email varchar(100) not null)

sp_help Employees1


create table EmployeeSkill
(Employee_id int constraint fk_skill_eid foreign key references Employees1(id),
Skill int constraint fk_Skill_EmplSkill foreign key references Skills(SId),
skillLevel float constraint chk_skilllevel check(skillLevel>=0),
constraint pk_employee_skill primary key(EMployee_id,Skill))

sp_help EmployeeSkill

--DML--
Insert into Areas(Area,Zipcode) values('DDDD','12345')
Insert into Areas(Zipcode,Area) values('12333','FFFF')
insert into Areas values('HHHH','12222')

select * from Areas

insert into skills(Skill,Skill_Description) values('C','PLT')
insert into skills(Skill,Skill_Description) values('C++','OOPS'),('Java','Web'),('C#','Web'),('SQL','RDBMS')
select * from skills

--Foreign Key insert
insert into Employees1(name,DateOfBirth,EmployeeArea,Phone,Email)
Values('Ramu','2000-12-12','DDDD','9876543210','ramu@gmail.com')
insert into Employees1(name,DateOfBirth,EmployeeArea,Phone,Email)
Values('Somu','2001-05-01','FFFF','9988776655','somu@gmail.com')

select * from Employees1

--Employee Skill- Composite key

Insert into EmployeeSkill values(102,3,8)
select* from EmployeeSkill
