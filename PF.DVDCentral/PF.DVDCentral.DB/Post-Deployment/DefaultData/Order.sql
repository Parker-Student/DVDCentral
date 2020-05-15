BEGIN
	INSERT INTO dbo.tblOrder(Id,CustomerId,OrderDate,UserName,ShipDate)
	VALUES
	(1, 1, '2012-10-09 01:10:21', 1,'2012-10-09 01:10:21'),
	(2, 3, '2012-10-09 01:10:21', 1,'2012-10-09 01:10:21'),
	(3, 2, '2012-10-09 01:10:21', 1,'2012-10-09 01:10:21')

END