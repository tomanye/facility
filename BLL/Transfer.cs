using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class Transfer:_Transfer
    {
        public Transfer()
        {
            
        }

        public DataTable GetTransfered(int itemId, int storeId)
        {
            this.FlushData();
            this.LoadFromRawSql(String.Format("select * from Transfer where ItemID ={0} And FromStoreID={1}",itemId,storeId));
            return this.DataTable;

        }
    }
}
