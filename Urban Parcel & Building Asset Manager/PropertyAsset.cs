using System;
using System.Collections.Generic;
using System.Text;

namespace Urban_Parcel___Building_Asset_Manager
{
    public abstract class PropertyAsset
    {
        public string PropertyCode { get; set; }
        public double TaxRatePerUnitArea { get; set; }

        public PropertyAsset(string code, double taxRate)
        {
            PropertyCode = code;
            TaxRatePerUnitArea = taxRate;
        }

        public abstract double ComputeFootprintArea();
        public abstract double ComputeEnclosurePerimeter();

        public virtual double ComputeEstimatedTax()
        {
            return ComputeFootprintArea() * TaxRatePerUnitArea;
        }
    }
}