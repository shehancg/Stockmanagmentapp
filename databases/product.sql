CREATE TABLE [dbo].[PRODUCT] (
    [id]          INT          IDENTITY (1, 1) NOT NULL,
    [productname] VARCHAR (50) NOT NULL,
    [categoryid]  INT          NOT NULL,
    [stockamount] INT          NOT NULL,
    [price]       INT          NOT NULL,
    [isdeleted]   BIT          NOT NULL,
    [deleteddate] DATE         NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

