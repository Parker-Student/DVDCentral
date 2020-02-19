CREATE TABLE [dbo].[tblMovie]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Title] NCHAR(10) NOT NULL, 
    [Description] VARCHAR(50) NOT NULL, 
    [ImagePath] VARCHAR(255) NOT NULL, 
    [Cost] DECIMAL(18, 2) NOT NULL, 
    [RaitingsId] INT NOT NULL, 
    [FormatId] INT NOT NULL, 
    [DirectorId] INT NOT NULL, 
    [InStockQty] INT NOT NULL
)
