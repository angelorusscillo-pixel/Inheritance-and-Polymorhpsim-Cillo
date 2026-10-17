using System;
using System.Collections.Generic;
using System.Text;

namespace Urban_Parcel___Building_Asset_Manager
{
    internal class TriangulaPark
    {
        public class TriangularPark : PropertyAsset
        {
            public double BaseSpan { get; set; }
            public double Height { get; set; }
            public double Side1 { get; set; }
            public double Side2 { get; set; }
            public double Side3 { get; set; }

            public TriangularPark(string code, double taxRate,
                                  double baseSpan, double height,
                                  double side1, double side2, double side3)
                : base(code, taxRate)
            {
                BaseSpan = baseSpan;
                Height = height;
                Side1 = side1;
                Side2 = side2;
                Side3 = side3;
            }

            public override double ComputeFootprintArea()
            {
                return 0.5 * BaseSpan * Height;
            }

            public override double ComputeEnclosurePerimeter()
            {
                return Side1 + Side2 + Side3;
            }
        }
    }
}
