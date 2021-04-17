using CabInvoiceTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class Cab
    {
       public static readonly Cab NORMAL = new Cab(10.0,1.0,5.0);
       public static readonly Cab PREMINUM = new Cab(15.0, 2.0, 15.0);

        public readonly double perKilometer;
        public readonly double perMinute;
        public readonly double minimumFare;
      
        public Cab(double perKilometer,double perMinute, double minimumFare)
        {
            this.perKilometer=perKilometer;
            this.perMinute = perMinute;
            this.minimumFare = minimumFare;
        }

    }
}
