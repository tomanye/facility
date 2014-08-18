UPDATE dbo.ReceiveDoc 
SET SubProgramID =1000
WHERE SubProgramID =0


DELETE  FROM dbo.ProgramProduct
WHERE   ID NOT IN ( SELECT  MAX(ID)
                    FROM    dbo.ProgramProduct
                    GROUP BY ItemID ,
                            ProgramID )
