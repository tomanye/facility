ALTER TABLE [dbo].[UserStore]  WITH CHECK ADD  CONSTRAINT [FK_dbo_UserStore_UserID] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
GO 