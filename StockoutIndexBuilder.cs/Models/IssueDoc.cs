using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockoutIndexBuilder.Models
{
    [Table("IssueDoc")]
    public class IssueDoc
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }
        public int ItemID { get; set; }
        [Column("StoreId")]
        public int StoreID { get; set; }
        public DateTime? Date { get; set; }
        public long Quantity { get; set; }
    }
}
