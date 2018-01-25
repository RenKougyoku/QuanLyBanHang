Drop database QUANLYBANHANG
Create database QUANLYBANHANG
go
use QUANLYBANHANG
go
create table tb_category (
	category_id int identity (1,1) primary key, 
	category_name nvarchar (50) not null default ' ',
	del_fg bigint not null default 0 
)
go 
create table tb_unit(
	unit_id int identity (1,1) primary key, 
	unit_name nvarchar (50) not null default ' '
)
go 
create table tb_Username (
	ID int identity(1,1) primary key,
	Username nvarchar(50) not null, 
	Pass varchar(50) not null,
)
go
drop table tb_product
create table tb_product(
	product_id varchar(10) primary key NOT NULL DEFAULT ' ',
	product_name nvarchar(200) NOT NULL DEFAULT ' ',
	price_in decimal(19,0) NOT NULL DEFAULT 0,
	price_out decimal(19,0) NOT NULL DEFAULT 0,
	quantity int NOT NULL DEFAULT 0,
	modifi nvarchar(50) NOT NULL DEFAULT ' ' ,
	category_id int NOT NULL DEFAULT 0, 
	unit_id int NOT NULL DEFAULT 0,
	brandname nvarchar(100) NOT NULL DEFAULT ' ' ,
	size nvarchar(20) NOT NULL DEFAULT ' ' ,
	photo image DEFAULT NULL,
	del_fg bigint not null default 0
)
go
create table tb_person(
	person_id varchar(10) primary key NOT NULL,
	person_name nvarchar(200) NOT NULL DEFAULT ' ', 
	person_address nvarchar(max) NOT NULL DEFAULT ' ',
	person_phone varchar(15) NOT NULL DEFAULT ' ',
	typeperson bigint not null,
	del_fg bigint not null default 0
)
go
drop table tb_bill
create table tb_bill (
	bill_id varchar(30) primary key NOT NULL, 
	person_id varchar(10) NOT NULL DEFAULT ' ',
	person_name nvarchar(50) NOT NULL DEFAULT ' ', 
	bill_date datetime NOT NULL, 
	note nvarchar(200) DEFAULT NULL,
	typebill bigint not null,
	del_fg bigint not null default 0
)
go
drop table tb_billdetail
create table tb_billdetail (
	billdetail_id int  identity(1,1) primary key not null ,
	bill_id varchar(30) not null foreign key (bill_id) references tb_bill(bill_id) ,
	product_id varchar(10) not null foreign key (product_id) references tb_product(product_id),
	quantity int, 
	price_one decimal(19,0),
	note nvarchar(max),
	del_fg bigint not null default 0
)

go
create table tb_Error(
	ID varchar(10) not null primary key,
	Content nvarchar(max) 
)
go
create table tb_Payment(
	payment_id varchar(30) not null primary key,
	bill_id varchar(30) not null ,
	-- thanh tien tinh dc
	chietkhau 
	guess_pay
	guess_charge
	pay_date 
)
