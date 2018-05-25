﻿
/*
'===============================================================================
'  Generated From - CSharp_dOOdads_BusinessEntity.vbgen
' 
'  ** IMPORTANT  ** 
'  How to Generate your stored procedures:
' 
'  SQL        = SQL_StoredProcs.vbgen
'  ACCESS     = Access_StoredProcs.vbgen
'  ORACLE     = Oracle_StoredProcs.vbgen
'  FIREBIRD   = FirebirdStoredProcs.vbgen
'  POSTGRESQL = PostgreSQL_StoredProcs.vbgen
'
'  The supporting base class SqlClientEntity is in the Architecture directory in "dOOdads".
'  
'  This object is 'abstract' which means you need to inherit from it to be able
'  to instantiate it.  This is very easilly done. You can override properties and
'  methods in your derived class, this allows you to regenerate this class at any
'  time and not worry about overwriting custom code. 
'
'  NEVER EDIT THIS FILE.
'
'  public class YourObject :  _YourObject
'  {
'
'  }
'
'===============================================================================
*/

// Generated by MyGeneration Version # (1.2.0.7)

using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Specialized;

using MyGeneration.dOOdads;

namespace DAL
{
    public abstract class _YearEndDetail : SqlClientEntity
    {
        public _YearEndDetail()
        {
            this.QuerySource = "YearEndDetail";
            this.MappingName = "YearEndDetail";

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

            return base.LoadFromSql("[" + this.SchemaStoredProcedure + "proc_YearEndDetailLoadAll]", parameters);
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


            return base.LoadFromSql("[" + this.SchemaStoredProcedure + "proc_YearEndDetailLoadByPrimaryKey]", parameters);
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

            public static SqlParameter YearEndID
            {
                get
                {
                    return new SqlParameter("@YearEndID", SqlDbType.Int, 0);
                }
            }

            public static SqlParameter ReceiveDocID
            {
                get
                {
                    return new SqlParameter("@ReceiveDocID", SqlDbType.Int, 0);
                }
            }

            public static SqlParameter Quantity
            {
                get
                {
                    return new SqlParameter("@Quantity", SqlDbType.BigInt, 0);
                }
            }

        }
        #endregion

        #region ColumnNames
        public class ColumnNames
        {
            public const string ID = "ID";
            public const string YearEndID = "YearEndID";
            public const string ReceiveDocID = "ReceiveDocID";
            public const string Quantity = "Quantity";

            static public string ToPropertyName(string columnName)
            {
                if (ht == null)
                {
                    ht = new Hashtable();

                    ht[ID] = _YearEndDetail.PropertyNames.ID;
                    ht[YearEndID] = _YearEndDetail.PropertyNames.YearEndID;
                    ht[ReceiveDocID] = _YearEndDetail.PropertyNames.ReceiveDocID;
                    ht[Quantity] = _YearEndDetail.PropertyNames.Quantity;

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
            public const string YearEndID = "YearEndID";
            public const string ReceiveDocID = "ReceiveDocID";
            public const string Quantity = "Quantity";

            static public string ToColumnName(string propertyName)
            {
                if (ht == null)
                {
                    ht = new Hashtable();

                    ht[ID] = _YearEndDetail.ColumnNames.ID;
                    ht[YearEndID] = _YearEndDetail.ColumnNames.YearEndID;
                    ht[ReceiveDocID] = _YearEndDetail.ColumnNames.ReceiveDocID;
                    ht[Quantity] = _YearEndDetail.ColumnNames.Quantity;

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
            public const string YearEndID = "s_YearEndID";
            public const string ReceiveDocID = "s_ReceiveDocID";
            public const string Quantity = "s_Quantity";

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

        public virtual int YearEndID
        {
            get
            {
                return base.Getint(ColumnNames.YearEndID);
            }
            set
            {
                base.Setint(ColumnNames.YearEndID, value);
            }
        }

        public virtual int ReceiveDocID
        {
            get
            {
                return base.Getint(ColumnNames.ReceiveDocID);
            }
            set
            {
                base.Setint(ColumnNames.ReceiveDocID, value);
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

        public virtual string s_YearEndID
        {
            get
            {
                return this.IsColumnNull(ColumnNames.YearEndID) ? string.Empty : base.GetintAsString(ColumnNames.YearEndID);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.YearEndID);
                else
                    this.YearEndID = base.SetintAsString(ColumnNames.YearEndID, value);
            }
        }

        public virtual string s_ReceiveDocID
        {
            get
            {
                return this.IsColumnNull(ColumnNames.ReceiveDocID) ? string.Empty : base.GetintAsString(ColumnNames.ReceiveDocID);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.ReceiveDocID);
                else
                    this.ReceiveDocID = base.SetintAsString(ColumnNames.ReceiveDocID, value);
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

                public WhereParameter YearEndID
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.YearEndID, Parameters.YearEndID);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter ReceiveDocID
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.ReceiveDocID, Parameters.ReceiveDocID);
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

            public WhereParameter YearEndID
            {
                get
                {
                    if (_YearEndID_W == null)
                    {
                        _YearEndID_W = TearOff.YearEndID;
                    }
                    return _YearEndID_W;
                }
            }

            public WhereParameter ReceiveDocID
            {
                get
                {
                    if (_ReceiveDocID_W == null)
                    {
                        _ReceiveDocID_W = TearOff.ReceiveDocID;
                    }
                    return _ReceiveDocID_W;
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

            private WhereParameter _ID_W = null;
            private WhereParameter _YearEndID_W = null;
            private WhereParameter _ReceiveDocID_W = null;
            private WhereParameter _Quantity_W = null;

            public void WhereClauseReset()
            {
                _ID_W = null;
                _YearEndID_W = null;
                _ReceiveDocID_W = null;
                _Quantity_W = null;

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

                public AggregateParameter YearEndID
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.YearEndID, Parameters.YearEndID);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                public AggregateParameter ReceiveDocID
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.ReceiveDocID, Parameters.ReceiveDocID);
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

            public AggregateParameter YearEndID
            {
                get
                {
                    if (_YearEndID_W == null)
                    {
                        _YearEndID_W = TearOff.YearEndID;
                    }
                    return _YearEndID_W;
                }
            }

            public AggregateParameter ReceiveDocID
            {
                get
                {
                    if (_ReceiveDocID_W == null)
                    {
                        _ReceiveDocID_W = TearOff.ReceiveDocID;
                    }
                    return _ReceiveDocID_W;
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

            private AggregateParameter _ID_W = null;
            private AggregateParameter _YearEndID_W = null;
            private AggregateParameter _ReceiveDocID_W = null;
            private AggregateParameter _Quantity_W = null;

            public void AggregateClauseReset()
            {
                _ID_W = null;
                _YearEndID_W = null;
                _ReceiveDocID_W = null;
                _Quantity_W = null;

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
            cmd.CommandText = "[" + this.SchemaStoredProcedure + "proc_YearEndDetailInsert]";

            CreateParameters(cmd);

            SqlParameter p;
            p = cmd.Parameters[Parameters.ID.ParameterName];
            p.Direction = ParameterDirection.Output;

            return cmd;
        }

        protected override IDbCommand GetUpdateCommand()
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[" + this.SchemaStoredProcedure + "proc_YearEndDetailUpdate]";

            CreateParameters(cmd);

            return cmd;
        }

        protected override IDbCommand GetDeleteCommand()
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[" + this.SchemaStoredProcedure + "proc_YearEndDetailDelete]";

            SqlParameter p;
            p = cmd.Parameters.Add(Parameters.ID);
            p.SourceColumn = ColumnNames.ID;
            p.SourceVersion = DataRowVersion.Current;


            return cmd;
        }

        private IDbCommand CreateParameters(SqlCommand cmd)
        {
            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.ID);
            p.SourceColumn = ColumnNames.ID;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.YearEndID);
            p.SourceColumn = ColumnNames.YearEndID;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.ReceiveDocID);
            p.SourceColumn = ColumnNames.ReceiveDocID;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.Quantity);
            p.SourceColumn = ColumnNames.Quantity;
            p.SourceVersion = DataRowVersion.Current;


            return cmd;
        }
    }
}


