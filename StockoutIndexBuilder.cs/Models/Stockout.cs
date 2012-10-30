using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockoutIndexBuilder.Models
{
    [Table("Stockout")]
    public class Stockout
    {
        [Key]
        [Column("ID")]
        public int StockoutID { get; set; }
        public int ItemID { get; set; }
        public int StoreID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual Item Item { get; set; }

        [NotMapped]
        public int NumberOfDays { get { return EndDate.Subtract(StartDate).Days; } }

    }
}
