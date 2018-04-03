CREATE TABLE [dbo].[Model22](
	 [ID] INT IDENTITY(1, 1) NOT NULL ,
        [IssueDocID] INT NOT NULL ,
        [PackQty] INT NULL ,
        [QtyPerPack] DECIMAL NULL ,
        [PackPrice] DECIMAL(16, 4) NULL ,
        [TotalPrice] DECIMAL(16, 4) NULL ,
        [TotalPackSellingPrice] DECIMAL(16, 4) NULL ,
        [priceRate] DECIMAL(16, 4) NULL ,
 CONSTRAINT [PK_Model22] PRIMARY KEY CLUSTERED 
(
	[ID] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)ON [PRIMARY]

 ALTER TABLE [dbo].[Model22] WITH CHECK
ADD CONSTRAINT [FK_Model22_IssueDocID]
    FOREIGN KEY ( [IssueDocID] )
    REFERENCES [dbo].[IssueDoc] ( [ID] )
 

ALTER TABLE [dbo].[Model22] CHECK CONSTRAINT [FK_Model22_IssueDocID]
 