using System;
using System.Collections.Generic;
using System.Linq;
using BLL;
using PharmInventory.Barcode.DTO;

namespace PharmInventory.Barcode.Service
{
    public class BarcodeDTOService
    {
        public static IEnumerable<InvoiceHeader> CreateInvoiceForBarcode(int[] stvIDs)
        {
            var invoices = new List<InvoiceHeader>();
            foreach (int stvID in stvIDs.Distinct())
            {
                var issue = new Issue();

                issue.LoadByPrimaryKey(stvID);
                var issueDetail = IssueDoc.GetIssueDetailForBarcode(stvID).Table;

                var invoice = new InvoiceHeader
                {
                    A = issue.AccountID,
                    F = GeneralInfo.Current.HospitalName,
                    Dt = issue.PrintedDate,
                    IN = issue.InvoiceNumber,
                    W = issue.IsColumnNull("WarehouseID") ? 0 : issue.WarehouseID,
                    T = issue.ReceivingUnitID,
                    D = issueDetail.AsEnumerable().Select(i => new InvoiceDetail
                        {
                            I = i.Field<int>("ItemID"),
                            U = i.Field<int>("UnitID"),
                            Q = Math.Round(i.Field<decimal>("Quantity"), 1),
                            C = Math.Round(i.Field<decimal>("UnitCost"), 1),
                            B = i.Field<string>("BatchNo"),
                            E = i.Field<DateTime?>("ExpDate"),
                            QP = i.Field<int>("QP")
                        })
                };
                invoices.Add(invoice);
            }
            return invoices;
        }
    }
}
