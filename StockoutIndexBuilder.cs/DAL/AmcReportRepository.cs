using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using StockoutIndexBuilder.Models;

namespace StockoutIndexBuilder.DAL
{
  public class AmcReportRepository
    {
      private readonly StockoutEntities context =new StockoutEntities();
      public void Add(AmcReport amcReport)
      {
          context.AmcReports.Add(amcReport);
          context.SaveChanges();
      }
      public void DeleteAll()
      {
          foreach (var item in context.AmcReports)
          {
              this.Remove(item);
          }
          context.SaveChanges();
      }
      void Remove(AmcReport amcreport)
      {
          context.AmcReports.Remove(amcreport);
      }
    }
}
