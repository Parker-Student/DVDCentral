BEGIN
	INSERT INTO dbo.tblOrderItem(Id,OrderId,MovieId,Quantity)
	VALUES
	(1, 2,3,4),
	(2, 1,2,3),
	(3, 2,3,4)

END