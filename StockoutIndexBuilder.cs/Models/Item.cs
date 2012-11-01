using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StockoutIndexBuilder.Models
{
    [Table("Items")]
    public class Item
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }
        public string StockCode { get; set; }
        public string Strength  { get; set; }
        public int? DosageFormID { get; set; }
        public virtual ICollection<Stockout> Stockouts { get; set; }
      
    }
}
