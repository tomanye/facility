CREATE TABLE [dbo].[VRFDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[VRFID] [int] NULL,
	[StoreID] [int] NULL,
	[ItemID] [int] NULL,
	[Doses] [int] NULL,
	[WasteFactor] [decimal] NULL,
	[TargetCoverage] [int] NULL,
        [RequestedQuantity] [int] NULL,
	[VaccinationGiven] [int] NULL,
	[Remark] [varchar(100)] NULL,

 CONSTRAINT [PK_VRFDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[VRFDetail]  WITH CHECK ADD  CONSTRAINT [FK_VRFDetail_Items] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Items] ([ID])
GO

ALTER TABLE [dbo].[VRFDetail] CHECK CONSTRAINT [FK_VRFDetail_Items]
GO

ALTER TABLE [dbo].[VRFDetail]  WITH CHECK ADD  CONSTRAINT [FK_VRFDetail_VRF] FOREIGN KEY([VRFID])
REFERENCES [dbo].[VRF] ([ID])
GO

ALTER TABLE [dbo].[VRFDetail] CHECK CONSTRAINT [FK_VRFDetail_VRF]
GO

ALTER TABLE [dbo].[VRFDetail]  WITH CHECK ADD  CONSTRAINT [FK_VRFDetail_Stores] FOREIGN KEY([StoreID])
REFERENCES [dbo].[Stores] ([ID])
GO

ALTER TABLE [dbo].[VRFDetail] CHECK CONSTRAINT [FK_VRFDetail_Stores]
GO


