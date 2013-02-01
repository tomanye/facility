Create TABLE [dbo].[Disposal](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ItemID] [int] NULL,
	[StoreId] [int] NULL,
	[ReasonId] [int] NULL,
	[Quantity] [bigint] NULL,
	[Date] [datetime] NULL,
	[ApprovedBy] [varchar](50) NULL,
	[Losses] [bit] NULL,
	[BatchNo] [varchar](50) NULL,
	[Remark] [text] NULL,
	[Cost] [float] NULL,
	[RefNo] [varchar](50) NULL,
	[EurDate] [datetime] NULL,
	[RecID] [int] NULL,
	[NoOfPack] [int] NULL,
	[QtyPerPack] [int] NULL,
 CONSTRAINT [PK_Disposal] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]