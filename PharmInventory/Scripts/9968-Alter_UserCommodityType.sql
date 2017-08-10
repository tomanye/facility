ALTER TABLE [dbo].[UserCommodityType]  WITH CHECK ADD  CONSTRAINT [FK_dbo_UserCommodityType_TypeID] FOREIGN KEY([TypeID])
REFERENCES [dbo].[Type] ([ID])
GO 