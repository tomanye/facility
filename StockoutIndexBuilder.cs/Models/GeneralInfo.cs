using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace StockoutIndexBuilder.Models
{
    [Table("GeneralInfo")]
  public class GeneralInfo
    {
        [Key]
        public int ID { get; set; }
        public int AMCRange { get; set; }
    }
}
