CREATE TABLE [dbo].[SALES]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [productid] INT NOT NULL, 
    [customerid] INT NOT NULL, 
    [categoryid] INT NOT NULL, 
    [productsalesamount] INT NOT NULL, 
    [productsalesprice] INT NOT NULL, 
    [salesdate] DATE NOT NULL, 
    [isdeleted] BIT NOT NULL, 
    [deleteddate] DATE NULL
)
