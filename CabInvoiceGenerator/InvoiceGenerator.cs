using System;

namespace CabInvoiceTesting
{
    public class InvoiceGenerator
    {
        
        private double COST_PER_KILOMETER = 10.0;
        private double COST_PER_MINUTE = 1.0;
        private double MINIMUM_FARE = 5.0;
        
        public double CalculateFare(double distance, double time)
        {
            double totalFare = ((distance * COST_PER_KILOMETER) + (time * COST_PER_MINUTE));
            if (totalFare < MINIMUM_FARE)
                return MINIMUM_FARE;
            return totalFare;
        }
    }
}