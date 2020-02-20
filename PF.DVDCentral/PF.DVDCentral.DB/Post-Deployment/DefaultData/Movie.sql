BEGIN
	INSERT INTO dbo.tblMovie(Id,Title,Description,Cost,RaitingsId,FormatId,DirectorId,InStockQty,ImagePath)
	VALUES
	(1,'Sonic','Blue Hedgehog',19,1,1,1,1,'null'),
	(2,'Harry Potter','Wizard Stuff',9,2,2,2,1,'null'),
	(3,'Star Wars','Space Fighting',18,3,1,2,1,'null')

END