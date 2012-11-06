using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public int? DosageFormId { get; set; }
        public int? IINID { get; set; }

        public virtual ICollection<Stockout> Stockouts { get; set; }
        public virtual ICollection<Product>  Products { get; set; }
       
    }
}
