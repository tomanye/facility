UPDATE dbo.ReceiveDoc
SET EurDate = (SELECT DISTINCT tr.EurDate FROM dbo.[Transfer] tr JOIN dbo.IssueDoc id ON tr.RecID = id.RecievDocID)
WHERE dbo.ReceiveDoc.EurDate IS null
