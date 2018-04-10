 

ALTER PROCEDURE [dbo].[SOHByPrograms]
    @progID INT ,
    @storeid INT ,
    @month INT ,
    @year INT ,
    @days INT
AS
    BEGIN
        DECLARE @tempdate VARCHAR(20);
	
        DECLARE @amcrange INT;
        DECLARE @min INT;
        DECLARE @max INT;
        DECLARE @eop FLOAT;

        SELECT  @amcrange = AMCRange ,
                @eop = EOP ,
                @min = Min ,
                @max = Max
        FROM    GeneralInfo; 
	
        DECLARE @rangedate DATETIME;
        DECLARE @todate DATETIME;
        DECLARE @fromdate DATETIME;
	
	
        SELECT  @tempdate = CAST(@month AS VARCHAR) + '/'
                + CAST(@days AS VARCHAR) + '/' + CAST(@year AS VARCHAR); 
        SELECT  @todate = CAST(@tempdate AS DATETIME);
        SELECT  @fromdate = CASE WHEN MONTH(@todate) <= 10
                                 THEN CAST('11/1/'
                                      + ( CAST(( @year - 1 ) AS VARCHAR) ) AS DATETIME)
                                 ELSE CAST('11/1/'
                                      + ( CAST(( @year ) AS VARCHAR) ) AS DATETIME)
                            END;	
        SELECT  @rangedate = DATEADD(MONTH, 0 - @amcrange, @todate);
				
        SELECT  t.* ,
                [Status] = CASE WHEN t.SOH IS NULL
                                     OR t.SOH = 0 THEN 'Stock Out'
                                WHEN t.SOH < t.EOP THEN 'Below EOP'
                                WHEN t.SOH < ( t.EOP * 1.25 ) THEN 'Near EOP'
                                WHEN t.SOH > t.[Max]
                                     AND t.AMC > 0 THEN 'Over Stocked'
                                ELSE 'Normal'
                           END ,
                ( t.SOH - ( t.Expired ) ) AS Dispatchable
        FROM    ( SELECT    CASE WHEN vw.ID IN ( SELECT DISTINCT
                                                        ItemID
                                                 FROM   ReceiveDoc
                                                 WHERE  StoreID = @storeid )
                                 THEN 1
                                 ELSE 0
                            END AS EverReceived ,
                            ISNULL(rd.Quantity, 0) AS Received ,
                            ISNULL(rd.QuantityLeft, 0) AS QuantityLeft ,
                            ISNULL(id.Quantity, 0) AS Issued ,
                            ISNULL(id2.Quantity, 0) AS IssuedMonth ,
                            ISNULL(loss.Quantity, 0) AS Lost ,
                            ISNULL(adj.Quantity, 0) AS Adjusted ,
                            ISNULL(amc.Quantity, 0) AS AMC ,
                            ( ISNULL(bb.Quantity, 0) + ISNULL(rd.Quantity, 0)
                              + ISNULL(adj.Quantity, 0) - ISNULL(id.Quantity,
                                                              0)
                              - ISNULL(loss.Quantity, 0) ) AS SOH ,
                            ISNULL(amc.Quantity * @min, 0) AS Min ,
                            ISNULL(amc.Quantity * @max, 0) AS Max ,
                            ISNULL(amc.Quantity * @eop, 0) AS EOP ,
                            ISNULL(ed.Quantity, 0) AS Expired ,
                            ISNULL(nEx.Quantity, 0) AS NearExpiry ,
                            vw.ID ,
                            vw.FullItemName ,
                            vw.StockCode ,
                            vw.Unit ,
                            vw.Name AS Type ,
                            vw.TypeID ,
                            p.ID AS ProgramID ,
                            p.Name AS ProgramName,
							vw.VEN ,
							ISNULL(vw.isPFSAVital,0) isPFSAVital
                  FROM      vwGetAllItems vw
                            LEFT JOIN ProgramProduct pp ON vw.ID = pp.ItemID
                            RIGHT JOIN ( SELECT *
                                         FROM   Programs
                                         WHERE  ID = @progID
                                       ) AS p ON pp.ProgramID = p.ID
                            LEFT JOIN ( SELECT  ItemID ,
                                                SUM(Quantity) Quantity ,
                                                SUM(QuantityLeft) QuantityLeft
                                        FROM    ReceiveDoc
                                        WHERE   StoreID = @storeid
                                                AND ( Date BETWEEN @fromdate AND @todate )
                                        GROUP BY ItemID
                                      ) AS rd ON rd.ItemID = vw.ID
                            LEFT JOIN ( SELECT  ItemID ,
                                                SUM(Quantity) Quantity
                                        FROM    IssueDoc
                                        WHERE   StoreId = @storeid
                                                AND ( Date BETWEEN @fromdate AND @todate )
                                        GROUP BY ItemID
                                      ) AS id ON id.ItemID = vw.ID
                            LEFT JOIN ( SELECT  ItemID ,
                                                SUM(Quantity) Quantity
                                        FROM    IssueDoc
                                        WHERE   StoreId = @storeid
                                                AND ( YEAR(Date) = @year
                                                      AND MONTH(Date) = @month
                                                    )
                                        GROUP BY ItemID
                                      ) AS id2 ON id2.ItemID = vw.ID
                            LEFT JOIN ( SELECT  ItemID ,
                                                SUM(PhysicalInventory) Quantity
                                        FROM    YearEnd
                                        WHERE   StoreID = @storeid
                                                AND Year = YEAR(@fromdate)
                                        GROUP BY ItemID
                                      ) AS bb ON bb.ItemID = vw.ID
                            LEFT JOIN ( SELECT  ItemID ,
                                                SUM(QuantityLeft) Quantity
                                        FROM    ReceiveDoc
                                        WHERE   StoreID = @storeid
                                                AND ExpDate < GETDATE()
                                        GROUP BY ItemID
                                      ) AS ed ON ed.ItemID = vw.ID
                            LEFT JOIN ( SELECT  ItemID ,
                                                SUM(QuantityLeft) Quantity
                                        FROM    ReceiveDoc rd
                                                JOIN vwGetAllItems v ON rd.ItemID = v.ID
                                        WHERE   StoreID = @storeid
                                                AND ExpDate BETWEEN GETDATE()
                                                            AND
                                                              DATEADD(DAY,
                                                              v.NearExpiryTrigger,
                                                              GETDATE())
                                        GROUP BY ItemID
                                      ) AS nEx ON nEx.ItemID = vw.ID
                            LEFT JOIN ( SELECT  MAX(AmcWithDos) AS Quantity ,
                                                ar.ItemID
                                        FROM    AmcReport ar
                                        WHERE   ar.StoreID = @storeid
                                        GROUP BY ItemID
                                      ) AS amc ON amc.ItemID = vw.ID
                            LEFT JOIN ( SELECT  ItemID ,
                                                SUM(Quantity) Quantity
                                        FROM    Disposal
                                        WHERE   StoreId = @storeid
                                                AND ( Date BETWEEN @fromdate AND @todate )
                                                AND Losses = 1
                                        GROUP BY ItemID
                                      ) AS loss ON loss.ItemID = vw.ID
                            LEFT JOIN ( SELECT  ItemID ,
                                                SUM(Quantity) Quantity
                                        FROM    Disposal
                                        WHERE   StoreId = @storeid
                                                AND ( Date BETWEEN @fromdate AND @todate )
                                                AND Losses = 0
                                        GROUP BY ItemID
                                      ) AS adj ON adj.ItemID = vw.ID
                  WHERE     vw.IsInHospitalList = 1
                ) t
        ORDER BY t.FullItemName
    END



