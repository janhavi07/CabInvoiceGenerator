using CabInvoiceGenerator;
using System;

namespace CabInvoiceTesting
{
    public class InvoiceGenerator
    {
        /// <summary>
    /// Calculated the total fare of the ride according to its type
    /// </summary>
    /// <param name="type"></param>
    /// <param name="distance"></param>
    /// <param name="time"></param>
    /// <returns></returns>
     
        public double CalculateFare(Cab type,double distance, double time)
        {
            double totalFare = distance*type.perKilometer + time*type.perMinute;
            if (totalFare < type.minimumFare)
                return type.minimumFare;
            return totalFare;
            
        }

        /// <summary>
        /// Genrates Invoice summary of the rides taken by the user
        /// </summary>
        /// <param name="rides"></param>
        /// <returns></returns>
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