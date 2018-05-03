using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace BLL
{
    public interface IModel
    {
        float AvailableDetailHeight { get; }
        float ItemWidth { get; }
        float UnitWidth { get; }
        float BatchWidth { get; }
        float InternalDrugCodeWidth { get; }
        float RowHeight { get; }

        Font ItemFont { get; }
        Font UnitFont { get; }
        Font BatchFont { get; }
        Font InternalDrugCodeFont { get; }
    }
}
