ALTER TABLE [dbo].[YearEndDetail]  WITH CHECK ADD  CONSTRAINT [FK_YearEndDetail_YearEnd] FOREIGN KEY([YearEndID]) REFERENCES [dbo].[YearEnd] ([ID])
ALTER TABLE [dbo].[YearEndDetail]  WITH CHECK ADD  CONSTRAINT [FK_YearEndDetail_ReceiveDoc] FOREIGN KEY([ReceiveDocID]) REFERENCES [dbo].[ReceiveDoc] ([ID])