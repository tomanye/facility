INSERT INTO dbo.UserCommodityType (   UserID ,
                                      TypeID
                                  )
  SELECT us.id UserID, ty.id TypeID FROM dbo.[User] us
LEFT JOIN   dbo.[Type] ty ON 1=1
LEFT JOIN dbo.UserCommodityType ut ON us.id = ut.UserID AND ty.id =ut.TypeID
WHERE ut.id IS NULL