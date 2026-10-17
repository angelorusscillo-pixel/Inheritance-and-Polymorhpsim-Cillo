using System;
using System.Collections.Generic;
using System.Text;

namespace Urban_Parcel___Building_Asset_Manager
{
    internal class Residential
    {
        public class ResidentialLot : PropertyAsset
        {
            public double Frontage { get; set; }
            public double Depth { get; set; }

            public ResidentialLot(string code, double taxRate, double frontage, double depth)
                : base(code, taxRate)
            {
                Frontage = frontage;
                Depth = depth;
            }

            public override double ComputeFootprintArea()
            {
                return Frontage * Depth;
            }

            public override double ComputeEnclosurePerimeter()
            {
                return 2 * (Frontage + Depth);
            }
        }
    }
}
