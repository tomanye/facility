using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StockoutIndexBuilder.Models
{
    [Table("ReceiveDoc")]
    public class ReceiveDoc
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }
        public int ItemID { get; set; }
        public DateTime? Date { get; set; }
        public long Quantity { get; set; }
        public int StoreID { get; set; }
    }
}
