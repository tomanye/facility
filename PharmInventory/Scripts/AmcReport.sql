CREATE TABLE [dbo].[AmcReport](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ItemID] [int] NULL,
	[StoreID] [int] NULL,
	[AmcRange] [int] NULL,
	[IssueInAmcRange] [float] NULL,
	[DaysOutOfStock] [int] NULL,
	[AmcWithDos] [float] NULL,
	[AmcWithoutDos] [float] NULL,
	[LastIndexedTime] [datetime] NULL,
 CONSTRAINT [PK_AmcReport] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[AmcReport]  WITH CHECK ADD  CONSTRAINT [FK_AmcReport_Items] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Items] ([ID])
GO

ALTER TABLE [dbo].[AmcReport] CHECK CONSTRAINT [FK_AmcReport_Items]