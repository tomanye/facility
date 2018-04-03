 ALTER TABLE [dbo].[Model22] WITH CHECK
ADD CONSTRAINT [FK_Model22_IssueDocID]
    FOREIGN KEY ( [IssueDocID] )
    REFERENCES [dbo].[IssueDoc] ( [ID] )
 

ALTER TABLE [dbo].[Model22] CHECK CONSTRAINT [FK_Model22_IssueDocID]