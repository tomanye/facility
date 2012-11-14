CREATE TABLE [dbo].[ReceiveDocDeleted](
	[ID] [int] NOT NULL,
	[BatchNo] [varchar](50) NULL,
	[ItemID] [int] NULL,
	[SupplierID] [int] NULL,
	[Quantity] [bigint] NULL,
	[Date] [datetime] NULL,
	[ExpDate] [datetime] NULL,
	[Out] [bit] NULL,
	[ReceivedStatus] [int] NULL,
	[ReceivedBy] [varchar](50) NULL,
	[Remark] [text] NULL,
	[StoreID] [int] NULL,
	[LocalBatchNo] [varchar](50) NULL,
	[RefNo] [varchar](50) NULL,
	[Cost] [float] NULL,
	[IsApproved] [bit] NULL,
	[ManufacturerId] [int] NULL,
	[QuantityLeft] [bigint] NULL,
	[NoOfPack] [int] NULL,
	[QtyPerPack] [int] NULL,
	[BoxLevel] [int] NULL,
	[EurDate] [datetime] NULL,
	[SubProgramID] [int] NULL,
 CONSTRAINT [PK_ReceiveDocDeleted] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


SET ANSI_PADDING OFF

ALTER TABLE [dbo].[ReceiveDocDeleted]  WITH CHECK ADD  CONSTRAINT [FK_ReceiveDocDeleted_Items] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Items] ([ID])

ALTER TABLE [dbo].[ReceiveDocDeleted] CHECK CONSTRAINT [FK_ReceiveDocDeleted_Items]

ALTER TABLE [dbo].[ReceiveDocDeleted]  WITH CHECK ADD  CONSTRAINT [FK_ReceiveDocDeleted_Manufactures] FOREIGN KEY([ManufacturerId])
REFERENCES [dbo].[Manufacturers] ([ID])

ALTER TABLE [dbo].[ReceiveDocDeleted] CHECK CONSTRAINT [FK_ReceiveDocDeleted_Manufactures]

ALTER TABLE [dbo].[ReceiveDocDeleted]  WITH CHECK ADD  CONSTRAINT [FK_ReceiveDocDeleted_Supplier] FOREIGN KEY([SupplierID])
REFERENCES [dbo].[Supplier] ([ID])

ALTER TABLE [dbo].[ReceiveDocDeleted] CHECK CONSTRAINT [FK_ReceiveDocDeleted_Supplier]

ALTER TABLE [dbo].[ReceiveDocDeleted] ADD  CONSTRAINT [DF_ReceiveDocDeleted_Out]  DEFAULT ((0)) FOR [Out]

ALTER TABLE [dbo].[ReceiveDocDeleted] ADD  CONSTRAINT [DF_ReceiveDocDeleted_IsApproved]  DEFAULT ((0)) FOR [IsApproved]

ALTER TABLE [dbo].[ReceiveDocDeleted] ADD  CONSTRAINT [DF_ReceiveDocDeleted_QuantityLeft]  DEFAULT ((0)) FOR [QuantityLeft]

ALTER TABLE [dbo].[ReceiveDocDeleted] ADD  CONSTRAINT [DF_ReceiveDocDeleted_NoOfPack]  DEFAULT ((0)) FOR [NoOfPack]

ALTER TABLE [dbo].[ReceiveDocDeleted] ADD  CONSTRAINT [DF_ReceiveDocDeleted_QtyPerPack]  DEFAULT ((0)) FOR [QtyPerPack]


