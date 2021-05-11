using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PieChart
{
    public class SectorPart
    {
        public SectorPart(double spanAngle, Brush fillBrush)
        {
            this.SpanAngle = spanAngle;
            this.FillBrush = fillBrush;
        }
        public double SpanAngle { get; set; }

        public Brush FillBrush { get; set; }

        public bool PIsLargeArc
        {
            get
            {
                return SpanAngle > 180 ? true : false;
            }
        }
    }
}
