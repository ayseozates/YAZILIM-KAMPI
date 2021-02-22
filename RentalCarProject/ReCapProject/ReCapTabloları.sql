CREATE TABLE Cars(
 
   Id   INT  PRIMARY KEY IDENTITY(1,1) NOT NULL,
   BrandId INT,
   ColorId int,
   ModelYear  INT , 
   DailyPrice decimal ,   
   Description nvarchar(50),
   Foreign Key(ColorId)References Colors(ColorId),
   Foreign Key(BrandId)References Brands(BrandId),
  
);

Create Table Brands(
BrandId int Primary Key Identity(1,1) not null,
BrandName varchar(50),

);
Create Table Colors(
ColorId int Primary Key Identity(1,1) not null,
ColorName varchar(50),
);
Insert into Colors(ColorName)Values ('Beyaz'),('Siyah'),('Kýrmýzý');

Insert into Brands(BrandName)Values ('BMW'),('Skoda'),('Mercedes');

Insert into Cars(BrandId,ColorId,ModelYear,DailyPrice,Description)
Values
('1','1','2013','200','Lüks Araç'),
('1','3','2014','100','Otomatik Dizel'),
('2','2','2018','150','Manuel Benzin'),
('3','1','2019','200','Otomatik Benzin');
