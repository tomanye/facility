UPDATE dbo.IssueDoc
SET EurDate = (SELECT DISTINCT tr.EurDate FROM dbo.[Transfer] tr JOIN dbo.ReceiveDoc rd ON tr.RecID = rd.ID)
WHERE dbo.IssueDoc.EurDate IS null
