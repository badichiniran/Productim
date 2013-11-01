Create table Users (  
UserId int identity (1,1) primary key,
UserName nvarchar (15),
UserPassword nvarchar (15),
Register_time_stmp datetime DEFAULT (GETDATE()),
)
--drop table ProductTypes 
--Create table ProductTypes (
--ProductType_id int identity (1,1) primary key,
--ProductType_desc nvarchar (20),
--)
--ALTER TABLE Volunteer_In_Activity ADD IsApprove bit NOT NULL DEFAULT ((0))
--time_Stamp datetime ,--DEFAULT (GETDATE()),


Create table Product_categories(
Product_category_id int identity (1,1) primary key,
Product_category_desc nvarchar (20),
)

Create table Products (  
Product_id int identity (1,1) primary key,
Product_desc nvarchar (20),
Product_category_id int,
IsApproved bit NOT NULL DEFAULT ((1)) ,
UserId int ,
time_stmp datetime DEFAULT (GETDATE()),
constraint Product_category_FK foreign key (Product_category_id) references Product_categories ,
constraint UserId_FK1 foreign key (UserId) references Users   
)

Create table List(
List_id int identity (1,1) primary key,
List_name nvarchar (20),
UserId int,
Creation_date datetime DEFAULT (GETDATE()),
Is_Active bit NOT NULL DEFAULT ((1)) ,
Purchasing_time_stmp datetime ,
constraint UserId_FK foreign key (UserId) references Users  
) 
--ALTER TABLE List ADD Purchasing_time_stmp datetime 

Create table Units ( 
Unit_id int identity (1,1) primary key,
Unit_desc nvarchar (20),
)

Create table Product_list ( 
Product_list_id int identity (1,1) primary key,
List_id int,
Product_id int, 
Product_amount int,
Unit_id int,
Price int,
Comment nvarchar (20),
Is_purchased bit NOT NULL DEFAULT ((0)) ,

constraint List_id_FK foreign key (List_id) references List ,
constraint Product_id_FK foreign key (Product_id) references Products ,
constraint Unit_id_FK foreign key (Unit_id) references Units 
)



