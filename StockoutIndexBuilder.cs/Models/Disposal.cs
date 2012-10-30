using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockoutIndexBuilder.Models
{
    [Table("Disposal")]
    public class Disposal
    {
        [Key]        
        public int ID { get; set; }
        public int ItemID { get; set; }
        public long? Quantity { get; set; }
        public DateTime? Date { get; set; }
        public int StoreID { get; set; }
    }
}
