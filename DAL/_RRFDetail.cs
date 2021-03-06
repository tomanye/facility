
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

// Generated by MyGeneration Version # (1.3.0.9)

using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Specialized;

using MyGeneration.dOOdads;

namespace DAL
{
	public abstract class _RRFDetail : SqlClientEntity
	{
		public _RRFDetail()
		{
			this.QuerySource = "RRFDetail";
			this.MappingName = "RRFDetail";

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
			
			return base.LoadFromSql("[" + this.SchemaStoredProcedure + "proc_RRFDetailLoadAll]", parameters);
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

		
			return base.LoadFromSql("[" + this.SchemaStoredProcedure + "proc_RRFDetailLoadByPrimaryKey]", parameters);
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
			
			public static SqlParameter RRFID
			{
				get
				{
					return new SqlParameter("@RRFID", SqlDbType.Int, 0);
				}
			}
			
			public static SqlParameter StoreID
			{
				get
				{
					return new SqlParameter("@StoreID", SqlDbType.Int, 0);
				}
			}
			
			public static SqlParameter ItemID
			{
				get
				{
					return new SqlParameter("@ItemID", SqlDbType.Int, 0);
				}
			}
			
			public static SqlParameter RequestedQuantity
			{
				get
				{
					return new SqlParameter("@RequestedQuantity", SqlDbType.Int, 0);
				}
			}
			
		}
		#endregion		
	
		#region ColumnNames
		public class ColumnNames
		{  
            public const string ID = "ID";
            public const string RRFID = "RRFID";
            public const string StoreID = "StoreID";
            public const string ItemID = "ItemID";
            public const string RequestedQuantity = "RequestedQuantity";

			static public string ToPropertyName(string columnName)
			{
				if(ht == null)
				{
					ht = new Hashtable();
					
					ht[ID] = _RRFDetail.PropertyNames.ID;
					ht[RRFID] = _RRFDetail.PropertyNames.RRFID;
					ht[StoreID] = _RRFDetail.PropertyNames.StoreID;
					ht[ItemID] = _RRFDetail.PropertyNames.ItemID;
					ht[RequestedQuantity] = _RRFDetail.PropertyNames.RequestedQuantity;

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
            public const string RRFID = "RRFID";
            public const string StoreID = "StoreID";
            public const string ItemID = "ItemID";
            public const string RequestedQuantity = "RequestedQuantity";

			static public string ToColumnName(string propertyName)
			{
				if(ht == null)
				{
					ht = new Hashtable();
					
					ht[ID] = _RRFDetail.ColumnNames.ID;
					ht[RRFID] = _RRFDetail.ColumnNames.RRFID;
					ht[StoreID] = _RRFDetail.ColumnNames.StoreID;
					ht[ItemID] = _RRFDetail.ColumnNames.ItemID;
					ht[RequestedQuantity] = _RRFDetail.ColumnNames.RequestedQuantity;

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
            public const string RRFID = "s_RRFID";
            public const string StoreID = "s_StoreID";
            public const string ItemID = "s_ItemID";
            public const string RequestedQuantity = "s_RequestedQuantity";

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

		public virtual int RRFID
	    {
			get
	        {
				return base.Getint(ColumnNames.RRFID);
			}
			set
	        {
				base.Setint(ColumnNames.RRFID, value);
			}
		}

		public virtual int StoreID
	    {
			get
	        {
				return base.Getint(ColumnNames.StoreID);
			}
			set
	        {
				base.Setint(ColumnNames.StoreID, value);
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

		public virtual int RequestedQuantity
	    {
			get
	        {
				return base.Getint(ColumnNames.RequestedQuantity);
			}
			set
	        {
				base.Setint(ColumnNames.RequestedQuantity, value);
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
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.ID);
				else
					this.ID = base.SetintAsString(ColumnNames.ID, value);
			}
		}

		public virtual string s_RRFID
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.RRFID) ? string.Empty : base.GetintAsString(ColumnNames.RRFID);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.RRFID);
				else
					this.RRFID = base.SetintAsString(ColumnNames.RRFID, value);
			}
		}

		public virtual string s_StoreID
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.StoreID) ? string.Empty : base.GetintAsString(ColumnNames.StoreID);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.StoreID);
				else
					this.StoreID = base.SetintAsString(ColumnNames.StoreID, value);
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
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.ItemID);
				else
					this.ItemID = base.SetintAsString(ColumnNames.ItemID, value);
			}
		}

		public virtual string s_RequestedQuantity
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.RequestedQuantity) ? string.Empty : base.GetintAsString(ColumnNames.RequestedQuantity);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.RequestedQuantity);
				else
					this.RequestedQuantity = base.SetintAsString(ColumnNames.RequestedQuantity, value);
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
					if(_tearOff == null)
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

				public WhereParameter RRFID
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.RRFID, Parameters.RRFID);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter StoreID
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.StoreID, Parameters.StoreID);
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

				public WhereParameter RequestedQuantity
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.RequestedQuantity, Parameters.RequestedQuantity);
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
					if(_ID_W == null)
	        	    {
						_ID_W = TearOff.ID;
					}
					return _ID_W;
				}
			}

			public WhereParameter RRFID
		    {
				get
		        {
					if(_RRFID_W == null)
	        	    {
						_RRFID_W = TearOff.RRFID;
					}
					return _RRFID_W;
				}
			}

			public WhereParameter StoreID
		    {
				get
		        {
					if(_StoreID_W == null)
	        	    {
						_StoreID_W = TearOff.StoreID;
					}
					return _StoreID_W;
				}
			}

			public WhereParameter ItemID
		    {
				get
		        {
					if(_ItemID_W == null)
	        	    {
						_ItemID_W = TearOff.ItemID;
					}
					return _ItemID_W;
				}
			}

			public WhereParameter RequestedQuantity
		    {
				get
		        {
					if(_RequestedQuantity_W == null)
	        	    {
						_RequestedQuantity_W = TearOff.RequestedQuantity;
					}
					return _RequestedQuantity_W;
				}
			}

			private WhereParameter _ID_W = null;
			private WhereParameter _RRFID_W = null;
			private WhereParameter _StoreID_W = null;
			private WhereParameter _ItemID_W = null;
			private WhereParameter _RequestedQuantity_W = null;

			public void WhereClauseReset()
			{
				_ID_W = null;
				_RRFID_W = null;
				_StoreID_W = null;
				_ItemID_W = null;
				_RequestedQuantity_W = null;

				this._entity.Query.FlushWhereParameters();

			}
	
			private BusinessEntity _entity;
			private TearOffWhereParameter _tearOff;
			
		}
	
		public WhereClause Where
		{
			get
			{
				if(_whereClause == null)
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
					if(_tearOff == null)
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

				public AggregateParameter RRFID
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.RRFID, Parameters.RRFID);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter StoreID
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.StoreID, Parameters.StoreID);
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

				public AggregateParameter RequestedQuantity
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.RequestedQuantity, Parameters.RequestedQuantity);
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
					if(_ID_W == null)
	        	    {
						_ID_W = TearOff.ID;
					}
					return _ID_W;
				}
			}

			public AggregateParameter RRFID
		    {
				get
		        {
					if(_RRFID_W == null)
	        	    {
						_RRFID_W = TearOff.RRFID;
					}
					return _RRFID_W;
				}
			}

			public AggregateParameter StoreID
		    {
				get
		        {
					if(_StoreID_W == null)
	        	    {
						_StoreID_W = TearOff.StoreID;
					}
					return _StoreID_W;
				}
			}

			public AggregateParameter ItemID
		    {
				get
		        {
					if(_ItemID_W == null)
	        	    {
						_ItemID_W = TearOff.ItemID;
					}
					return _ItemID_W;
				}
			}

			public AggregateParameter RequestedQuantity
		    {
				get
		        {
					if(_RequestedQuantity_W == null)
	        	    {
						_RequestedQuantity_W = TearOff.RequestedQuantity;
					}
					return _RequestedQuantity_W;
				}
			}

			private AggregateParameter _ID_W = null;
			private AggregateParameter _RRFID_W = null;
			private AggregateParameter _StoreID_W = null;
			private AggregateParameter _ItemID_W = null;
			private AggregateParameter _RequestedQuantity_W = null;

			public void AggregateClauseReset()
			{
				_ID_W = null;
				_RRFID_W = null;
				_StoreID_W = null;
				_ItemID_W = null;
				_RequestedQuantity_W = null;

				this._entity.Query.FlushAggregateParameters();

			}
	
			private BusinessEntity _entity;
			private TearOffAggregateParameter _tearOff;
			
		}
	
		public AggregateClause Aggregate
		{
			get
			{
				if(_aggregateClause == null)
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
			cmd.CommandText = "[" + this.SchemaStoredProcedure + "proc_RRFDetailInsert]";
	
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
			cmd.CommandText = "[" + this.SchemaStoredProcedure + "proc_RRFDetailUpdate]";
	
			CreateParameters(cmd);
			      
			return cmd;
		}
	
		protected override IDbCommand GetDeleteCommand()
		{
		
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[" + this.SchemaStoredProcedure + "proc_RRFDetailDelete]";
	
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

			p = cmd.Parameters.Add(Parameters.RRFID);
			p.SourceColumn = ColumnNames.RRFID;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.StoreID);
			p.SourceColumn = ColumnNames.StoreID;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.ItemID);
			p.SourceColumn = ColumnNames.ItemID;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.RequestedQuantity);
			p.SourceColumn = ColumnNames.RequestedQuantity;
			p.SourceVersion = DataRowVersion.Current;


			return cmd;
		}
	}
}
