Create table Users (  
UserName nvarchar (15) primary key,
UserPassword nvarchar (15),
)

Create table ProductTypes (
ProductType_id int identity (1,1) primary key,
ProductType_desc nvarchar (20),
)


Create table Product_categories(
Product_category_id int identity (1,1) primary key,
Product_category_desc nvarchar (20),
)

Create table Products (  
Product_id int identity (1,1) primary key,
Product_desc nvarchar (20),
Product_category_id int,
constraint Product_category_FK foreign key (Product_category_id) references Product_categories  
)

Create table List(
List_id int identity (1,1) primary key,
List_name nvarchar (20),
UserName nvarchar (15),
Creation_date datetime DEFAULT (GETDATE()),
Is_Active bit NOT NULL DEFAULT ((0)) ,
constraint UserName_FK foreign key (UserName) references Users  
) 

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
Is_purchased bit NOT NULL DEFAULT ((1)) ,

constraint List_id_FK foreign key (List_id) references List ,
constraint Product_id_FK foreign key (Product_id) references Products ,
constraint Unit_id_FK foreign key (Unit_id) references Units 
)



