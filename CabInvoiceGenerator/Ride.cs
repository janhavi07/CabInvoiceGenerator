using CabInvoiceGenerator;

namespace CabInvoiceTesting
{
    public class Ride
    {
         public double rideDistance;
         public double rideTime;
         public Cab type;
        public Ride(Cab type,double distance, double time)
        {
            this.rideDistance = distance;
            this.rideTime = time;
            this.type = type;
        }
    }
}