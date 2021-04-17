using CabInvoiceGenerator;
using System;

namespace CabInvoiceTesting
{
    public class InvoiceGenerator
    {
     
        public double CalculateFare(Cab type,double distance, double time)
        {
            double totalFare = distance*type.perKilometer + time*type.perMinute;
            if (totalFare < type.minimumFare)
                return type.minimumFare;
            return totalFare;
            
        }

        public Invoice GenerateInvoice(Ride[] rides)
        {
            double totalFare = 0;
            foreach (Ride ride in rides)
            {
                 totalFare += CalculateFare(ride.type,ride.rideDistance,ride.rideTime);
            }
            double avgFare = (totalFare / rides.Length);
            Invoice invoice = new Invoice();
            invoice.totalFare = totalFare;
            invoice.totalRides = rides.Length;
            invoice.averageFare = avgFare;
            return invoice;
        }
    }
}