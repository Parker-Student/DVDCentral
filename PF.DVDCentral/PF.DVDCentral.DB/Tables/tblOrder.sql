CREATE TABLE [dbo].[tblOrder]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [CustomerId] INT NOT NULL, 
    [OrderDate] DATETIME NOT NULL, 
    [UserId] INT NOT NULL, 
    [PaymentReceipt] IMAGE NOT NULL, 
    [ShipDate] DATETIME NOT NULL
)
