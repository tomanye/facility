
CREATE TABLE [dbo].[Model22](
	    [ID] INT IDENTITY(1, 1) NOT NULL ,
        [IssueDocID] INT NOT NULL ,
        [PackQty] DECIMAL NULL ,
        [QtyPerPack] DECIMAL NULL ,
        [PackPrice] DECIMAL(16, 4) NULL ,
        [TotalPrice] DECIMAL(16, 4) NULL ,
        [TotalPackSellingPrice] DECIMAL(16, 4) NULL ,
        [priceRate] DECIMAL(16, 4) NULL ,
	    [PackSellingPrice] DECIMAL(16, 4) NULL ,
	    [UnitSellingPrice] DECIMAL(16, 4) NULL ,
		[ExpiryDate] DATETIME NULL,
		[IssuedBy] NVARCHAR(100) NULL,
 CONSTRAINT [PK_Model22] PRIMARY KEY CLUSTERED 
(
	[ID] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)ON [PRIMARY]

 
 