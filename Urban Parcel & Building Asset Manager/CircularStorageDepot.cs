using System;

namespace Urban_Parcel___Building_Asset_Manager
{
    public class CircularStorageDepot : PropertyAsset
    {
        public double Radius { get; set; }

        public CircularStorageDepot(string code, double taxRate, double radius)
            : base(code, taxRate)
        {
            Radius = radius;
        }

        public override double ComputeFootprintArea()
        {
            return Math.PI * Radius * Radius;
        }

        public override double ComputeEnclosurePerimeter()
        {
            return 2 * Math.PI * Radius;
        }
    }
}