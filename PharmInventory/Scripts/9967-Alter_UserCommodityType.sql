ALTER TABLE [dbo].[UserCommodityType]  WITH CHECK ADD  CONSTRAINT [FK_dbo_UserCommodityType_UserID] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
GO 
 
 