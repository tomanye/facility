﻿
// Generated by MyGeneration Version # (1.2.0.7)

using DAL;
using System;
using System.Data;
namespace BLL
{
    public class UserStore : _UserStore
    {
        public UserStore()
        {

        }
        public void DeleteAllTStoreForUser(int userid)
        {
            this.FlushData();
            this.Where.WhereClauseReset();
            this.Where.UserID.Value = userid;
            this.Query.Load();
            foreach (DataRowView dv in this.DataTable.DefaultView)
            {
                this.LoadByPrimaryKey(Convert.ToInt32(dv["ID"]));
                this.MarkAsDeleted();
                this.Save();
            }
        }
    }
}