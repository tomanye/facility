using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace StockoutIndexBuilder.Models
{
  [Table("Product")]
  public class Product
    {
      [Key]
      public int ID { get; set; }
      public string IIN { get; set; }

     
    }
}
