using NUnit.Framework;

namespace CabInvoiceTesting
{
    public class Tests
    {
        [Test]
        public void GivenDistanceAndTime_WhenCalculated_ShouldReturnTotalFare()
        {
            double distance = 2.0;// In kilometer
            double time = 5.0; // In minutes
            InvoiceGenerator invoice = new InvoiceGenerator();
            double fare = invoice.CalculateFare(distance, time);
            Assert.AreEqual(fare, 25.0);
        }

        [Test]
        public void GivenDistanceAndTime_WhenLessThanMinimumFarre_ShouldReturnMinumumFare()
        {
            double minimumFare = 5.0;
            double distance = 0.1;
            double time = 2.0;
            InvoiceGenerator invoice = new InvoiceGenerator();
            double fare = invoice.CalculateFare(distance, time);
            Assert.AreEqual(fare, minimumFare);
        }
        [Test]
        public void GivenMultipleRides_WhenCalculatedFare_ShouldReturnTotalFare()
        {
            Ride[] rides = {
                new Ride(2.0,25.0),
                new Ride(3.0,55.0)
            };
            InvoiceGenerator invoice = new InvoiceGenerator();
            double totalFare = invoice.CalculateTotalFare(rides);
            Assert.AreEqual(totalFare, 130.0);
        }
    }
}