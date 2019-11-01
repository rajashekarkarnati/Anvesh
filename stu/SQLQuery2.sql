use Training_20Feb_Mumbai

create schema StudentStaffDetailsAutomation

create table StudentStaffDetailsAutomation.StudentDetails
( StudentId int identity (170000,1) primary key,
Name varchar(25),
Gender char check (gender in('M', 'F')),
Branch nvarchar(10),
[Year] varchar(5),
DateofBirth date,
PhoneNumber nvarchar(10),
Addrees varchar(500),
FeesAmount bigint
)
drop table StudentStaffDetailsAutomation.StudentDetails
drop table StudentStaffDetailsAutomation.StaffDetails
select * from StudentStaffDetailsAutomation.StudentDetails
select * from StudentStaffDetailsAutomation.StaffDetails
--------------------
create table StudentStaffDetailsAutomation.StaffDetails
( 
StaffId int identity (200000,1) primary key,
[Name] varchar(25) ,
Gender char check (gender in('M', 'F')),
City varchar(20),
Experience int,
PhoneNumber nvarchar(10),
Salary Bigint,
[Subject] varchar(20))

-----------------------
create table StudentStaffDetailsAutomation.Fees
( 
feesid int primary key Identity,
StudentId int foreign key references StudentStaffDetailsAutomation.StudentDetails(StudentId),
Branch nvarchar(10),
[Year] varchar(5),
Amount bigint,
Paid varchar(10),
Balance bigint
)

insert into StudentStaffDetailsAutomation.Fees values('170001', 10000, 'Partial', 6000)
drop table StudentStaffDetailsAutomation.Fees
drop table StudentStaffDetailsAutomation.AdminLogin


create table StudentStaffDetailsAutomation.AdminLogin
(
	id int primary key Identity,
	adminUsername varchar(10),
	adminpassword varchar(20)
)

insert into StudentStaffDetailsAutomation.AdminLogin values('admin','admin')

select * from StudentStaffDetailsAutomation.AdminLogin
---------------------------------------------------

create table StudentStaffDetailsAutomation.FeeStructure
(
	id int identity primary key,
	[year] varchar(5),
	Branch nvarchar(10),
	Amount Bigint
)

drop table StudentStaffDetailsAutomation.FeeStructure


insert into StudentStaffDetailsAutomation.FeeStructure values('1', 'CSE', 100000)
insert into StudentStaffDetailsAutomation.FeeStructure values('2', 'CSE', 110000)
insert into StudentStaffDetailsAutomation.FeeStructure values('3', 'CSE', 130000)
insert into StudentStaffDetailsAutomation.FeeStructure values('4', 'CSE', 150000)
insert into StudentStaffDetailsAutomation.FeeStructure values('1', 'EEE', 70000)
insert into StudentStaffDetailsAutomation.FeeStructure values('2', 'EEE', 80000)
insert into StudentStaffDetailsAutomation.FeeStructure values('3', 'EEE', 90000)
insert into StudentStaffDetailsAutomation.FeeStructure values('4', 'EEE', 100000)
insert into StudentStaffDetailsAutomation.FeeStructure values('1', 'ECE', 90000)
insert into StudentStaffDetailsAutomation.FeeStructure values('2', 'ECE', 100000)
insert into StudentStaffDetailsAutomation.FeeStructure values('3', 'ECE', 120000)
insert into StudentStaffDetailsAutomation.FeeStructure values('4', 'ECE', 150000)
insert into StudentStaffDetailsAutomation.FeeStructure values('1', 'MECH', 40000)
insert into StudentStaffDetailsAutomation.FeeStructure values('2', 'MECH', 50000)
insert into StudentStaffDetailsAutomation.FeeStructure values('3', 'MECH', 60000)
insert into StudentStaffDetailsAutomation.FeeStructure values('4', 'MECH', 10000)
insert into StudentStaffDetailsAutomation.FeeStructure values('1', 'CIVIL', 50000)
insert into StudentStaffDetailsAutomation.FeeStructure values('2', 'CIVIL', 69000)
insert into StudentStaffDetailsAutomation.FeeStructure values('3', 'CIVIL', 71000)
insert into StudentStaffDetailsAutomation.FeeStructure values('4', 'CIVIL', 80000)
