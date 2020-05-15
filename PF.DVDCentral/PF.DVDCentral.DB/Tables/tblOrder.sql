CREATE TABLE [dbo].[tblOrder]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [CustomerId] INT NOT NULL, 
    [OrderDate] DATETIME NOT NULL, 
    [UserName] INT NOT NULL, 
    [ShipDate] DATETIME NOT NULL 
)
