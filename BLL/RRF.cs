
// Generated by MyGeneration Version # (1.3.0.9)

using System;
using System.Data;
using DAL;
using EthiopianDate;

namespace BLL
{
	public class RRF : _RRF
	{
		public RRF()
		{
		
		}

        public int AddNewRRF(int rrfType, int fromYear, int fromMonth,int toYear, int toMonth, bool overWriteOn)
        {
            if(RRFExists(rrfType,fromYear,fromMonth,toYear,toMonth))
            {
                if (!overWriteOn)
                    return -1;
            }
            else
            {
                this.AddNew();
            }

            //this.StoreID = storeID;
            this.RRFType = rrfType;
            this.FromYear = fromYear;
            this.FromMonth = fromMonth;
            this.ToMonth = toMonth;
            this.ToYear = toYear;
            this.DateOfSubmission = DateTime.Now;
            this.Save();
            return this.ID;
        }

        public bool RRFExists(int rrfType, int fromYear, int fromMonth,int toYear, int toMonth)
        {
            this.FlushData();
            //this.Where.StoreID.Value = storeID;
            this.Where.FromYear.Value = fromYear;
            this.Where.FromMonth.Value = fromMonth;
            this.Where.ToYear.Value = toYear;
            this.Where.ToMonth.Value = toMonth;
            this.Where.RRFType.Value = rrfType;
            this.Query.Load();
            return this.RowCount > 0;
        }

        public DataTable GetSavedRRFList()
        {
            this.FlushData();
            this.LoadAll();
            return this.DataTable;
        }

        public DataTable GetSavedRRFForDisplay()
        {
            this.FlushData();
            string query = "select ID,DateOfSubmission, LastRRFStatus, RRFType, cast(FromMonth as varchar) + ',' + cast(FromYear as varchar) + ' - ' + cast(ToMonth as varchar) + ',' + cast(ToYear as varchar) Period from RRF";
            this.LoadFromRawSql(query);
            this.AddColumn("DateOfSubmissionEth", typeof (string));
            this.AddColumn("RRFTypeText", typeof(string));
            
            while(!this.EOF)
            {
                string ethDate = this.IsColumnNull("DateOfSubmission")? "": EthiopianDate.EthiopianDate.GregorianToEthiopian(this.DateOfSubmission);
                this.SetColumn("DateOfSubmissionEth",ethDate);
                var str = new Stores();
                str.LoadByStoreID(this.RRFType);
                this.SetColumn("RRFTypeText", str.RowCount > 0 ? str.StoreName : "Unknown Store");
                this.MoveNext();
            }
            return this.DataTable;
        }
        public void UpdateSubProgram()
        {
            string query = string.Format(@"UPDATE ReceiveDoc
                                                SET SubProgramID = 1000
                                                    WHERE storeid = 8

                                                    UPDATE ReceiveDoc
                                                SET SubProgramID = 1001
                                                    WHERE storeid = 9

                                            UPDATE a
                                                SET a.ProgramID = subprogramID
                                                FROM ProgramProduct a INNER JOIN ReceiveDoc b ON a.ItemID = b.ItemID
                                                WHERE b.StoreID = 9

                                                --// ART lists

                                            UPDATE  a
                                            SET     a.ProgramID = 22
                                            FROM    ProgramProduct a
                                                    INNER JOIN ReceiveDoc b ON a.ItemID = b.ItemID
                                            WHERE   b.StoreID = 9
                                                    AND b.ItemID IN(100000, 100001, 100002, 100003, 100165, 100166,
                                                                      100167, 100168, 100169, 100170, 100171, 100627,
                                                                      100628, 100629, 100630, 100631, 100632, 100633,
                                                                      100634, 100635, 100636, 100637, 100638, 100639,
                                                                      100640, 100697, 100698, 100699, 100700, 100701,
                                                                      100702, 100703, 101131, 101132, 101133, 101134,
                                                                      101135, 101136, 101137, 101138, 101139, 101140,
                                                                      101141, 101142, 101143, 101144, 101145, 101146,
                                                                      101147, 101148, 101233, 101234, 101235, 101236,
                                                                      101460, 101461, 101462, 101463, 101832, 101833,
                                                                      101834, 101921, 101922, 101923, 101924, 101925,
                                                                      102181, 102182, 102183, 102184, 102185, 102186,
                                                                      300073, 300141, 300142, 300143, 300144, 300145,
                                                                      300186, 300370, 300371, 300372, 300373, 300569,
                                                                      300570, 500017, 500024, 500033, 500044, 500045,
                                                                      500046, 500047, 500065, 500066, 500067, 500103,
                                                                      500104, 500105, 500106, 500107, 500108, 500109,
                                                                      500110, 500111, 500112, 500113, 500114, 500115,
                                                                      500116, 500117, 500118, 500120, 500121, 500122,
                                                                      500123, 500132, 500133, 500134, 500135, 500136,
                                                                      500157, 500166, 500171, 500175, 500176, 500205,
                                                                      500206, 500217, 500218, 500219, 500220, 500221,
                                                                      500222, 500223, 500224, 500225, 500252, 500287,
                                                                      500288, 500314, 500330, 500435, 500436, 500437,
                                                                      500507, 500508, 500514, 500515, 500517, 500553,
                                                                      500554, 500555, 500556, 500557, 500568, 500569,
                                                                      500572, 500573)
                                             --// for recentil  recieved 
                                                UPDATE  ReceiveDoc
                                                SET     SubProgramID = 22
                                                WHERE   StoreID = 9
                                                        AND ItemID IN ( 100000, 100001, 100002, 100003, 100165, 100166,
                                                                        100167, 100168, 100169, 100170, 100171, 100627,
                                                                        100628, 100629, 100630, 100631, 100632, 100633,
                                                                        100634, 100635, 100636, 100637, 100638, 100639,
                                                                        100640, 100697, 100698, 100699, 100700, 100701,
                                                                        100702, 100703, 101131, 101132, 101133, 101134,
                                                                        101135, 101136, 101137, 101138, 101139, 101140,
                                                                        101141, 101142, 101143, 101144, 101145, 101146,
                                                                        101147, 101148, 101233, 101234, 101235, 101236,
                                                                        101460, 101461, 101462, 101463, 101832, 101833,
                                                                        101834, 101921, 101922, 101923, 101924, 101925,
                                                                        102181, 102182, 102183, 102184, 102185, 102186,
                                                                        300073, 300141, 300142, 300143, 300144, 300145,
                                                                        300186, 300370, 300371, 300372, 300373, 300569,
                                                                        300570, 500017, 500024, 500033, 500044, 500045,
                                                                        500046, 500047, 500065, 500066, 500067, 500103,
                                                                        500104, 500105, 500106, 500107, 500108, 500109,
                                                                        500110, 500111, 500112, 500113, 500114, 500115,
                                                                        500116, 500117, 500118, 500120, 500121, 500122,
                                                                        500123, 500132, 500133, 500134, 500135, 500136,
                                                                        500157, 500166, 500171, 500175, 500176, 500205,
                                                                        500206, 500217, 500218, 500219, 500220, 500221,
                                                                        500222, 500223, 500224, 500225, 500252, 500287,
                                                                        500288, 500314, 500330, 500435, 500436, 500437,
                                                                        500507, 500508, 500514, 500515, 500517, 500553,
                                                                        500554, 500555, 500556, 500557, 500568, 500569,
                                                                        500572, 500573 )
                                            --famly planing
                                            UPDATE  a
                                            SET     a.ProgramID = 24
                                            FROM    ProgramProduct a
                                                    INNER JOIN ReceiveDoc b ON a.ItemID = b.ItemID
                                            WHERE   b.StoreID = 9
                                                    AND b.ItemID IN ( 100797, 100799, 100800, 101111, 101182, 101183,
                                                                      101184, 101185, 101186, 101187, 101188, 101189,
                                                                      101190, 101191, 101192, 101193, 101271, 101272,
                                                                      101273, 101388, 101389, 101390, 101391, 101392,
                                                                      101393, 101394, 101395 )
                                            -- recently received famly planing
                                            UPDATE  ReceiveDoc
                                            SET     SubProgramID = 24
                                            WHERE   StoreID = 9
                                                    AND ItemID IN ( 100797, 100799, 100800, 101111, 101182, 101183, 101184,
                                                                    101185, 101186, 101187, 101188, 101189, 101190, 101191,
                                                                    101192, 101193, 101271, 101272, 101273, 101388, 101389,
                                                                    101390, 101391, 101392, 101393, 101394, 101395 )
                                        --// Malaria
                                        UPDATE  a
                                        SET     a.ProgramID = 20
                                        FROM    ProgramProduct a
                                                INNER JOIN ReceiveDoc b ON a.ItemID = b.ItemID
                                        WHERE   b.StoreID = 9
                                                AND b.ItemID IN ( 100153, 100154, 100155, 100156, 100157, 100158,
                                                                  100159, 100160, 100161, 100162, 100163, 100164,
                                                                  100400, 100401, 100402, 100403, 100404, 101774,
                                                                  101775, 101776, 101777, 101778, 300341, 500432 )
                                        --// recently recived
                                        UPDATE  ReceiveDoc
                                        SET     SubProgramID = 20
                                        WHERE   StoreID = 9
                                                AND ItemID IN ( 101395, 100154, 100155, 100156, 100157, 100158, 100159,
                                                                100160, 100161, 100162, 100163, 100164, 100400, 100401,
                                                                100402, 100403, 100404, 101774, 101775, 101776, 101777,
                                                                101778, 300341, 500432 )
                                    -- TB/LP
                                    UPDATE  a
                                    SET     a.ProgramID = 21
                                    FROM    ProgramProduct a
                                            INNER JOIN ReceiveDoc b ON a.ItemID = b.ItemID
                                    WHERE   b.StoreID = 9
                                            AND b.ItemID IN ( 100524, 100525, 100526, 100527, 100528, 100551,
                                                              100552, 100553, 100554, 100781, 100782, 100783,
                                                              100784, 101088, 101089, 101179, 101180, 101181,
                                                              101429, 101430, 101700, 101701, 101765, 101766,
                                                              101806, 101807, 101808, 101809, 101810, 101811,
                                                              101812, 101813, 101814, 101815, 101816, 101817,
                                                              101818, 101819, 101820, 101821, 101822, 101926,
                                                              300024, 300025, 300530, 300531, 300532, 300533,
                                                              300534, 500013, 500056, 500097, 500098, 500099,
                                                              500567 )
                                    --//recently received 
                                    UPDATE  ReceiveDoc
                                    SET     SubProgramID = 21
                                    WHERE   StoreID = 9
                                            AND ItemID IN ( 100524, 100525, 100526, 100527, 100528, 100551, 100552,
                                                            100553, 100554, 100781, 100782, 100783, 101088, 101089,
                                                            100784, 101179, 101180, 101181, 101429, 101430, 101700,
                                                            101701, 101765, 101766, 101806, 101807, 101808, 101809,
                                                            101810, 101811, 101812, 101813, 101814, 101815, 101816,
                                                            101817, 101818, 101819, 101820, 101821, 101822, 101926,
                                                            300024, 300025, 300530, 300531, 300532, 300533, 300534,
                                                            500013, 500056, 500097, 500098, 500099, 500567 )
                                --// vaccine
                                UPDATE  a
                                SET     a.ProgramID = 30
                                FROM    ProgramProduct a
                                        INNER JOIN ReceiveDoc b ON a.ItemID = b.ItemID
                                WHERE   b.StoreID = 9
                                        AND b.ItemID IN ( 100196, 100197, 100198, 100199, 100249, 100964,
                                                          100981, 100982, 100983, 100987, 100988, 101052,
                                                          101261, 101262, 101283, 101284, 101285, 101286,
                                                          101287, 101288, 101400, 101558, 101588, 101677,
                                                          101678, 101681, 101682, 101683, 101779, 101780,
                                                          101792, 101839, 102051, 102052, 102099, 102100,
                                                          102175, 102176, 102177, 102178, 102197, 300031,
                                                          300032 )

                                --// recently received
                                UPDATE  ReceiveDoc
                                SET     SubProgramID = 30
                                WHERE   StoreID = 9
                                        AND ItemID IN ( 100196, 100197, 100198, 100199, 100249, 100964, 100981,
                                                        100982, 100983, 100987, 100988, 101052, 101261, 101262,
                                                        101283, 101284, 101285, 101286, 101287, 101288, 101400,
                                                        101558, 01588, 101677, 101678, 101681, 101682, 101683,
                                                        101779, 101780, 101792, 101839, 102051, 102052, 102099,
                                                        102100, 102175, 102176, 102177, 102178, 102197, 300031,
                                                        300032 )");
            this.LoadFromRawSql(query); 
        }
    }
}
