using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Specialized;

using MyGeneration.dOOdads;
namespace DAL
{
   public abstract class _Transfer :SqlClientEntity
    {
       public _Transfer()
       {
           this.QuerySource = "Transfer";
           this.MappingName = "Transfer";
       }

       public override void FlushData()
       {
           this._whereClause = null;
           this._aggregateClause = null;
           base.FlushData();
       }

       //=================================================================
       //  	public Function LoadAll() As Boolean
       //=================================================================
       //  Loads all of the records in the database, and sets the currentRow to the first row
       //=================================================================
       public bool LoadAll()
       {
           ListDictionary parameters = null;

           return base.LoadFromSql("[" + this.SchemaStoredProcedure + "proc_TransferLoadAll]", parameters);
       }

       //=================================================================
       // public Overridable Function LoadByPrimaryKey()  As Boolean
       //=================================================================
       //  Loads a single row of via the primary key
       //=================================================================
       public virtual bool LoadByPrimaryKey(int ID)
       {
           ListDictionary parameters = new ListDictionary();
           parameters.Add(_Transfer.Parameters.ID, ID);


           return base.LoadFromSql("[" + this.SchemaStoredProcedure + "proc_TransferLoadByPrimaryKey]", parameters);
       }

       #region Parameters
       protected class Parameters
       {

           public static SqlParameter ID
           {
               get
               {
                   return new SqlParameter("@ID", SqlDbType.Int, 0);
               }
           }

           public static SqlParameter BatchNo
           {
               get
               {
                   return new SqlParameter("@BatchNo", SqlDbType.VarChar, 50);
               }
           }

           public static SqlParameter ItemID
           {
               get
               {
                   return new SqlParameter("@ItemID", SqlDbType.Int, 0);
               }
           }

           public static SqlParameter SupplierID
           {
               get
               {
                   return new SqlParameter("@SupplierID", SqlDbType.Int, 0);
               }
           }

           public static SqlParameter Quantity
           {
               get
               {
                   return new SqlParameter("@Quantity", SqlDbType.BigInt, 0);
               }
           }

           public static SqlParameter Date
           {
               get
               {
                   return new SqlParameter("@Date", SqlDbType.DateTime, 0);
               }
           }

           public static SqlParameter ExpDate
           {
               get
               {
                   return new SqlParameter("@ExpDate", SqlDbType.DateTime, 0);
               }
           }

           public static SqlParameter Out
           {
               get
               {
                   return new SqlParameter("@Out", SqlDbType.Bit, 0);
               }
           }

           public static SqlParameter ReceivedStatus
           {
               get
               {
                   return new SqlParameter("@ReceivedStatus", SqlDbType.Int, 0);
               }
           }

           public static SqlParameter ReceivedBy
           {
               get
               {
                   return new SqlParameter("@ReceivedBy", SqlDbType.VarChar, 50);
               }
           }

           public static SqlParameter Remark
           {
               get
               {
                   return new SqlParameter("@Remark", SqlDbType.Text, 2147483647);
               }
           }

           public static SqlParameter FromStoreID
           {
               get
               {
                   return new SqlParameter("@FromStoreID", SqlDbType.Int, 0);
               }
           }

           public static SqlParameter ToStoreID
           {
               get
               {
                   return new SqlParameter("@ToStoreID", SqlDbType.Int, 0);
               }
           }

           public static SqlParameter LocalBatchNo
           {
               get
               {
                   return new SqlParameter("@LocalBatchNo", SqlDbType.VarChar, 50);
               }
           }

           public static SqlParameter RefNo
           {
               get
               {
                   return new SqlParameter("@RefNo", SqlDbType.VarChar, 50);
               }
           }

           public static SqlParameter Cost
           {
               get
               {
                   return new SqlParameter("@Cost", SqlDbType.Float, 0);
               }
           }

           public static SqlParameter IsApproved
           {
               get
               {
                   return new SqlParameter("@IsApproved", SqlDbType.Bit, 0);
               }
           }

           public static SqlParameter ManufacturerId
           {
               get
               {
                   return new SqlParameter("@ManufacturerId", SqlDbType.Int, 0);
               }
           }

           public static SqlParameter QuantityLeft
           {
               get
               {
                   return new SqlParameter("@QuantityLeft", SqlDbType.BigInt, 0);
               }
           }

           public static SqlParameter NoOfPack
           {
               get
               {
                   return new SqlParameter("@NoOfPack", SqlDbType.Int, 0);
               }
           }

           public static SqlParameter QtyPerPack
           {
               get
               {
                   return new SqlParameter("@QtyPerPack", SqlDbType.Int, 0);
               }
           }

           public static SqlParameter EurDate
           {
               get
               {
                   return new SqlParameter("@EurDate", SqlDbType.DateTime, 0);
               }
           }

           public static SqlParameter BoxLevel
           {
               get
               {
                   return new SqlParameter("@BoxLevel", SqlDbType.Int, 0);
               }
           }

           public static SqlParameter SubProgramID
           {
               get
               {
                   return new SqlParameter("@SubProgramID", SqlDbType.Int, 0);
               }
           }
       }
       #endregion

       #region ColumnNames
       public class ColumnNames
       {
           public const string ID = "ID";
           public const string BatchNo = "BatchNo";
           public const string ItemID = "ItemID";
           public const string SupplierID = "SupplierID";
           public const string Quantity = "Quantity";
           public const string Date = "Date";
           public const string ExpDate = "ExpDate";
           public const string Out = "Out";
           public const string ReceivedStatus = "ReceivedStatus";
           public const string ReceivedBy = "ReceivedBy";
           public const string Remark = "Remark";
           public const string FromStoreID = "FromStoreID";
           public const string ToStoreID = "ToStoreID";
           public const string LocalBatchNo = "LocalBatchNo";
           public const string RefNo = "RefNo";
           public const string Cost = "Cost";
           public const string IsApproved = "IsApproved";
           public const string ManufacturerId = "ManufacturerId";
           public const string QuantityLeft = "QuantityLeft";
           public const string NoOfPack = "NoOfPack";
           public const string QtyPerPack = "QtyPerPack";
           public const string EurDate = "EurDate";
           public const string BoxLevel = "BoxLevel";
           public const string SubProgramID = "SubProgramID";

           static public string ToPropertyName(string columnName)
           {
               if (ht == null)
               {
                   ht = new Hashtable();

                   ht[ID] = _Transfer.PropertyNames.ID;
                   ht[BatchNo] = _Transfer.PropertyNames.BatchNo;
                   ht[ItemID] = _Transfer.PropertyNames.ItemID;
                   ht[SupplierID] = _Transfer.PropertyNames.SupplierID;
                   ht[Quantity] = _Transfer.PropertyNames.Quantity;
                   ht[Date] = _Transfer.PropertyNames.Date;
                   ht[ExpDate] = _Transfer.PropertyNames.ExpDate;
                   ht[Out] = _Transfer.PropertyNames.Out;
                   ht[ReceivedStatus] = _Transfer.PropertyNames.ReceivedStatus;
                   ht[ReceivedBy] = _Transfer.PropertyNames.ReceivedBy;
                   ht[Remark] = _Transfer.PropertyNames.Remark;
                   ht[FromStoreID] = _Transfer.PropertyNames.FromStoreID;
                   ht[ToStoreID] = _Transfer.PropertyNames.ToStoreID;
                   ht[LocalBatchNo] = _Transfer.PropertyNames.LocalBatchNo;
                   ht[RefNo] = _Transfer.PropertyNames.RefNo;
                   ht[Cost] = _Transfer.PropertyNames.Cost;
                   ht[IsApproved] = _Transfer.PropertyNames.IsApproved;
                   ht[ManufacturerId] = _Transfer.PropertyNames.ManufacturerId;
                   ht[QuantityLeft] = _Transfer.PropertyNames.QuantityLeft;
                   ht[NoOfPack] = _Transfer.PropertyNames.NoOfPack;
                   ht[QtyPerPack] = _Transfer.PropertyNames.QtyPerPack;
                   ht[EurDate] = _Transfer.PropertyNames.EurDate;
                   ht[BoxLevel] = _Transfer.PropertyNames.BoxLevel;
                   ht[SubProgramID] = _Transfer.PropertyNames.SubProgramID;

               }
               return (string)ht[columnName];
           }

           static private Hashtable ht = null;
       }
       #endregion

       #region PropertyNames
       public class PropertyNames
       {
           public const string ID = "ID";
           public const string BatchNo = "BatchNo";
           public const string ItemID = "ItemID";
           public const string SupplierID = "SupplierID";
           public const string Quantity = "Quantity";
           public const string Date = "Date";
           public const string ExpDate = "ExpDate";
           public const string Out = "Out";
           public const string ReceivedStatus = "ReceivedStatus";
           public const string ReceivedBy = "ReceivedBy";
           public const string Remark = "Remark";
           public const string FromStoreID = "FromStoreID";
           public const string ToStoreID = "ToStoreID";
           public const string LocalBatchNo = "LocalBatchNo";
           public const string RefNo = "RefNo";
           public const string Cost = "Cost";
           public const string IsApproved = "IsApproved";
           public const string ManufacturerId = "ManufacturerId";
           public const string QuantityLeft = "QuantityLeft";
           public const string NoOfPack = "NoOfPack";
           public const string QtyPerPack = "QtyPerPack";
           public const string EurDate = "EurDate";
           public const string BoxLevel = "BoxLevel";
           public const string SubProgramID = "SubProgramID";

           static public string ToColumnName(string propertyName)
           {
               if (ht == null)
               {
                   ht = new Hashtable();

                   ht[ID] = _Transfer.ColumnNames.ID;
                   ht[BatchNo] = _Transfer.ColumnNames.BatchNo;
                   ht[ItemID] = _Transfer.ColumnNames.ItemID;
                   ht[SupplierID] = _Transfer.ColumnNames.SupplierID;
                   ht[Quantity] = _Transfer.ColumnNames.Quantity;
                   ht[Date] = _Transfer.ColumnNames.Date;
                   ht[ExpDate] = _Transfer.ColumnNames.ExpDate;
                   ht[Out] = _Transfer.ColumnNames.Out;
                   ht[ReceivedStatus] = _Transfer.ColumnNames.ReceivedStatus;
                   ht[ReceivedBy] = _Transfer.ColumnNames.ReceivedBy;
                   ht[Remark] = _Transfer.ColumnNames.Remark;
                   ht[FromStoreID] = _Transfer.ColumnNames.FromStoreID;
                   ht[ToStoreID] = _Transfer.ColumnNames.ToStoreID;
                   ht[LocalBatchNo] = _Transfer.ColumnNames.LocalBatchNo;
                   ht[RefNo] = _Transfer.ColumnNames.RefNo;
                   ht[Cost] = _Transfer.ColumnNames.Cost;
                   ht[IsApproved] = _Transfer.ColumnNames.IsApproved;
                   ht[ManufacturerId] = _Transfer.ColumnNames.ManufacturerId;
                   ht[QuantityLeft] = _Transfer.ColumnNames.QuantityLeft;
                   ht[NoOfPack] = _Transfer.ColumnNames.NoOfPack;
                   ht[QtyPerPack] = _Transfer.ColumnNames.QtyPerPack;
                   ht[EurDate] = _Transfer.ColumnNames.EurDate;
                   ht[BoxLevel] = _Transfer.ColumnNames.BoxLevel;
                   ht[SubProgramID] = _Transfer.ColumnNames.SubProgramID;
               }
               return (string)ht[propertyName];
           }

           static private Hashtable ht = null;
       }
       #endregion

       #region StringPropertyNames
       public class StringPropertyNames
       {
           public const string ID = "s_ID";
           public const string BatchNo = "s_BatchNo";
           public const string ItemID = "s_ItemID";
           public const string SupplierID = "s_SupplierID";
           public const string Quantity = "s_Quantity";
           public const string Date = "s_Date";
           public const string ExpDate = "s_ExpDate";
           public const string Out = "s_Out";
           public const string ReceivedStatus = "s_ReceivedStatus";
           public const string ReceivedBy = "s_ReceivedBy";
           public const string Remark = "s_Remark";
           public const string FromStoreID = "s_FromStoreID";
           public const string ToStoreID = "s_ToStoreID";
           public const string LocalBatchNo = "s_LocalBatchNo";
           public const string RefNo = "s_RefNo";
           public const string Cost = "s_Cost";
           public const string IsApproved = "s_IsApproved";
           public const string ManufacturerId = "s_ManufacturerId";
           public const string QuantityLeft = "s_QuantityLeft";
           public const string NoOfPack = "s_NoOfPack";
           public const string QtyPerPack = "s_QtyPerPack";
           public const string EurDate = "s_EurDate";
           public const string BoxLevel = "s_BoxLevel";
           public const string SubProgramID = "s_SubProgramID";
       }
       #endregion

       #region Properties

       public virtual int ID
       {
           get
           {
               return base.Getint(_Transfer.ColumnNames.ID);
           }
           set
           {
               base.Setint(_Transfer.ColumnNames.ID, value);
           }
       }

       public virtual string BatchNo
       {
           get
           {
               return base.Getstring(_Transfer.ColumnNames.BatchNo);
           }
           set
           {
               base.Setstring(_Transfer.ColumnNames.BatchNo, value);
           }
       }

       public virtual int ItemID
       {
           get
           {
               return base.Getint(_Transfer.ColumnNames.ItemID);
           }
           set
           {
               base.Setint(_Transfer.ColumnNames.ItemID, value);
           }
       }

       public virtual int SupplierID
       {
           get
           {
               return base.Getint(_Transfer.ColumnNames.SupplierID);
           }
           set
           {
               base.Setint(_Transfer.ColumnNames.SupplierID, value);
           }
       }

       public virtual long Quantity
       {
           get
           {
               return base.Getlong(_Transfer.ColumnNames.Quantity);
           }
           set
           {
               base.Setlong(_Transfer.ColumnNames.Quantity, value);
           }
       }

       public virtual DateTime Date
       {
           get
           {
               return base.GetDateTime(_Transfer.ColumnNames.Date);
           }
           set
           {
               base.SetDateTime(_Transfer.ColumnNames.Date, value);
           }
       }

       public virtual DateTime ExpDate
       {
           get
           {
               return base.GetDateTime(_Transfer.ColumnNames.ExpDate);
           }
           set
           {
               base.SetDateTime(_Transfer.ColumnNames.ExpDate, value);
           }
       }

       public virtual bool Out
       {
           get
           {
               return base.Getbool(_Transfer.ColumnNames.Out);
           }
           set
           {
               base.Setbool(_Transfer.ColumnNames.Out, value);
           }
       }

       public virtual int ReceivedStatus
       {
           get
           {
               return base.Getint(_Transfer.ColumnNames.ReceivedStatus);
           }
           set
           {
               base.Setint(_Transfer.ColumnNames.ReceivedStatus, value);
           }
       }

       public virtual string ReceivedBy
       {
           get
           {
               return base.Getstring(_Transfer.ColumnNames.ReceivedBy);
           }
           set
           {
               base.Setstring(_Transfer.ColumnNames.ReceivedBy, value);
           }
       }

       public virtual string Remark
       {
           get
           {
               return base.Getstring(_Transfer.ColumnNames.Remark);
           }
           set
           {
               base.Setstring(_Transfer.ColumnNames.Remark, value);
           }
       }

       public virtual int FromStoreID
       {
           get
           {
               return base.Getint(_Transfer.ColumnNames.FromStoreID);
           }
           set
           {
               base.Setint(_Transfer.ColumnNames.FromStoreID, value);
           }
       }

       public virtual int ToStoreID
       {
           get
           {
               return base.Getint(_Transfer.ColumnNames.ToStoreID);
           }
           set
           {
               base.Setint(_Transfer.ColumnNames.ToStoreID, value);
           }
       }

       public virtual string LocalBatchNo
       {
           get
           {
               return base.Getstring(_Transfer.ColumnNames.LocalBatchNo);
           }
           set
           {
               base.Setstring(_Transfer.ColumnNames.LocalBatchNo, value);
           }
       }

       public virtual string RefNo
       {
           get
           {
               return base.Getstring(_Transfer.ColumnNames.RefNo);
           }
           set
           {
               base.Setstring(_Transfer.ColumnNames.RefNo, value);
           }
       }

       public virtual double Cost
       {
           get
           {
               return base.Getdouble(_Transfer.ColumnNames.Cost);
           }
           set
           {
               base.Setdouble(_Transfer.ColumnNames.Cost, value);
           }
       }

       public virtual bool IsApproved
       {
           get
           {
               return base.Getbool(_Transfer.ColumnNames.IsApproved);
           }
           set
           {
               base.Setbool(_Transfer.ColumnNames.IsApproved, value);
           }
       }

       public virtual int ManufacturerId
       {
           get
           {
               return base.Getint(_Transfer.ColumnNames.ManufacturerId);
           }
           set
           {
               base.Setint(_Transfer.ColumnNames.ManufacturerId, value);
           }
       }

       public virtual long QuantityLeft
       {
           get
           {
               return base.Getlong(_Transfer.ColumnNames.QuantityLeft);
           }
           set
           {
               base.Setlong(_Transfer.ColumnNames.QuantityLeft, value);
           }
       }

       public virtual int NoOfPack
       {
           get
           {
               return base.Getint(_Transfer.ColumnNames.NoOfPack);
           }
           set
           {
               base.Setint(_Transfer.ColumnNames.NoOfPack, value);
           }
       }

       public virtual int QtyPerPack
       {
           get
           {
               return base.Getint(_Transfer.ColumnNames.QtyPerPack);
           }
           set
           {
               base.Setint(_Transfer.ColumnNames.QtyPerPack, value);
           }
       }

       public virtual DateTime EurDate
       {
           get
           {
               return base.GetDateTime(_Transfer.ColumnNames.EurDate);
           }
           set
           {
               base.SetDateTime(_Transfer.ColumnNames.EurDate, value);
           }
       }

       public virtual int BoxLevel
       {
           get
           {
               return base.Getint(_Transfer.ColumnNames.BoxLevel);
           }
           set
           {
               base.Setint(_Transfer.ColumnNames.BoxLevel, value);
           }
       }

       public virtual int SubProgramID
       {
           get
           {
               return base.Getint(_Transfer.ColumnNames.SubProgramID);
           }
           set
           {
               base.Setint(_Transfer.ColumnNames.SubProgramID, value);
           }
       }

       #endregion

       #region String Properties

       public virtual string s_ID
       {
           get
           {
               return this.IsColumnNull(_Transfer.ColumnNames.ID) ? string.Empty : base.GetintAsString(_Transfer.ColumnNames.ID);
           }
           set
           {
               if (string.Empty == value)
                   this.SetColumnNull(_Transfer.ColumnNames.ID);
               else
                   this.ID = base.SetintAsString(_Transfer.ColumnNames.ID, value);
           }
       }

       public virtual string s_BatchNo
       {
           get
           {
               return this.IsColumnNull(_Transfer.ColumnNames.BatchNo) ? string.Empty : base.GetstringAsString(_Transfer.ColumnNames.BatchNo);
           }
           set
           {
               if (string.Empty == value)
                   this.SetColumnNull(_Transfer.ColumnNames.BatchNo);
               else
                   this.BatchNo = base.SetstringAsString(_Transfer.ColumnNames.BatchNo, value);
           }
       }

       public virtual string s_ItemID
       {
           get
           {
               return this.IsColumnNull(_Transfer.ColumnNames.ItemID) ? string.Empty : base.GetintAsString(_Transfer.ColumnNames.ItemID);
           }
           set
           {
               if (string.Empty == value)
                   this.SetColumnNull(_Transfer.ColumnNames.ItemID);
               else
                   this.ItemID = base.SetintAsString(_Transfer.ColumnNames.ItemID, value);
           }
       }

       public virtual string s_SupplierID
       {
           get
           {
               return this.IsColumnNull(_Transfer.ColumnNames.SupplierID) ? string.Empty : base.GetintAsString(_Transfer.ColumnNames.SupplierID);
           }
           set
           {
               if (string.Empty == value)
                   this.SetColumnNull(_Transfer.ColumnNames.SupplierID);
               else
                   this.SupplierID = base.SetintAsString(_Transfer.ColumnNames.SupplierID, value);
           }
       }

       public virtual string s_Quantity
       {
           get
           {
               return this.IsColumnNull(_Transfer.ColumnNames.Quantity) ? string.Empty : base.GetlongAsString(_Transfer.ColumnNames.Quantity);
           }
           set
           {
               if (string.Empty == value)
                   this.SetColumnNull(_Transfer.ColumnNames.Quantity);
               else
                   this.Quantity = base.SetlongAsString(_Transfer.ColumnNames.Quantity, value);
           }
       }

       public virtual string s_Date
       {
           get
           {
               return this.IsColumnNull(_Transfer.ColumnNames.Date) ? string.Empty : base.GetDateTimeAsString(_Transfer.ColumnNames.Date);
           }
           set
           {
               if (string.Empty == value)
                   this.SetColumnNull(_Transfer.ColumnNames.Date);
               else
                   this.Date = base.SetDateTimeAsString(_Transfer.ColumnNames.Date, value);
           }
       }

       public virtual string s_ExpDate
       {
           get
           {
               return this.IsColumnNull(_Transfer.ColumnNames.ExpDate) ? string.Empty : base.GetDateTimeAsString(_Transfer.ColumnNames.ExpDate);
           }
           set
           {
               if (string.Empty == value)
                   this.SetColumnNull(_Transfer.ColumnNames.ExpDate);
               else
                   this.ExpDate = base.SetDateTimeAsString(_Transfer.ColumnNames.ExpDate, value);
           }
       }

       public virtual string s_Out
       {
           get
           {
               return this.IsColumnNull(_Transfer.ColumnNames.Out) ? string.Empty : base.GetboolAsString(_Transfer.ColumnNames.Out);
           }
           set
           {
               if (string.Empty == value)
                   this.SetColumnNull(_Transfer.ColumnNames.Out);
               else
                   this.Out = base.SetboolAsString(_Transfer.ColumnNames.Out, value);
           }
       }

       public virtual string s_ReceivedStatus
       {
           get
           {
               return this.IsColumnNull(_Transfer.ColumnNames.ReceivedStatus) ? string.Empty : base.GetintAsString(_Transfer.ColumnNames.ReceivedStatus);
           }
           set
           {
               if (string.Empty == value)
                   this.SetColumnNull(_Transfer.ColumnNames.ReceivedStatus);
               else
                   this.ReceivedStatus = base.SetintAsString(_Transfer.ColumnNames.ReceivedStatus, value);
           }
       }

       public virtual string s_ReceivedBy
       {
           get
           {
               return this.IsColumnNull(_Transfer.ColumnNames.ReceivedBy) ? string.Empty : base.GetstringAsString(_Transfer.ColumnNames.ReceivedBy);
           }
           set
           {
               if (string.Empty == value)
                   this.SetColumnNull(_Transfer.ColumnNames.ReceivedBy);
               else
                   this.ReceivedBy = base.SetstringAsString(_Transfer.ColumnNames.ReceivedBy, value);
           }
       }

       public virtual string s_Remark
       {
           get
           {
               return this.IsColumnNull(_Transfer.ColumnNames.Remark) ? string.Empty : base.GetstringAsString(_Transfer.ColumnNames.Remark);
           }
           set
           {
               if (string.Empty == value)
                   this.SetColumnNull(_Transfer.ColumnNames.Remark);
               else
                   this.Remark = base.SetstringAsString(_Transfer.ColumnNames.Remark, value);
           }
       }

       public virtual string s_FromStoreID
       {
           get
           {
               return this.IsColumnNull(_Transfer.ColumnNames.FromStoreID) ? string.Empty : base.GetintAsString(_Transfer.ColumnNames.FromStoreID);
           }
           set
           {
               if (string.Empty == value)
                   this.SetColumnNull(_Transfer.ColumnNames.FromStoreID);
               else
                   this.FromStoreID = base.SetintAsString(_Transfer.ColumnNames.FromStoreID, value);
           }
       }

       public virtual string s_ToStoreID
       {
           get
           {
               return this.IsColumnNull(_Transfer.ColumnNames.ToStoreID) ? string.Empty : base.GetintAsString(_Transfer.ColumnNames.ToStoreID);
           }
           set
           {
               if (string.Empty == value)
                   this.SetColumnNull(_Transfer.ColumnNames.ToStoreID);
               else
                   this.ToStoreID = base.SetintAsString(_Transfer.ColumnNames.ToStoreID, value);
           }
       }

       public virtual string s_LocalBatchNo
       {
           get
           {
               return this.IsColumnNull(_Transfer.ColumnNames.LocalBatchNo) ? string.Empty : base.GetstringAsString(_Transfer.ColumnNames.LocalBatchNo);
           }
           set
           {
               if (string.Empty == value)
                   this.SetColumnNull(_Transfer.ColumnNames.LocalBatchNo);
               else
                   this.LocalBatchNo = base.SetstringAsString(_Transfer.ColumnNames.LocalBatchNo, value);
           }
       }

       public virtual string s_RefNo
       {
           get
           {
               return this.IsColumnNull(_Transfer.ColumnNames.RefNo) ? string.Empty : base.GetstringAsString(_Transfer.ColumnNames.RefNo);
           }
           set
           {
               if (string.Empty == value)
                   this.SetColumnNull(_Transfer.ColumnNames.RefNo);
               else
                   this.RefNo = base.SetstringAsString(_Transfer.ColumnNames.RefNo, value);
           }
       }

       public virtual string s_Cost
       {
           get
           {
               return this.IsColumnNull(_Transfer.ColumnNames.Cost) ? string.Empty : base.GetdoubleAsString(_Transfer.ColumnNames.Cost);
           }
           set
           {
               if (string.Empty == value)
                   this.SetColumnNull(_Transfer.ColumnNames.Cost);
               else
                   this.Cost = base.SetdoubleAsString(_Transfer.ColumnNames.Cost, value);
           }
       }

       public virtual string s_IsApproved
       {
           get
           {
               return this.IsColumnNull(_Transfer.ColumnNames.IsApproved) ? string.Empty : base.GetboolAsString(_Transfer.ColumnNames.IsApproved);
           }
           set
           {
               if (string.Empty == value)
                   this.SetColumnNull(_Transfer.ColumnNames.IsApproved);
               else
                   this.IsApproved = base.SetboolAsString(_Transfer.ColumnNames.IsApproved, value);
           }
       }

       public virtual string s_ManufacturerId
       {
           get
           {
               return this.IsColumnNull(_Transfer.ColumnNames.ManufacturerId) ? string.Empty : base.GetintAsString(_Transfer.ColumnNames.ManufacturerId);
           }
           set
           {
               if (string.Empty == value)
                   this.SetColumnNull(_Transfer.ColumnNames.ManufacturerId);
               else
                   this.ManufacturerId = base.SetintAsString(_Transfer.ColumnNames.ManufacturerId, value);
           }
       }

       public virtual string s_QuantityLeft
       {
           get
           {
               return this.IsColumnNull(_Transfer.ColumnNames.QuantityLeft) ? string.Empty : base.GetlongAsString(_Transfer.ColumnNames.QuantityLeft);
           }
           set
           {
               if (string.Empty == value)
                   this.SetColumnNull(_Transfer.ColumnNames.QuantityLeft);
               else
                   this.QuantityLeft = base.SetlongAsString(_Transfer.ColumnNames.QuantityLeft, value);
           }
       }

       public virtual string s_NoOfPack
       {
           get
           {
               return this.IsColumnNull(_Transfer.ColumnNames.NoOfPack) ? string.Empty : base.GetintAsString(_Transfer.ColumnNames.NoOfPack);
           }
           set
           {
               if (string.Empty == value)
                   this.SetColumnNull(_Transfer.ColumnNames.NoOfPack);
               else
                   this.NoOfPack = base.SetintAsString(_Transfer.ColumnNames.NoOfPack, value);
           }
       }

       public virtual string s_QtyPerPack
       {
           get
           {
               return this.IsColumnNull(_Transfer.ColumnNames.QtyPerPack) ? string.Empty : base.GetintAsString(_Transfer.ColumnNames.QtyPerPack);
           }
           set
           {
               if (string.Empty == value)
                   this.SetColumnNull(_Transfer.ColumnNames.QtyPerPack);
               else
                   this.QtyPerPack = base.SetintAsString(_Transfer.ColumnNames.QtyPerPack, value);
           }
       }

       public virtual string s_EurDate
       {
           get
           {
               return this.IsColumnNull(_Transfer.ColumnNames.EurDate) ? string.Empty : base.GetDateTimeAsString(_Transfer.ColumnNames.EurDate);
           }
           set
           {
               if (string.Empty == value)
                   this.SetColumnNull(_Transfer.ColumnNames.EurDate);
               else
                   this.EurDate = base.SetDateTimeAsString(_Transfer.ColumnNames.EurDate, value);
           }
       }

       public virtual string s_BoxLevel
       {
           get
           {
               return this.IsColumnNull(_Transfer.ColumnNames.BoxLevel) ? string.Empty : base.GetintAsString(_Transfer.ColumnNames.BoxLevel);
           }
           set
           {
               if (string.Empty == value)
                   this.SetColumnNull(_Transfer.ColumnNames.BoxLevel);
               else
                   this.BoxLevel = base.SetintAsString(_Transfer.ColumnNames.BoxLevel, value);
           }
       }

       public virtual string s_SubProgramID
       {
           get
           {
               return this.IsColumnNull(_Transfer.ColumnNames.SubProgramID) ? string.Empty : base.GetintAsString(_Transfer.ColumnNames.SubProgramID);
           }
           set
           {
               if (string.Empty == value)
                   this.SetColumnNull(_Transfer.ColumnNames.SubProgramID);
               else
                   this.BoxLevel = base.SetintAsString(_Transfer.ColumnNames.SubProgramID, value);
           }
       }

       #endregion

       #region Where Clause
       public class WhereClause
       {
           public WhereClause(BusinessEntity entity)
           {
               this._entity = entity;
           }

           public _Transfer.WhereClause.TearOffWhereParameter TearOff
           {
               get
               {
                   if (_tearOff == null)
                   {
                       _tearOff = new _Transfer.WhereClause.TearOffWhereParameter(this);
                   }

                   return _tearOff;
               }
           }

           #region WhereParameter TearOff's
           public class TearOffWhereParameter
           {
               public TearOffWhereParameter(_Transfer.WhereClause clause)
               {
                   this._clause = clause;
               }


               public WhereParameter ID
               {
                   get
                   {
                       WhereParameter where = new WhereParameter(_Transfer.ColumnNames.ID, _Transfer.Parameters.ID);
                       this._clause._entity.Query.AddWhereParameter(where);
                       return where;
                   }
               }

               public WhereParameter BatchNo
               {
                   get
                   {
                       WhereParameter where = new WhereParameter(_Transfer.ColumnNames.BatchNo, _Transfer.Parameters.BatchNo);
                       this._clause._entity.Query.AddWhereParameter(where);
                       return where;
                   }
               }

               public WhereParameter ItemID
               {
                   get
                   {
                       WhereParameter where = new WhereParameter(_Transfer.ColumnNames.ItemID, _Transfer.Parameters.ItemID);
                       this._clause._entity.Query.AddWhereParameter(where);
                       return where;
                   }
               }

               public WhereParameter SupplierID
               {
                   get
                   {
                       WhereParameter where = new WhereParameter(_Transfer.ColumnNames.SupplierID, _Transfer.Parameters.SupplierID);
                       this._clause._entity.Query.AddWhereParameter(where);
                       return where;
                   }
               }

               public WhereParameter Quantity
               {
                   get
                   {
                       WhereParameter where = new WhereParameter(_Transfer.ColumnNames.Quantity, _Transfer.Parameters.Quantity);
                       this._clause._entity.Query.AddWhereParameter(where);
                       return where;
                   }
               }

               public WhereParameter Date
               {
                   get
                   {
                       WhereParameter where = new WhereParameter(_Transfer.ColumnNames.Date, _Transfer.Parameters.Date);
                       this._clause._entity.Query.AddWhereParameter(where);
                       return where;
                   }
               }

               public WhereParameter ExpDate
               {
                   get
                   {
                       WhereParameter where = new WhereParameter(_Transfer.ColumnNames.ExpDate, _Transfer.Parameters.ExpDate);
                       this._clause._entity.Query.AddWhereParameter(where);
                       return where;
                   }
               }

               public WhereParameter Out
               {
                   get
                   {
                       WhereParameter where = new WhereParameter(_Transfer.ColumnNames.Out, _Transfer.Parameters.Out);
                       this._clause._entity.Query.AddWhereParameter(where);
                       return where;
                   }
               }

               public WhereParameter ReceivedStatus
               {
                   get
                   {
                       WhereParameter where = new WhereParameter(_Transfer.ColumnNames.ReceivedStatus, _Transfer.Parameters.ReceivedStatus);
                       this._clause._entity.Query.AddWhereParameter(where);
                       return where;
                   }
               }

               public WhereParameter ReceivedBy
               {
                   get
                   {
                       WhereParameter where = new WhereParameter(_Transfer.ColumnNames.ReceivedBy, _Transfer.Parameters.ReceivedBy);
                       this._clause._entity.Query.AddWhereParameter(where);
                       return where;
                   }
               }

               public WhereParameter Remark
               {
                   get
                   {
                       WhereParameter where = new WhereParameter(_Transfer.ColumnNames.Remark, _Transfer.Parameters.Remark);
                       this._clause._entity.Query.AddWhereParameter(where);
                       return where;
                   }
               }

               public WhereParameter FromStoreID
               {
                   get
                   {
                       WhereParameter where = new WhereParameter(_Transfer.ColumnNames.FromStoreID, _Transfer.Parameters.FromStoreID);
                       this._clause._entity.Query.AddWhereParameter(where);
                       return where;
                   }
               }

               public WhereParameter ToStoreID
               {
                   get
                   {
                       WhereParameter where = new WhereParameter(_Transfer.ColumnNames.ToStoreID, _Transfer.Parameters.ToStoreID);
                       this._clause._entity.Query.AddWhereParameter(where);
                       return where;
                   }
               }

               public WhereParameter LocalBatchNo
               {
                   get
                   {
                       WhereParameter where = new WhereParameter(_Transfer.ColumnNames.LocalBatchNo, _Transfer.Parameters.LocalBatchNo);
                       this._clause._entity.Query.AddWhereParameter(where);
                       return where;
                   }
               }

               public WhereParameter RefNo
               {
                   get
                   {
                       WhereParameter where = new WhereParameter(_Transfer.ColumnNames.RefNo, _Transfer.Parameters.RefNo);
                       this._clause._entity.Query.AddWhereParameter(where);
                       return where;
                   }
               }

               public WhereParameter Cost
               {
                   get
                   {
                       WhereParameter where = new WhereParameter(_Transfer.ColumnNames.Cost, _Transfer.Parameters.Cost);
                       this._clause._entity.Query.AddWhereParameter(where);
                       return where;
                   }
               }

               public WhereParameter IsApproved
               {
                   get
                   {
                       WhereParameter where = new WhereParameter(_Transfer.ColumnNames.IsApproved, _Transfer.Parameters.IsApproved);
                       this._clause._entity.Query.AddWhereParameter(where);
                       return where;
                   }
               }

               public WhereParameter ManufacturerId
               {
                   get
                   {
                       WhereParameter where = new WhereParameter(_Transfer.ColumnNames.ManufacturerId, _Transfer.Parameters.ManufacturerId);
                       this._clause._entity.Query.AddWhereParameter(where);
                       return where;
                   }
               }

               public WhereParameter QuantityLeft
               {
                   get
                   {
                       WhereParameter where = new WhereParameter(_Transfer.ColumnNames.QuantityLeft, _Transfer.Parameters.QuantityLeft);
                       this._clause._entity.Query.AddWhereParameter(where);
                       return where;
                   }
               }

               public WhereParameter NoOfPack
               {
                   get
                   {
                       WhereParameter where = new WhereParameter(_Transfer.ColumnNames.NoOfPack, _Transfer.Parameters.NoOfPack);
                       this._clause._entity.Query.AddWhereParameter(where);
                       return where;
                   }
               }

               public WhereParameter QtyPerPack
               {
                   get
                   {
                       WhereParameter where = new WhereParameter(_Transfer.ColumnNames.QtyPerPack, _Transfer.Parameters.QtyPerPack);
                       this._clause._entity.Query.AddWhereParameter(where);
                       return where;
                   }
               }

               public WhereParameter EurDate
               {
                   get
                   {
                       WhereParameter where = new WhereParameter(_Transfer.ColumnNames.EurDate, _Transfer.Parameters.EurDate);
                       this._clause._entity.Query.AddWhereParameter(where);
                       return where;
                   }
               }

               public WhereParameter BoxLevel
               {
                   get
                   {
                       WhereParameter where = new WhereParameter(_Transfer.ColumnNames.BoxLevel, _Transfer.Parameters.BoxLevel);
                       this._clause._entity.Query.AddWhereParameter(where);
                       return where;
                   }
               }

               public WhereParameter SubProgramID
               {
                   get
                   {
                       WhereParameter where = new WhereParameter(_Transfer.ColumnNames.SubProgramID, _Transfer.Parameters.SubProgramID);
                       this._clause._entity.Query.AddWhereParameter(where);
                       return where;
                   }
               }

               private _Transfer.WhereClause _clause;
           }
           #endregion

           public WhereParameter ID
           {
               get
               {
                   if (_ID_W == null)
                   {
                       _ID_W = TearOff.ID;
                   }
                   return _ID_W;
               }
           }

           public WhereParameter BatchNo
           {
               get
               {
                   if (_BatchNo_W == null)
                   {
                       _BatchNo_W = TearOff.BatchNo;
                   }
                   return _BatchNo_W;
               }
           }

           public WhereParameter ItemID
           {
               get
               {
                   if (_ItemID_W == null)
                   {
                       _ItemID_W = TearOff.ItemID;
                   }
                   return _ItemID_W;
               }
           }

           public WhereParameter SupplierID
           {
               get
               {
                   if (_SupplierID_W == null)
                   {
                       _SupplierID_W = TearOff.SupplierID;
                   }
                   return _SupplierID_W;
               }
           }

           public WhereParameter Quantity
           {
               get
               {
                   if (_Quantity_W == null)
                   {
                       _Quantity_W = TearOff.Quantity;
                   }
                   return _Quantity_W;
               }
           }

           public WhereParameter Date
           {
               get
               {
                   if (_Date_W == null)
                   {
                       _Date_W = TearOff.Date;
                   }
                   return _Date_W;
               }
           }

           public WhereParameter ExpDate
           {
               get
               {
                   if (_ExpDate_W == null)
                   {
                       _ExpDate_W = TearOff.ExpDate;
                   }
                   return _ExpDate_W;
               }
           }

           public WhereParameter Out
           {
               get
               {
                   if (_Out_W == null)
                   {
                       _Out_W = TearOff.Out;
                   }
                   return _Out_W;
               }
           }

           public WhereParameter ReceivedStatus
           {
               get
               {
                   if (_ReceivedStatus_W == null)
                   {
                       _ReceivedStatus_W = TearOff.ReceivedStatus;
                   }
                   return _ReceivedStatus_W;
               }
           }

           public WhereParameter ReceivedBy
           {
               get
               {
                   if (_ReceivedBy_W == null)
                   {
                       _ReceivedBy_W = TearOff.ReceivedBy;
                   }
                   return _ReceivedBy_W;
               }
           }

           public WhereParameter Remark
           {
               get
               {
                   if (_Remark_W == null)
                   {
                       _Remark_W = TearOff.Remark;
                   }
                   return _Remark_W;
               }
           }

           public WhereParameter FromStoreID
           {
               get
               {
                   if (_FromStoreID_W == null)
                   {
                       _FromStoreID_W = TearOff.FromStoreID;
                   }
                   return _FromStoreID_W;
               }
           }

           public WhereParameter ToStoreID
           {
               get
               {
                   if (_ToStoreID_W == null)
                   {
                       _ToStoreID_W = TearOff.ToStoreID;
                   }
                   return _ToStoreID_W;
               }
           }

           public WhereParameter LocalBatchNo
           {
               get
               {
                   if (_LocalBatchNo_W == null)
                   {
                       _LocalBatchNo_W = TearOff.LocalBatchNo;
                   }
                   return _LocalBatchNo_W;
               }
           }

           public WhereParameter RefNo
           {
               get
               {
                   if (_RefNo_W == null)
                   {
                       _RefNo_W = TearOff.RefNo;
                   }
                   return _RefNo_W;
               }
           }

           public WhereParameter Cost
           {
               get
               {
                   if (_Cost_W == null)
                   {
                       _Cost_W = TearOff.Cost;
                   }
                   return _Cost_W;
               }
           }

           public WhereParameter IsApproved
           {
               get
               {
                   if (_IsApproved_W == null)
                   {
                       _IsApproved_W = TearOff.IsApproved;
                   }
                   return _IsApproved_W;
               }
           }

           public WhereParameter ManufacturerId
           {
               get
               {
                   if (_ManufacturerId_W == null)
                   {
                       _ManufacturerId_W = TearOff.ManufacturerId;
                   }
                   return _ManufacturerId_W;
               }
           }

           public WhereParameter QuantityLeft
           {
               get
               {
                   if (_QuantityLeft_W == null)
                   {
                       _QuantityLeft_W = TearOff.QuantityLeft;
                   }
                   return _QuantityLeft_W;
               }
           }

           public WhereParameter NoOfPack
           {
               get
               {
                   if (_NoOfPack_W == null)
                   {
                       _NoOfPack_W = TearOff.NoOfPack;
                   }
                   return _NoOfPack_W;
               }
           }

           public WhereParameter QtyPerPack
           {
               get
               {
                   if (_QtyPerPack_W == null)
                   {
                       _QtyPerPack_W = TearOff.QtyPerPack;
                   }
                   return _QtyPerPack_W;
               }
           }

           public WhereParameter EurDate
           {
               get
               {
                   if (_EurDate_W == null)
                   {
                       _EurDate_W = TearOff.EurDate;
                   }
                   return _EurDate_W;
               }
           }

           public WhereParameter BoxLevel
           {
               get
               {
                   if (_BoxLevel_W == null)
                   {
                       _BoxLevel_W = TearOff.BoxLevel;
                   }
                   return _BoxLevel_W;
               }
           }

           public WhereParameter SubProgramID
           {
               get
               {
                   if (_SubProgramID_W == null)
                   {
                       _SubProgramID_W = TearOff.SubProgramID;
                   }
                   return _SubProgramID_W;
               }
           }

           private WhereParameter _ID_W = null;
           private WhereParameter _BatchNo_W = null;
           private WhereParameter _ItemID_W = null;
           private WhereParameter _SupplierID_W = null;
           private WhereParameter _Quantity_W = null;
           private WhereParameter _Date_W = null;
           private WhereParameter _ExpDate_W = null;
           private WhereParameter _Out_W = null;
           private WhereParameter _ReceivedStatus_W = null;
           private WhereParameter _ReceivedBy_W = null;
           private WhereParameter _Remark_W = null;
           private WhereParameter _FromStoreID_W = null;
           private WhereParameter _ToStoreID_W = null;
           private WhereParameter _LocalBatchNo_W = null;
           private WhereParameter _RefNo_W = null;
           private WhereParameter _Cost_W = null;
           private WhereParameter _IsApproved_W = null;
           private WhereParameter _ManufacturerId_W = null;
           private WhereParameter _QuantityLeft_W = null;
           private WhereParameter _NoOfPack_W = null;
           private WhereParameter _QtyPerPack_W = null;
           private WhereParameter _EurDate_W = null;
           private WhereParameter _BoxLevel_W = null;
           private WhereParameter _SubProgramID_W = null;

           public void WhereClauseReset()
           {
               _ID_W = null;
               _BatchNo_W = null;
               _ItemID_W = null;
               _SupplierID_W = null;
               _Quantity_W = null;
               _Date_W = null;
               _ExpDate_W = null;
               _Out_W = null;
               _ReceivedStatus_W = null;
               _ReceivedBy_W = null;
               _Remark_W = null;
               _FromStoreID_W = null;
               _ToStoreID_W = null;
               _LocalBatchNo_W = null;
               _RefNo_W = null;
               _Cost_W = null;
               _IsApproved_W = null;
               _ManufacturerId_W = null;
               _QuantityLeft_W = null;
               _NoOfPack_W = null;
               _QtyPerPack_W = null;
               _EurDate_W = null;
               _BoxLevel_W = null;
               _SubProgramID_W = null;

               this._entity.Query.FlushWhereParameters();

           }

           private BusinessEntity _entity;
           private _Transfer.WhereClause.TearOffWhereParameter _tearOff;

       }

       public _Transfer.WhereClause Where
       {
           get
           {
               if (_whereClause == null)
               {
                   _whereClause = new _Transfer.WhereClause(this);
               }

               return _whereClause;
           }
       }

       private _Transfer.WhereClause _whereClause = null;
       #endregion

       #region Aggregate Clause
       public class AggregateClause
       {
           public AggregateClause(BusinessEntity entity)
           {
               this._entity = entity;
           }

           public _Transfer.AggregateClause.TearOffAggregateParameter TearOff
           {
               get
               {
                   if (_tearOff == null)
                   {
                       _tearOff = new _Transfer.AggregateClause.TearOffAggregateParameter(this);
                   }

                   return _tearOff;
               }
           }

           #region AggregateParameter TearOff's
           public class TearOffAggregateParameter
           {
               public TearOffAggregateParameter(_Transfer.AggregateClause clause)
               {
                   this._clause = clause;
               }


               public AggregateParameter ID
               {
                   get
                   {
                       AggregateParameter aggregate = new AggregateParameter(_Transfer.ColumnNames.ID, _Transfer.Parameters.ID);
                       this._clause._entity.Query.AddAggregateParameter(aggregate);
                       return aggregate;
                   }
               }

               public AggregateParameter BatchNo
               {
                   get
                   {
                       AggregateParameter aggregate = new AggregateParameter(_Transfer.ColumnNames.BatchNo, _Transfer.Parameters.BatchNo);
                       this._clause._entity.Query.AddAggregateParameter(aggregate);
                       return aggregate;
                   }
               }

               public AggregateParameter ItemID
               {
                   get
                   {
                       AggregateParameter aggregate = new AggregateParameter(_Transfer.ColumnNames.ItemID, _Transfer.Parameters.ItemID);
                       this._clause._entity.Query.AddAggregateParameter(aggregate);
                       return aggregate;
                   }
               }

               public AggregateParameter SupplierID
               {
                   get
                   {
                       AggregateParameter aggregate = new AggregateParameter(_Transfer.ColumnNames.SupplierID, _Transfer.Parameters.SupplierID);
                       this._clause._entity.Query.AddAggregateParameter(aggregate);
                       return aggregate;
                   }
               }

               public AggregateParameter Quantity
               {
                   get
                   {
                       AggregateParameter aggregate = new AggregateParameter(_Transfer.ColumnNames.Quantity, _Transfer.Parameters.Quantity);
                       this._clause._entity.Query.AddAggregateParameter(aggregate);
                       return aggregate;
                   }
               }

               public AggregateParameter Date
               {
                   get
                   {
                       AggregateParameter aggregate = new AggregateParameter(_Transfer.ColumnNames.Date, _Transfer.Parameters.Date);
                       this._clause._entity.Query.AddAggregateParameter(aggregate);
                       return aggregate;
                   }
               }

               public AggregateParameter ExpDate
               {
                   get
                   {
                       AggregateParameter aggregate = new AggregateParameter(_Transfer.ColumnNames.ExpDate, _Transfer.Parameters.ExpDate);
                       this._clause._entity.Query.AddAggregateParameter(aggregate);
                       return aggregate;
                   }
               }

               public AggregateParameter Out
               {
                   get
                   {
                       AggregateParameter aggregate = new AggregateParameter(_Transfer.ColumnNames.Out, _Transfer.Parameters.Out);
                       this._clause._entity.Query.AddAggregateParameter(aggregate);
                       return aggregate;
                   }
               }

               public AggregateParameter ReceivedStatus
               {
                   get
                   {
                       AggregateParameter aggregate = new AggregateParameter(_Transfer.ColumnNames.ReceivedStatus, _Transfer.Parameters.ReceivedStatus);
                       this._clause._entity.Query.AddAggregateParameter(aggregate);
                       return aggregate;
                   }
               }

               public AggregateParameter ReceivedBy
               {
                   get
                   {
                       AggregateParameter aggregate = new AggregateParameter(_Transfer.ColumnNames.ReceivedBy, _Transfer.Parameters.ReceivedBy);
                       this._clause._entity.Query.AddAggregateParameter(aggregate);
                       return aggregate;
                   }
               }

               public AggregateParameter Remark
               {
                   get
                   {
                       AggregateParameter aggregate = new AggregateParameter(_Transfer.ColumnNames.Remark, _Transfer.Parameters.Remark);
                       this._clause._entity.Query.AddAggregateParameter(aggregate);
                       return aggregate;
                   }
               }

               public AggregateParameter FromStoreID
               {
                   get
                   {
                       AggregateParameter aggregate = new AggregateParameter(_Transfer.ColumnNames.FromStoreID, _Transfer.Parameters.FromStoreID);
                       this._clause._entity.Query.AddAggregateParameter(aggregate);
                       return aggregate;
                   }
               }

               public AggregateParameter ToStoreID
               {
                   get
                   {
                       AggregateParameter aggregate = new AggregateParameter(_Transfer.ColumnNames.ToStoreID, _Transfer.Parameters.ToStoreID);
                       this._clause._entity.Query.AddAggregateParameter(aggregate);
                       return aggregate;
                   }
               }

               public AggregateParameter LocalBatchNo
               {
                   get
                   {
                       AggregateParameter aggregate = new AggregateParameter(_Transfer.ColumnNames.LocalBatchNo, _Transfer.Parameters.LocalBatchNo);
                       this._clause._entity.Query.AddAggregateParameter(aggregate);
                       return aggregate;
                   }
               }

               public AggregateParameter RefNo
               {
                   get
                   {
                       AggregateParameter aggregate = new AggregateParameter(_Transfer.ColumnNames.RefNo, _Transfer.Parameters.RefNo);
                       this._clause._entity.Query.AddAggregateParameter(aggregate);
                       return aggregate;
                   }
               }

               public AggregateParameter Cost
               {
                   get
                   {
                       AggregateParameter aggregate = new AggregateParameter(_Transfer.ColumnNames.Cost, _Transfer.Parameters.Cost);
                       this._clause._entity.Query.AddAggregateParameter(aggregate);
                       return aggregate;
                   }
               }

               public AggregateParameter IsApproved
               {
                   get
                   {
                       AggregateParameter aggregate = new AggregateParameter(_Transfer.ColumnNames.IsApproved, _Transfer.Parameters.IsApproved);
                       this._clause._entity.Query.AddAggregateParameter(aggregate);
                       return aggregate;
                   }
               }

               public AggregateParameter ManufacturerId
               {
                   get
                   {
                       AggregateParameter aggregate = new AggregateParameter(_Transfer.ColumnNames.ManufacturerId, _Transfer.Parameters.ManufacturerId);
                       this._clause._entity.Query.AddAggregateParameter(aggregate);
                       return aggregate;
                   }
               }

               public AggregateParameter QuantityLeft
               {
                   get
                   {
                       AggregateParameter aggregate = new AggregateParameter(_Transfer.ColumnNames.QuantityLeft, _Transfer.Parameters.QuantityLeft);
                       this._clause._entity.Query.AddAggregateParameter(aggregate);
                       return aggregate;
                   }
               }

               public AggregateParameter NoOfPack
               {
                   get
                   {
                       AggregateParameter aggregate = new AggregateParameter(_Transfer.ColumnNames.NoOfPack, _Transfer.Parameters.NoOfPack);
                       this._clause._entity.Query.AddAggregateParameter(aggregate);
                       return aggregate;
                   }
               }

               public AggregateParameter QtyPerPack
               {
                   get
                   {
                       AggregateParameter aggregate = new AggregateParameter(_Transfer.ColumnNames.QtyPerPack, _Transfer.Parameters.QtyPerPack);
                       this._clause._entity.Query.AddAggregateParameter(aggregate);
                       return aggregate;
                   }
               }

               public AggregateParameter EurDate
               {
                   get
                   {
                       AggregateParameter aggregate = new AggregateParameter(_Transfer.ColumnNames.EurDate, _Transfer.Parameters.EurDate);
                       this._clause._entity.Query.AddAggregateParameter(aggregate);
                       return aggregate;
                   }
               }

               public AggregateParameter BoxLevel
               {
                   get
                   {
                       AggregateParameter aggregate = new AggregateParameter(_Transfer.ColumnNames.BoxLevel, _Transfer.Parameters.BoxLevel);
                       this._clause._entity.Query.AddAggregateParameter(aggregate);
                       return aggregate;
                   }
               }

               public AggregateParameter SubProgramID
               {
                   get
                   {
                       AggregateParameter aggregate = new AggregateParameter(_Transfer.ColumnNames.SubProgramID, _Transfer.Parameters.SubProgramID);
                       this._clause._entity.Query.AddAggregateParameter(aggregate);
                       return aggregate;
                   }
               }

               private _Transfer.AggregateClause _clause;
           }
           #endregion

           public AggregateParameter ID
           {
               get
               {
                   if (_ID_W == null)
                   {
                       _ID_W = TearOff.ID;
                   }
                   return _ID_W;
               }
           }

           public AggregateParameter BatchNo
           {
               get
               {
                   if (_BatchNo_W == null)
                   {
                       _BatchNo_W = TearOff.BatchNo;
                   }
                   return _BatchNo_W;
               }
           }

           public AggregateParameter ItemID
           {
               get
               {
                   if (_ItemID_W == null)
                   {
                       _ItemID_W = TearOff.ItemID;
                   }
                   return _ItemID_W;
               }
           }

           public AggregateParameter SupplierID
           {
               get
               {
                   if (_SupplierID_W == null)
                   {
                       _SupplierID_W = TearOff.SupplierID;
                   }
                   return _SupplierID_W;
               }
           }

           public AggregateParameter Quantity
           {
               get
               {
                   if (_Quantity_W == null)
                   {
                       _Quantity_W = TearOff.Quantity;
                   }
                   return _Quantity_W;
               }
           }

           public AggregateParameter Date
           {
               get
               {
                   if (_Date_W == null)
                   {
                       _Date_W = TearOff.Date;
                   }
                   return _Date_W;
               }
           }

           public AggregateParameter ExpDate
           {
               get
               {
                   if (_ExpDate_W == null)
                   {
                       _ExpDate_W = TearOff.ExpDate;
                   }
                   return _ExpDate_W;
               }
           }

           public AggregateParameter Out
           {
               get
               {
                   if (_Out_W == null)
                   {
                       _Out_W = TearOff.Out;
                   }
                   return _Out_W;
               }
           }

           public AggregateParameter ReceivedStatus
           {
               get
               {
                   if (_ReceivedStatus_W == null)
                   {
                       _ReceivedStatus_W = TearOff.ReceivedStatus;
                   }
                   return _ReceivedStatus_W;
               }
           }

           public AggregateParameter ReceivedBy
           {
               get
               {
                   if (_ReceivedBy_W == null)
                   {
                       _ReceivedBy_W = TearOff.ReceivedBy;
                   }
                   return _ReceivedBy_W;
               }
           }

           public AggregateParameter Remark
           {
               get
               {
                   if (_Remark_W == null)
                   {
                       _Remark_W = TearOff.Remark;
                   }
                   return _Remark_W;
               }
           }

           public AggregateParameter FromStoreID
           {
               get
               {
                   if (_FromStoreID_W == null)
                   {
                       _FromStoreID_W = TearOff.FromStoreID;
                   }
                   return _FromStoreID_W;
               }
           }

           public AggregateParameter ToStoreID
           {
               get
               {
                   if (_ToStoreID_W == null)
                   {
                       _ToStoreID_W = TearOff.ToStoreID;
                   }
                   return _ToStoreID_W;
               }
           }

           public AggregateParameter LocalBatchNo
           {
               get
               {
                   if (_LocalBatchNo_W == null)
                   {
                       _LocalBatchNo_W = TearOff.LocalBatchNo;
                   }
                   return _LocalBatchNo_W;
               }
           }

           public AggregateParameter RefNo
           {
               get
               {
                   if (_RefNo_W == null)
                   {
                       _RefNo_W = TearOff.RefNo;
                   }
                   return _RefNo_W;
               }
           }

           public AggregateParameter Cost
           {
               get
               {
                   if (_Cost_W == null)
                   {
                       _Cost_W = TearOff.Cost;
                   }
                   return _Cost_W;
               }
           }

           public AggregateParameter IsApproved
           {
               get
               {
                   if (_IsApproved_W == null)
                   {
                       _IsApproved_W = TearOff.IsApproved;
                   }
                   return _IsApproved_W;
               }
           }

           public AggregateParameter ManufacturerId
           {
               get
               {
                   if (_ManufacturerId_W == null)
                   {
                       _ManufacturerId_W = TearOff.ManufacturerId;
                   }
                   return _ManufacturerId_W;
               }
           }

           public AggregateParameter QuantityLeft
           {
               get
               {
                   if (_QuantityLeft_W == null)
                   {
                       _QuantityLeft_W = TearOff.QuantityLeft;
                   }
                   return _QuantityLeft_W;
               }
           }

           public AggregateParameter NoOfPack
           {
               get
               {
                   if (_NoOfPack_W == null)
                   {
                       _NoOfPack_W = TearOff.NoOfPack;
                   }
                   return _NoOfPack_W;
               }
           }

           public AggregateParameter QtyPerPack
           {
               get
               {
                   if (_QtyPerPack_W == null)
                   {
                       _QtyPerPack_W = TearOff.QtyPerPack;
                   }
                   return _QtyPerPack_W;
               }
           }

           public AggregateParameter EurDate
           {
               get
               {
                   if (_EurDate_W == null)
                   {
                       _EurDate_W = TearOff.EurDate;
                   }
                   return _EurDate_W;
               }
           }

           public AggregateParameter BoxLevel
           {
               get
               {
                   if (_BoxLevel_W == null)
                   {
                       _BoxLevel_W = TearOff.BoxLevel;
                   }
                   return _BoxLevel_W;
               }
           }

           public AggregateParameter SubProgramID
           {
               get
               {
                   if (_SubProgramID_W == null)
                   {
                       _SubProgramID_W = TearOff.SubProgramID;
                   }
                   return _SubProgramID_W;
               }
           }

           private AggregateParameter _ID_W = null;
           private AggregateParameter _BatchNo_W = null;
           private AggregateParameter _ItemID_W = null;
           private AggregateParameter _SupplierID_W = null;
           private AggregateParameter _Quantity_W = null;
           private AggregateParameter _Date_W = null;
           private AggregateParameter _ExpDate_W = null;
           private AggregateParameter _Out_W = null;
           private AggregateParameter _ReceivedStatus_W = null;
           private AggregateParameter _ReceivedBy_W = null;
           private AggregateParameter _Remark_W = null;
           private AggregateParameter _FromStoreID_W = null;
           private AggregateParameter _ToStoreID_W = null;
           private AggregateParameter _LocalBatchNo_W = null;
           private AggregateParameter _RefNo_W = null;
           private AggregateParameter _Cost_W = null;
           private AggregateParameter _IsApproved_W = null;
           private AggregateParameter _ManufacturerId_W = null;
           private AggregateParameter _QuantityLeft_W = null;
           private AggregateParameter _NoOfPack_W = null;
           private AggregateParameter _QtyPerPack_W = null;
           private AggregateParameter _EurDate_W = null;
           private AggregateParameter _BoxLevel_W = null;
           private AggregateParameter _SubProgramID_W = null;
           public void AggregateClauseReset()
           {
               _ID_W = null;
               _BatchNo_W = null;
               _ItemID_W = null;
               _SupplierID_W = null;
               _Quantity_W = null;
               _Date_W = null;
               _ExpDate_W = null;
               _Out_W = null;
               _ReceivedStatus_W = null;
               _ReceivedBy_W = null;
               _Remark_W = null;
               _FromStoreID_W = null;
               _ToStoreID_W = null;
               _LocalBatchNo_W = null;
               _RefNo_W = null;
               _Cost_W = null;
               _IsApproved_W = null;
               _ManufacturerId_W = null;
               _QuantityLeft_W = null;
               _NoOfPack_W = null;
               _QtyPerPack_W = null;
               _EurDate_W = null;
               _BoxLevel_W = null;
               _SubProgramID_W = null;
               this._entity.Query.FlushAggregateParameters();

           }

           private BusinessEntity _entity;
           private _Transfer.AggregateClause.TearOffAggregateParameter _tearOff;

       }

       public _Transfer.AggregateClause Aggregate
       {
           get
           {
               if (_aggregateClause == null)
               {
                   _aggregateClause = new _Transfer.AggregateClause(this);
               }

               return _aggregateClause;
           }
       }

       private _Transfer.AggregateClause _aggregateClause = null;
       #endregion

       protected override IDbCommand GetInsertCommand()
       {

           SqlCommand cmd = new SqlCommand();
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.CommandText = "[" + this.SchemaStoredProcedure + "proc_TransferInsert]";

           CreateParameters(cmd);

           SqlParameter p;
           p = cmd.Parameters[_Transfer.Parameters.ID.ParameterName];
           p.Direction = ParameterDirection.Output;

           return cmd;
       }

       protected override IDbCommand GetUpdateCommand()
       {

           SqlCommand cmd = new SqlCommand();
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.CommandText = "[" + this.SchemaStoredProcedure + "proc_TransferUpdate]";

           CreateParameters(cmd);

           return cmd;
       }

       protected override IDbCommand GetDeleteCommand()
       {

           SqlCommand cmd = new SqlCommand();
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.CommandText = "[" + this.SchemaStoredProcedure + "proc_TransferDelete]";

           SqlParameter p;
           p = cmd.Parameters.Add(_Transfer.Parameters.ID);
           p.SourceColumn = _Transfer.ColumnNames.ID;
           p.SourceVersion = DataRowVersion.Current;


           return cmd;
       }

       private IDbCommand CreateParameters(SqlCommand cmd)
       {
           SqlParameter p;

           p = cmd.Parameters.Add(_Transfer.Parameters.ID);
           p.SourceColumn = _Transfer.ColumnNames.ID;
           p.SourceVersion = DataRowVersion.Current;

           p = cmd.Parameters.Add(Parameters.BatchNo);
           p.SourceColumn = ColumnNames.BatchNo;
           p.SourceVersion = DataRowVersion.Current;

           p = cmd.Parameters.Add(Parameters.ItemID);
           p.SourceColumn = ColumnNames.ItemID;
           p.SourceVersion = DataRowVersion.Current;

           p = cmd.Parameters.Add(Parameters.SupplierID);
           p.SourceColumn = ColumnNames.SupplierID;
           p.SourceVersion = DataRowVersion.Current;

           p = cmd.Parameters.Add(Parameters.Quantity);
           p.SourceColumn = ColumnNames.Quantity;
           p.SourceVersion = DataRowVersion.Current;

           p = cmd.Parameters.Add(Parameters.Date);
           p.SourceColumn = ColumnNames.Date;
           p.SourceVersion = DataRowVersion.Current;

           p = cmd.Parameters.Add(Parameters.ExpDate);
           p.SourceColumn = ColumnNames.ExpDate;
           p.SourceVersion = DataRowVersion.Current;

           p = cmd.Parameters.Add(Parameters.Out);
           p.SourceColumn = ColumnNames.Out;
           p.SourceVersion = DataRowVersion.Current;

           p = cmd.Parameters.Add(Parameters.ReceivedStatus);
           p.SourceColumn = ColumnNames.ReceivedStatus;
           p.SourceVersion = DataRowVersion.Current;

           p = cmd.Parameters.Add(Parameters.ReceivedBy);
           p.SourceColumn = ColumnNames.ReceivedBy;
           p.SourceVersion = DataRowVersion.Current;

           p = cmd.Parameters.Add(Parameters.Remark);
           p.SourceColumn = ColumnNames.Remark;
           p.SourceVersion = DataRowVersion.Current;

           p = cmd.Parameters.Add(Parameters.FromStoreID);
           p.SourceColumn = ColumnNames.FromStoreID;
           p.SourceVersion = DataRowVersion.Current;

           p = cmd.Parameters.Add(Parameters.ToStoreID);
           p.SourceColumn = ColumnNames.ToStoreID;
           p.SourceVersion = DataRowVersion.Current;

           p = cmd.Parameters.Add(Parameters.LocalBatchNo);
           p.SourceColumn = ColumnNames.LocalBatchNo;
           p.SourceVersion = DataRowVersion.Current;

           p = cmd.Parameters.Add(Parameters.RefNo);
           p.SourceColumn = ColumnNames.RefNo;
           p.SourceVersion = DataRowVersion.Current;

           p = cmd.Parameters.Add(Parameters.Cost);
           p.SourceColumn = ColumnNames.Cost;
           p.SourceVersion = DataRowVersion.Current;

           p = cmd.Parameters.Add(Parameters.IsApproved);
           p.SourceColumn = ColumnNames.IsApproved;
           p.SourceVersion = DataRowVersion.Current;

           p = cmd.Parameters.Add(Parameters.ManufacturerId);
           p.SourceColumn = ColumnNames.ManufacturerId;
           p.SourceVersion = DataRowVersion.Current;

           p = cmd.Parameters.Add(Parameters.QuantityLeft);
           p.SourceColumn = _Transfer.ColumnNames.QuantityLeft;
           p.SourceVersion = DataRowVersion.Current;

           p = cmd.Parameters.Add(Parameters.NoOfPack);
           p.SourceColumn = ColumnNames.NoOfPack;
           p.SourceVersion = DataRowVersion.Current;

           p = cmd.Parameters.Add(Parameters.QtyPerPack);
           p.SourceColumn = ColumnNames.QtyPerPack;
           p.SourceVersion = DataRowVersion.Current;

           p = cmd.Parameters.Add(Parameters.EurDate);
           p.SourceColumn = ColumnNames.EurDate;
           p.SourceVersion = DataRowVersion.Current;

           p = cmd.Parameters.Add(Parameters.BoxLevel);
           p.SourceColumn = _Transfer.ColumnNames.BoxLevel;
           p.SourceVersion = DataRowVersion.Current;

           p = cmd.Parameters.Add(Parameters.SubProgramID);
           p.SourceColumn = _Transfer.ColumnNames.SubProgramID;
           p.SourceVersion = DataRowVersion.Current;
           return cmd;
       }
    }
}
