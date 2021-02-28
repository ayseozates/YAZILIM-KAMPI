Create Table CarImages(
CarImageId int IDENTITY(1,1),
CarId int,
ImagePath nvarchar(MAX),
ImageDate Datetime,
FOREIGN KEY (CarId)REFERENCES Cars(Id)


)
