﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Specialized;

using MyGeneration.dOOdads;

namespace DAL
{
    public abstract class _IssueDocDeleted : SqlClientEntity
    {
        public _IssueDocDeleted()
        {
            this.QuerySource = "IssueDocDeleted";
            this.MappingName = "IssueDocDeleted";

        }

        //=================================================================
        //  public Overrides void AddNew()
        //=================================================================
        //
        //=================================================================
        public override void AddNew()
        {
            base.AddNew();

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

            return base.LoadFromSql("[" + this.SchemaStoredProcedure + "proc_IssueDocDeletedLoadAll]", parameters);
        }

        //=================================================================
        // public Overridable Function LoadByPrimaryKey()  As Boolean
        //=================================================================
        //  Loads a single row of via the primary key
        //=================================================================
        public virtual bool LoadByPrimaryKey(int ID)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(Parameters.ID, ID);


            return base.LoadFromSql("[" + this.SchemaStoredProcedure + "proc_IssueDocDeletedLoadByPrimaryKey]", parameters);
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

            public static SqlParameter ItemID
            {
                get
                {
                    return new SqlParameter("@ItemID", SqlDbType.Int, 0);
                }
            }

            public static SqlParameter StoreId
            {
                get
                {
                    return new SqlParameter("@StoreId", SqlDbType.Int, 0);
                }
            }

            public static SqlParameter ReceivingUnitID
            {
                get
                {
                    return new SqlParameter("@ReceivingUnitID", SqlDbType.Int, 0);
                }
            }

            public static SqlParameter LocalBatchNo
            {
                get
                {
                    return new SqlParameter("@LocalBatchNo", SqlDbType.VarChar, 50);
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

            public static SqlParameter IsTransfer
            {
                get
                {
                    return new SqlParameter("@IsTransfer", SqlDbType.Bit, 0);
                }
            }

            public static SqlParameter IssuedBy
            {
                get
                {
                    return new SqlParameter("@IssuedBy", SqlDbType.VarChar, 50);
                }
            }

            public static SqlParameter Remark
            {
                get
                {
                    return new SqlParameter("@Remark", SqlDbType.Text, 2147483647);
                }
            }

            public static SqlParameter RefNo
            {
                get
                {
                    return new SqlParameter("@RefNo", SqlDbType.VarChar, 50);
                }
            }

            public static SqlParameter BatchNo
            {
                get
                {
                    return new SqlParameter("@BatchNo", SqlDbType.VarChar, 50);
                }
            }

            public static SqlParameter IsApproved
            {
                get
                {
                    return new SqlParameter("@IsApproved", SqlDbType.Bit, 0);
                }
            }

            public static SqlParameter Cost
            {
                get
                {
                    return new SqlParameter("@Cost", SqlDbType.Float, 0);
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

            public static SqlParameter DUSOH
            {
                get
                {
                    return new SqlParameter("@DUSOH", SqlDbType.BigInt, 0);
                }
            }

            public static SqlParameter DURequestedQty
            {
                get
                {
                    return new SqlParameter("@DURequestedQty", SqlDbType.BigInt, 0);
                }
            }

            public static SqlParameter RecomendedQty
            {
                get
                {
                    return new SqlParameter("@RecomendedQty", SqlDbType.BigInt, 0);
                }
            }

            public static SqlParameter RecievDocID
            {
                get
                {
                    return new SqlParameter("@RecievDocID", SqlDbType.Int, 0);
                }
            }

            public static SqlParameter EurDate
            {
                get
                {
                    return new SqlParameter("@EurDate", SqlDbType.DateTime, 0);
                }
            }

            public static SqlParameter OrderID
            {
                get
                {
                    return new SqlParameter("@OrderID", SqlDbType.Int, 0);
                }
            }

        }
        #endregion

        #region ColumnNames
        public class ColumnNames
        {
            public const string ID = "ID";
            public const string ItemID = "ItemID";
            public const string StoreId = "StoreId";
            public const string ReceivingUnitID = "ReceivingUnitID";
            public const string LocalBatchNo = "LocalBatchNo";
            public const string Quantity = "Quantity";
            public const string Date = "Date";
            public const string IsTransfer = "IsTransfer";
            public const string IssuedBy = "IssuedBy";
            public const string Remark = "Remark";
            public const string RefNo = "RefNo";
            public const string BatchNo = "BatchNo";
            public const string IsApproved = "IsApproved";
            public const string Cost = "Cost";
            public const string NoOfPack = "NoOfPack";
            public const string QtyPerPack = "QtyPerPack";
            public const string DUSOH = "DUSOH";
            public const string DURequestedQty = "DURequestedQty";
            public const string RecomendedQty = "RecomendedQty";
            public const string RecievDocID = "RecievDocID";
            public const string EurDate = "EurDate";
            public const string OrderID = "OrderID";

            static public string ToPropertyName(string columnName)
            {
                if (ht == null)
                {
                    ht = new Hashtable();

                    ht[ID] = _IssueDocDeleted.PropertyNames.ID;
                    ht[ItemID] = _IssueDocDeleted.PropertyNames.ItemID;
                    ht[StoreId] = _IssueDocDeleted.PropertyNames.StoreId;
                    ht[ReceivingUnitID] = _IssueDocDeleted.PropertyNames.ReceivingUnitID;
                    ht[LocalBatchNo] = _IssueDocDeleted.PropertyNames.LocalBatchNo;
                    ht[Quantity] = _IssueDocDeleted.PropertyNames.Quantity;
                    ht[Date] = _IssueDocDeleted.PropertyNames.Date;
                    ht[IsTransfer] = _IssueDocDeleted.PropertyNames.IsTransfer;
                    ht[IssuedBy] = _IssueDocDeleted.PropertyNames.IssuedBy;
                    ht[Remark] = _IssueDocDeleted.PropertyNames.Remark;
                    ht[RefNo] = _IssueDocDeleted.PropertyNames.RefNo;
                    ht[BatchNo] = _IssueDocDeleted.PropertyNames.BatchNo;
                    ht[IsApproved] = _IssueDocDeleted.PropertyNames.IsApproved;
                    ht[Cost] = _IssueDocDeleted.PropertyNames.Cost;
                    ht[NoOfPack] = _IssueDocDeleted.PropertyNames.NoOfPack;
                    ht[QtyPerPack] = _IssueDocDeleted.PropertyNames.QtyPerPack;
                    ht[DUSOH] = _IssueDocDeleted.PropertyNames.DUSOH;
                    ht[DURequestedQty] = _IssueDocDeleted.PropertyNames.DURequestedQty;
                    ht[RecomendedQty] = _IssueDocDeleted.PropertyNames.RecomendedQty;
                    ht[RecievDocID] = _IssueDocDeleted.PropertyNames.RecievDocID;
                    ht[EurDate] = _IssueDocDeleted.PropertyNames.EurDate;
                    ht[OrderID] = _IssueDocDeleted.PropertyNames.OrderID;

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
            public const string ItemID = "ItemID";
            public const string StoreId = "StoreId";
            public const string ReceivingUnitID = "ReceivingUnitID";
            public const string LocalBatchNo = "LocalBatchNo";
            public const string Quantity = "Quantity";
            public const string Date = "Date";
            public const string IsTransfer = "IsTransfer";
            public const string IssuedBy = "IssuedBy";
            public const string Remark = "Remark";
            public const string RefNo = "RefNo";
            public const string BatchNo = "BatchNo";
            public const string IsApproved = "IsApproved";
            public const string Cost = "Cost";
            public const string NoOfPack = "NoOfPack";
            public const string QtyPerPack = "QtyPerPack";
            public const string DUSOH = "DUSOH";
            public const string DURequestedQty = "DURequestedQty";
            public const string RecomendedQty = "RecomendedQty";
            public const string RecievDocID = "RecievDocID";
            public const string EurDate = "EurDate";
            public const string OrderID = "OrderID";

            static public string ToColumnName(string propertyName)
            {
                if (ht == null)
                {
                    ht = new Hashtable();

                    ht[ID] = _IssueDocDeleted.ColumnNames.ID;
                    ht[ItemID] = _IssueDocDeleted.ColumnNames.ItemID;
                    ht[StoreId] = _IssueDocDeleted.ColumnNames.StoreId;
                    ht[ReceivingUnitID] = _IssueDocDeleted.ColumnNames.ReceivingUnitID;
                    ht[LocalBatchNo] = _IssueDocDeleted.ColumnNames.LocalBatchNo;
                    ht[Quantity] = _IssueDocDeleted.ColumnNames.Quantity;
                    ht[Date] = _IssueDocDeleted.ColumnNames.Date;
                    ht[IsTransfer] = _IssueDocDeleted.ColumnNames.IsTransfer;
                    ht[IssuedBy] = _IssueDocDeleted.ColumnNames.IssuedBy;
                    ht[Remark] = _IssueDocDeleted.ColumnNames.Remark;
                    ht[RefNo] = _IssueDocDeleted.ColumnNames.RefNo;
                    ht[BatchNo] = _IssueDocDeleted.ColumnNames.BatchNo;
                    ht[IsApproved] = _IssueDocDeleted.ColumnNames.IsApproved;
                    ht[Cost] = _IssueDocDeleted.ColumnNames.Cost;
                    ht[NoOfPack] = _IssueDocDeleted.ColumnNames.NoOfPack;
                    ht[QtyPerPack] = _IssueDocDeleted.ColumnNames.QtyPerPack;
                    ht[DUSOH] = _IssueDocDeleted.ColumnNames.DUSOH;
                    ht[DURequestedQty] = _IssueDocDeleted.ColumnNames.DURequestedQty;
                    ht[RecomendedQty] = _IssueDocDeleted.ColumnNames.RecomendedQty;
                    ht[RecievDocID] = _IssueDocDeleted.ColumnNames.RecievDocID;
                    ht[EurDate] = _IssueDocDeleted.ColumnNames.EurDate;
                    ht[OrderID] = _IssueDocDeleted.ColumnNames.OrderID;

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
            public const string ItemID = "s_ItemID";
            public const string StoreId = "s_StoreId";
            public const string ReceivingUnitID = "s_ReceivingUnitID";
            public const string LocalBatchNo = "s_LocalBatchNo";
            public const string Quantity = "s_Quantity";
            public const string Date = "s_Date";
            public const string IsTransfer = "s_IsTransfer";
            public const string IssuedBy = "s_IssuedBy";
            public const string Remark = "s_Remark";
            public const string RefNo = "s_RefNo";
            public const string BatchNo = "s_BatchNo";
            public const string IsApproved = "s_IsApproved";
            public const string Cost = "s_Cost";
            public const string NoOfPack = "s_NoOfPack";
            public const string QtyPerPack = "s_QtyPerPack";
            public const string DUSOH = "s_DUSOH";
            public const string DURequestedQty = "s_DURequestedQty";
            public const string RecomendedQty = "s_RecomendedQty";
            public const string RecievDocID = "s_RecievDocID";
            public const string EurDate = "s_EurDate";
            public const string OrderID = "s_OrderID";

        }
        #endregion

        #region Properties

        public virtual int ID
        {
            get
            {
                return base.Getint(ColumnNames.ID);
            }
            set
            {
                base.Setint(ColumnNames.ID, value);
            }
        }

        public virtual int ItemID
        {
            get
            {
                return base.Getint(ColumnNames.ItemID);
            }
            set
            {
                base.Setint(ColumnNames.ItemID, value);
            }
        }

        public virtual int StoreId
        {
            get
            {
                return base.Getint(ColumnNames.StoreId);
            }
            set
            {
                base.Setint(ColumnNames.StoreId, value);
            }
        }

        public virtual int ReceivingUnitID
        {
            get
            {
                return base.Getint(ColumnNames.ReceivingUnitID);
            }
            set
            {
                base.Setint(ColumnNames.ReceivingUnitID, value);
            }
        }

        public virtual string LocalBatchNo
        {
            get
            {
                return base.Getstring(ColumnNames.LocalBatchNo);
            }
            set
            {
                base.Setstring(ColumnNames.LocalBatchNo, value);
            }
        }

        public virtual long Quantity
        {
            get
            {
                return base.Getlong(ColumnNames.Quantity);
            }
            set
            {
                base.Setlong(ColumnNames.Quantity, value);
            }
        }

        public virtual DateTime Date
        {
            get
            {
                return base.GetDateTime(ColumnNames.Date);
            }
            set
            {
                base.SetDateTime(ColumnNames.Date, value);
            }
        }

        public virtual bool IsTransfer
        {
            get
            {
                return base.Getbool(ColumnNames.IsTransfer);
            }
            set
            {
                base.Setbool(ColumnNames.IsTransfer, value);
            }
        }

        public virtual string IssuedBy
        {
            get
            {
                return base.Getstring(ColumnNames.IssuedBy);
            }
            set
            {
                base.Setstring(ColumnNames.IssuedBy, value);
            }
        }

        public virtual string Remark
        {
            get
            {
                return base.Getstring(ColumnNames.Remark);
            }
            set
            {
                base.Setstring(ColumnNames.Remark, value);
            }
        }

        public virtual string RefNo
        {
            get
            {
                return base.Getstring(ColumnNames.RefNo);
            }
            set
            {
                base.Setstring(ColumnNames.RefNo, value);
            }
        }

        public virtual string BatchNo
        {
            get
            {
                return base.Getstring(ColumnNames.BatchNo);
            }
            set
            {
                base.Setstring(ColumnNames.BatchNo, value);
            }
        }

        public virtual bool IsApproved
        {
            get
            {
                return base.Getbool(ColumnNames.IsApproved);
            }
            set
            {
                base.Setbool(ColumnNames.IsApproved, value);
            }
        }

        public virtual double Cost
        {
            get
            {
                return base.Getdouble(ColumnNames.Cost);
            }
            set
            {
                base.Setdouble(ColumnNames.Cost, value);
            }
        }

        public virtual int NoOfPack
        {
            get
            {
                return base.Getint(ColumnNames.NoOfPack);
            }
            set
            {
                base.Setint(ColumnNames.NoOfPack, value);
            }
        }

        public virtual int QtyPerPack
        {
            get
            {
                return base.Getint(ColumnNames.QtyPerPack);
            }
            set
            {
                base.Setint(ColumnNames.QtyPerPack, value);
            }
        }

        public virtual long DUSOH
        {
            get
            {
                return base.Getlong(ColumnNames.DUSOH);
            }
            set
            {
                base.Setlong(ColumnNames.DUSOH, value);
            }
        }

        public virtual long DURequestedQty
        {
            get
            {
                return base.Getlong(ColumnNames.DURequestedQty);
            }
            set
            {
                base.Setlong(ColumnNames.DURequestedQty, value);
            }
        }

        public virtual long RecomendedQty
        {
            get
            {
                return base.Getlong(ColumnNames.RecomendedQty);
            }
            set
            {
                base.Setlong(ColumnNames.RecomendedQty, value);
            }
        }

        public virtual int RecievDocID
        {
            get
            {

                return base.Getint(ColumnNames.RecievDocID);
            }
            set
            {
                base.Setint(ColumnNames.RecievDocID, value);
            }
        }


        public virtual DateTime EurDate
        {
            get
            {
                return base.GetDateTime(ColumnNames.EurDate);
            }
            set
            {
                base.SetDateTime(ColumnNames.EurDate, value);
            }
        }

        public virtual int OrderID
        {
            get
            {
                return base.Getint(ColumnNames.OrderID);
            }
            set
            {
                base.Setint(ColumnNames.OrderID, value);
            }
        }


        #endregion

        #region String Properties

        public virtual string s_ID
        {
            get
            {
                return this.IsColumnNull(ColumnNames.ID) ? string.Empty : base.GetintAsString(ColumnNames.ID);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.ID);
                else
                    this.ID = base.SetintAsString(ColumnNames.ID, value);
            }
        }

        public virtual string s_ItemID
        {
            get
            {
                return this.IsColumnNull(ColumnNames.ItemID) ? string.Empty : base.GetintAsString(ColumnNames.ItemID);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.ItemID);
                else
                    this.ItemID = base.SetintAsString(ColumnNames.ItemID, value);
            }
        }

        public virtual string s_StoreId
        {
            get
            {
                return this.IsColumnNull(ColumnNames.StoreId) ? string.Empty : base.GetintAsString(ColumnNames.StoreId);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.StoreId);
                else
                    this.StoreId = base.SetintAsString(ColumnNames.StoreId, value);
            }
        }

        public virtual string s_ReceivingUnitID
        {
            get
            {
                return this.IsColumnNull(ColumnNames.ReceivingUnitID) ? string.Empty : base.GetintAsString(ColumnNames.ReceivingUnitID);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.ReceivingUnitID);
                else
                    this.ReceivingUnitID = base.SetintAsString(ColumnNames.ReceivingUnitID, value);
            }
        }

        public virtual string s_LocalBatchNo
        {
            get
            {
                return this.IsColumnNull(ColumnNames.LocalBatchNo) ? string.Empty : base.GetstringAsString(ColumnNames.LocalBatchNo);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.LocalBatchNo);
                else
                    this.LocalBatchNo = base.SetstringAsString(ColumnNames.LocalBatchNo, value);
            }
        }

        public virtual string s_Quantity
        {
            get
            {
                return this.IsColumnNull(ColumnNames.Quantity) ? string.Empty : base.GetlongAsString(ColumnNames.Quantity);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.Quantity);
                else
                    this.Quantity = base.SetlongAsString(ColumnNames.Quantity, value);
            }
        }

        public virtual string s_Date
        {
            get
            {
                return this.IsColumnNull(ColumnNames.Date) ? string.Empty : base.GetDateTimeAsString(ColumnNames.Date);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.Date);
                else
                    this.Date = base.SetDateTimeAsString(ColumnNames.Date, value);
            }
        }

        public virtual string s_IsTransfer
        {
            get
            {
                return this.IsColumnNull(ColumnNames.IsTransfer) ? string.Empty : base.GetboolAsString(ColumnNames.IsTransfer);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.IsTransfer);
                else
                    this.IsTransfer = base.SetboolAsString(ColumnNames.IsTransfer, value);
            }
        }

        public virtual string s_IssuedBy
        {
            get
            {
                return this.IsColumnNull(ColumnNames.IssuedBy) ? string.Empty : base.GetstringAsString(ColumnNames.IssuedBy);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.IssuedBy);
                else
                    this.IssuedBy = base.SetstringAsString(ColumnNames.IssuedBy, value);
            }
        }

        public virtual string s_Remark
        {
            get
            {
                return this.IsColumnNull(ColumnNames.Remark) ? string.Empty : base.GetstringAsString(ColumnNames.Remark);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.Remark);
                else
                    this.Remark = base.SetstringAsString(ColumnNames.Remark, value);
            }
        }

        public virtual string s_RefNo
        {
            get
            {
                return this.IsColumnNull(ColumnNames.RefNo) ? string.Empty : base.GetstringAsString(ColumnNames.RefNo);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.RefNo);
                else
                    this.RefNo = base.SetstringAsString(ColumnNames.RefNo, value);
            }
        }

        public virtual string s_BatchNo
        {
            get
            {
                return this.IsColumnNull(ColumnNames.BatchNo) ? string.Empty : base.GetstringAsString(ColumnNames.BatchNo);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.BatchNo);
                else
                    this.BatchNo = base.SetstringAsString(ColumnNames.BatchNo, value);
            }
        }

        public virtual string s_IsApproved
        {
            get
            {
                return this.IsColumnNull(ColumnNames.IsApproved) ? string.Empty : base.GetboolAsString(ColumnNames.IsApproved);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.IsApproved);
                else
                    this.IsApproved = base.SetboolAsString(ColumnNames.IsApproved, value);
            }
        }

        public virtual string s_Cost
        {
            get
            {
                return this.IsColumnNull(ColumnNames.Cost) ? string.Empty : base.GetdoubleAsString(ColumnNames.Cost);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.Cost);
                else
                    this.Cost = base.SetdoubleAsString(ColumnNames.Cost, value);
            }
        }

        public virtual string s_NoOfPack
        {
            get
            {
                return this.IsColumnNull(ColumnNames.NoOfPack) ? string.Empty : base.GetintAsString(ColumnNames.NoOfPack);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.NoOfPack);
                else
                    this.NoOfPack = base.SetintAsString(ColumnNames.NoOfPack, value);
            }
        }

        public virtual string s_QtyPerPack
        {
            get
            {
                return this.IsColumnNull(ColumnNames.QtyPerPack) ? string.Empty : base.GetintAsString(ColumnNames.QtyPerPack);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.QtyPerPack);
                else
                    this.QtyPerPack = base.SetintAsString(ColumnNames.QtyPerPack, value);
            }
        }

        public virtual string s_DUSOH
        {
            get
            {
                return this.IsColumnNull(ColumnNames.DUSOH) ? string.Empty : base.GetlongAsString(ColumnNames.DUSOH);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.DUSOH);
                else
                    this.DUSOH = base.SetlongAsString(ColumnNames.DUSOH, value);
            }
        }

        public virtual string s_DURequestedQty
        {
            get
            {
                return this.IsColumnNull(ColumnNames.DURequestedQty) ? string.Empty : base.GetlongAsString(ColumnNames.DURequestedQty);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.DURequestedQty);
                else
                    this.DURequestedQty = base.SetlongAsString(ColumnNames.DURequestedQty, value);
            }
        }

        public virtual string s_RecomendedQty
        {
            get
            {
                return this.IsColumnNull(ColumnNames.RecomendedQty) ? string.Empty : base.GetlongAsString(ColumnNames.RecomendedQty);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.RecomendedQty);
                else
                    this.RecomendedQty = base.SetlongAsString(ColumnNames.RecomendedQty, value);
            }
        }

        public virtual string s_RecievDocID
        {
            get
            {
                return this.IsColumnNull(ColumnNames.RecievDocID) ? string.Empty : base.GetintAsString(ColumnNames.RecievDocID);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.RecievDocID);
                else
                    this.RecievDocID = base.SetintAsString(ColumnNames.RecievDocID, value);
            }
        }

        public virtual string s_EurDate
        {
            get
            {
                return this.IsColumnNull(ColumnNames.EurDate) ? string.Empty : base.GetDateTimeAsString(ColumnNames.EurDate);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.EurDate);
                else
                    this.EurDate = base.SetDateTimeAsString(ColumnNames.EurDate, value);
            }
        }

        public virtual string s_OrderID
        {
            get
            {
                return this.IsColumnNull(ColumnNames.OrderID) ? string.Empty : base.GetintAsString(ColumnNames.OrderID);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.OrderID);
                else
                    this.OrderID = base.SetintAsString(ColumnNames.OrderID, value);
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

            public TearOffWhereParameter TearOff
            {
                get
                {
                    if (_tearOff == null)
                    {
                        _tearOff = new TearOffWhereParameter(this);
                    }

                    return _tearOff;
                }
            }

            #region WhereParameter TearOff's
            public class TearOffWhereParameter
            {
                public TearOffWhereParameter(WhereClause clause)
                {
                    this._clause = clause;
                }


                public WhereParameter ID
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.ID, Parameters.ID);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter ItemID
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.ItemID, Parameters.ItemID);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter StoreId
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.StoreId, Parameters.StoreId);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter ReceivingUnitID
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.ReceivingUnitID, Parameters.ReceivingUnitID);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter LocalBatchNo
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.LocalBatchNo, Parameters.LocalBatchNo);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter Quantity
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.Quantity, Parameters.Quantity);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter Date
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.Date, Parameters.Date);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter IsTransfer
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.IsTransfer, Parameters.IsTransfer);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter IssuedBy
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.IssuedBy, Parameters.IssuedBy);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter Remark
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.Remark, Parameters.Remark);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter RefNo
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.RefNo, Parameters.RefNo);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter BatchNo
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.BatchNo, Parameters.BatchNo);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter IsApproved
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.IsApproved, Parameters.IsApproved);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter Cost
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.Cost, Parameters.Cost);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter NoOfPack
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.NoOfPack, Parameters.NoOfPack);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter QtyPerPack
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.QtyPerPack, Parameters.QtyPerPack);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter DUSOH
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.DUSOH, Parameters.DUSOH);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter DURequestedQty
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.DURequestedQty, Parameters.DURequestedQty);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter RecomendedQty
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.RecomendedQty, Parameters.RecomendedQty);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter RecievDocID
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.RecievDocID, Parameters.RecievDocID);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter EurDate
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.EurDate, Parameters.EurDate);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter OrderID
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.OrderID, Parameters.OrderID);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }


                private WhereClause _clause;
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

            public WhereParameter StoreId
            {
                get
                {
                    if (_StoreId_W == null)
                    {
                        _StoreId_W = TearOff.StoreId;
                    }
                    return _StoreId_W;
                }
            }

            public WhereParameter ReceivingUnitID
            {
                get
                {
                    if (_ReceivingUnitID_W == null)
                    {
                        _ReceivingUnitID_W = TearOff.ReceivingUnitID;
                    }
                    return _ReceivingUnitID_W;
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

            public WhereParameter IsTransfer
            {
                get
                {
                    if (_IsTransfer_W == null)
                    {
                        _IsTransfer_W = TearOff.IsTransfer;
                    }
                    return _IsTransfer_W;
                }
            }

            public WhereParameter IssuedBy
            {
                get
                {
                    if (_IssuedBy_W == null)
                    {
                        _IssuedBy_W = TearOff.IssuedBy;
                    }
                    return _IssuedBy_W;
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

            public WhereParameter DUSOH
            {
                get
                {
                    if (_DUSOH_W == null)
                    {
                        _DUSOH_W = TearOff.DUSOH;
                    }
                    return _DUSOH_W;
                }
            }

            public WhereParameter DURequestedQty
            {
                get
                {
                    if (_DURequestedQty_W == null)
                    {
                        _DURequestedQty_W = TearOff.DURequestedQty;
                    }
                    return _DURequestedQty_W;
                }
            }

            public WhereParameter RecomendedQty
            {
                get
                {
                    if (_RecomendedQty_W == null)
                    {
                        _RecomendedQty_W = TearOff.RecomendedQty;
                    }
                    return _RecomendedQty_W;
                }
            }

            public WhereParameter RecievDocID
            {
                get
                {
                    if (_RecievDocID_W == null)
                    {
                        _RecievDocID_W = TearOff.RecievDocID;
                    }
                    return _RecievDocID_W;
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

            public WhereParameter OrderID
            {
                get
                {
                    if (_OrderID_W == null)
                    {
                        _OrderID_W = TearOff.OrderID;
                    }
                    return _OrderID_W;
                }
            }

            private WhereParameter _ID_W = null;
            private WhereParameter _ItemID_W = null;
            private WhereParameter _StoreId_W = null;
            private WhereParameter _ReceivingUnitID_W = null;
            private WhereParameter _LocalBatchNo_W = null;
            private WhereParameter _Quantity_W = null;
            private WhereParameter _Date_W = null;
            private WhereParameter _IsTransfer_W = null;
            private WhereParameter _IssuedBy_W = null;
            private WhereParameter _Remark_W = null;
            private WhereParameter _RefNo_W = null;
            private WhereParameter _BatchNo_W = null;
            private WhereParameter _IsApproved_W = null;
            private WhereParameter _Cost_W = null;
            private WhereParameter _NoOfPack_W = null;
            private WhereParameter _QtyPerPack_W = null;
            private WhereParameter _DUSOH_W = null;
            private WhereParameter _DURequestedQty_W = null;
            private WhereParameter _RecomendedQty_W = null;
            private WhereParameter _RecievDocID_W = null;
            private WhereParameter _EurDate_W = null;
            private WhereParameter _OrderID_W = null;

            public void WhereClauseReset()
            {
                _ID_W = null;
                _ItemID_W = null;
                _StoreId_W = null;
                _ReceivingUnitID_W = null;
                _LocalBatchNo_W = null;
                _Quantity_W = null;
                _Date_W = null;
                _IsTransfer_W = null;
                _IssuedBy_W = null;
                _Remark_W = null;
                _RefNo_W = null;
                _BatchNo_W = null;
                _IsApproved_W = null;
                _Cost_W = null;
                _NoOfPack_W = null;
                _QtyPerPack_W = null;
                _DUSOH_W = null;
                _DURequestedQty_W = null;
                _RecomendedQty_W = null;
                _RecievDocID_W = null;
                _EurDate_W = null;
                _OrderID_W = null;

                this._entity.Query.FlushWhereParameters();

            }

            private BusinessEntity _entity;
            private TearOffWhereParameter _tearOff;

        }

        public WhereClause Where
        {
            get
            {
                if (_whereClause == null)
                {
                    _whereClause = new WhereClause(this);
                }

                return _whereClause;
            }
        }

        private WhereClause _whereClause = null;
        #endregion

        #region Aggregate Clause
        public class AggregateClause
        {
            public AggregateClause(BusinessEntity entity)
            {
                this._entity = entity;
            }

            public TearOffAggregateParameter TearOff
            {
                get
                {
                    if (_tearOff == null)
                    {
                        _tearOff = new TearOffAggregateParameter(this);
                    }

                    return _tearOff;
                }
            }

            #region AggregateParameter TearOff's
            public class TearOffAggregateParameter
            {
                public TearOffAggregateParameter(AggregateClause clause)
                {
                    this._clause = clause;
                }


                public AggregateParameter ID
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.ID, Parameters.ID);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                public AggregateParameter ItemID
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.ItemID, Parameters.ItemID);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                public AggregateParameter StoreId
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.StoreId, Parameters.StoreId);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                public AggregateParameter ReceivingUnitID
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.ReceivingUnitID, Parameters.ReceivingUnitID);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                public AggregateParameter LocalBatchNo
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.LocalBatchNo, Parameters.LocalBatchNo);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                public AggregateParameter Quantity
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.Quantity, Parameters.Quantity);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                public AggregateParameter Date
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.Date, Parameters.Date);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                public AggregateParameter IsTransfer
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.IsTransfer, Parameters.IsTransfer);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                public AggregateParameter IssuedBy
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.IssuedBy, Parameters.IssuedBy);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                public AggregateParameter Remark
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.Remark, Parameters.Remark);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                public AggregateParameter RefNo
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.RefNo, Parameters.RefNo);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                public AggregateParameter BatchNo
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.BatchNo, Parameters.BatchNo);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                public AggregateParameter IsApproved
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.IsApproved, Parameters.IsApproved);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                public AggregateParameter Cost
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.Cost, Parameters.Cost);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                public AggregateParameter NoOfPack
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.NoOfPack, Parameters.NoOfPack);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                public AggregateParameter QtyPerPack
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.QtyPerPack, Parameters.QtyPerPack);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                public AggregateParameter DUSOH
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.DUSOH, Parameters.DUSOH);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                public AggregateParameter DURequestedQty
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.DURequestedQty, Parameters.DURequestedQty);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                public AggregateParameter RecomendedQty
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.RecomendedQty, Parameters.RecomendedQty);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                public AggregateParameter RecievDocID
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.RecievDocID, Parameters.RecievDocID);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                public AggregateParameter EurDate
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.EurDate, Parameters.EurDate);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                public AggregateParameter OrderID
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.OrderID, Parameters.OrderID);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }


                private AggregateClause _clause;
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

            public AggregateParameter StoreId
            {
                get
                {
                    if (_StoreId_W == null)
                    {
                        _StoreId_W = TearOff.StoreId;
                    }
                    return _StoreId_W;
                }
            }

            public AggregateParameter ReceivingUnitID
            {
                get
                {
                    if (_ReceivingUnitID_W == null)
                    {
                        _ReceivingUnitID_W = TearOff.ReceivingUnitID;
                    }
                    return _ReceivingUnitID_W;
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

            public AggregateParameter IsTransfer
            {
                get
                {
                    if (_IsTransfer_W == null)
                    {
                        _IsTransfer_W = TearOff.IsTransfer;
                    }
                    return _IsTransfer_W;
                }
            }

            public AggregateParameter IssuedBy
            {
                get
                {
                    if (_IssuedBy_W == null)
                    {
                        _IssuedBy_W = TearOff.IssuedBy;
                    }
                    return _IssuedBy_W;
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

            public AggregateParameter DUSOH
            {
                get
                {
                    if (_DUSOH_W == null)
                    {
                        _DUSOH_W = TearOff.DUSOH;
                    }
                    return _DUSOH_W;
                }
            }

            public AggregateParameter DURequestedQty
            {
                get
                {
                    if (_DURequestedQty_W == null)
                    {
                        _DURequestedQty_W = TearOff.DURequestedQty;
                    }
                    return _DURequestedQty_W;
                }
            }

            public AggregateParameter RecomendedQty
            {
                get
                {
                    if (_RecomendedQty_W == null)
                    {
                        _RecomendedQty_W = TearOff.RecomendedQty;
                    }
                    return _RecomendedQty_W;
                }
            }

            public AggregateParameter RecievDocID
            {
                get
                {
                    if (_RecievDocID_W == null)
                    {
                        _RecievDocID_W = TearOff.RecievDocID;
                    }
                    return _RecievDocID_W;
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

            public AggregateParameter OrderID
            {
                get
                {
                    if (_OrderID_W == null)
                    {
                        _OrderID_W = TearOff.OrderID;
                    }
                    return _OrderID_W;
                }
            }

            private AggregateParameter _ID_W = null;
            private AggregateParameter _ItemID_W = null;
            private AggregateParameter _StoreId_W = null;
            private AggregateParameter _ReceivingUnitID_W = null;
            private AggregateParameter _LocalBatchNo_W = null;
            private AggregateParameter _Quantity_W = null;
            private AggregateParameter _Date_W = null;
            private AggregateParameter _IsTransfer_W = null;
            private AggregateParameter _IssuedBy_W = null;
            private AggregateParameter _Remark_W = null;
            private AggregateParameter _RefNo_W = null;
            private AggregateParameter _BatchNo_W = null;
            private AggregateParameter _IsApproved_W = null;
            private AggregateParameter _Cost_W = null;
            private AggregateParameter _NoOfPack_W = null;
            private AggregateParameter _QtyPerPack_W = null;
            private AggregateParameter _DUSOH_W = null;
            private AggregateParameter _DURequestedQty_W = null;
            private AggregateParameter _RecomendedQty_W = null;
            private AggregateParameter _RecievDocID_W = null;
            private AggregateParameter _EurDate_W = null;
            private AggregateParameter _OrderID_W = null;

            public void AggregateClauseReset()
            {
                _ID_W = null;
                _ItemID_W = null;
                _StoreId_W = null;
                _ReceivingUnitID_W = null;
                _LocalBatchNo_W = null;
                _Quantity_W = null;
                _Date_W = null;
                _IsTransfer_W = null;
                _IssuedBy_W = null;
                _Remark_W = null;
                _RefNo_W = null;
                _BatchNo_W = null;
                _IsApproved_W = null;
                _Cost_W = null;
                _NoOfPack_W = null;
                _QtyPerPack_W = null;
                _DUSOH_W = null;
                _DURequestedQty_W = null;
                _RecomendedQty_W = null;
                _RecievDocID_W = null;
                _EurDate_W = null;
                _OrderID_W = null;

                this._entity.Query.FlushAggregateParameters();

            }

            private BusinessEntity _entity;
            private TearOffAggregateParameter _tearOff;

        }

        public AggregateClause Aggregate
        {
            get
            {
                if (_aggregateClause == null)
                {
                    _aggregateClause = new AggregateClause(this);
                }

                return _aggregateClause;
            }
        }

        private AggregateClause _aggregateClause = null;
        #endregion

        protected override IDbCommand GetInsertCommand()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[" + this.SchemaStoredProcedure + "proc_IssueDocDeletedInsert]";

            CreateParameters(cmd);

            //SqlParameter p;
            //p = cmd.Parameters[Parameters.ID.ParameterName];
            //p.Direction = ParameterDirection.Output;

            return cmd;
        }

        private IDbCommand CreateParameters(SqlCommand cmd)
        {
            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.ID);
            p.SourceColumn = ColumnNames.ID;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.ItemID);
            p.SourceColumn = ColumnNames.ItemID;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.StoreId);
            p.SourceColumn = ColumnNames.StoreId;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.ReceivingUnitID);
            p.SourceColumn = ColumnNames.ReceivingUnitID;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.LocalBatchNo);
            p.SourceColumn = ColumnNames.LocalBatchNo;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.Quantity);
            p.SourceColumn = ColumnNames.Quantity;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.Date);
            p.SourceColumn = ColumnNames.Date;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.IsTransfer);
            p.SourceColumn = ColumnNames.IsTransfer;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.IssuedBy);
            p.SourceColumn = ColumnNames.IssuedBy;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.Remark);
            p.SourceColumn = ColumnNames.Remark;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.RefNo);
            p.SourceColumn = ColumnNames.RefNo;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.BatchNo);
            p.SourceColumn = ColumnNames.BatchNo;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.IsApproved);
            p.SourceColumn = ColumnNames.IsApproved;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.Cost);
            p.SourceColumn = ColumnNames.Cost;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.NoOfPack);
            p.SourceColumn = ColumnNames.NoOfPack;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.QtyPerPack);
            p.SourceColumn = ColumnNames.QtyPerPack;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.DUSOH);
            p.SourceColumn = ColumnNames.DUSOH;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.DURequestedQty);
            p.SourceColumn = ColumnNames.DURequestedQty;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.RecomendedQty);
            p.SourceColumn = ColumnNames.RecomendedQty;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.RecievDocID);
            p.SourceColumn = ColumnNames.RecievDocID;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.EurDate);
            p.SourceColumn = ColumnNames.EurDate;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.OrderID);
            p.SourceColumn = ColumnNames.OrderID;
            p.SourceVersion = DataRowVersion.Current;


            return cmd;
        }
    }
}
