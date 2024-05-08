create database db_ClinicShop
use db_ClinicShop

create table Doctors(
Id int identity(1,1) primary key,
Name varchar(20),
Specialization varchar(20),
Available BIT
)
sp_help Doctors

create table Patients(
Id int identity(1,1) primary key,
Name varchar(20),
Age int,
Gender varchar(20),
Description varchar(300)
)

sp_help Patients

create table Appointments(
Id int identity(1,1) primary key,
DId int constraint Doct_fk references Doctors(Id),
PId int constraint Pat_fk references Patients(Id),
Date DATETIME ,
Status varchar(20)
)

sp_help Appointments

select * from Doctors

delete from Doctors

insert into doctors(Name,Specialization,Available) values('Mike','Ortho',0)