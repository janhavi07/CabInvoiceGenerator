using NUnit.Framework;

namespace CabInvoiceTesting
{
    public class Tests
    {
        InvoiceGenerator invoice = new InvoiceGenerator();

        [Test]
        public void GivenDistanceAndTime_WhenCalculated_ShouldReturnTotalFare()
        {
            double distance = 2.0;// In kilometer
            double time = 5.0; // In minutes
            double fare = invoice.CalculateFare(distance, time);
            Assert.AreEqual(fare, 25.0);
        }

        [Test]
        public void GivenDistanceAndTime_WhenLessThanMinimumFarre_ShouldReturnMinumumFare()
        {
            double minimumFare = 5.0;
            double distance = 0.1;
            double time = 2.0;
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
            double totalFare = invoice.CalculateTotalFare(rides);
            Assert.AreEqual(totalFare, 130.0);
        }
        [Test]
        public void GivenMultipleRide_WhenCalculated_ShouldReturnInvoice()
        {
            Ride[] rides = {
                new Ride(2.0,25.0),
                new Ride(3.0,55.0)
            };
            Invoice summary = new Invoice();
            summary.totalRides = 2;
            summary.totalFare = 130.0;
            summary.averageFare = 65.0;
            Invoice details = invoice.GenerateInvoice(rides);
            Assert.AreEqual(details.averageFare, summary.averageFare);
        }

        [Test]
        public void GivenUserIDandRides_ShouldAddRidesToRepository()
        {
            string userId= "jan12";
            Ride[] rides = {
                new Ride(2.0,25.0),
                new Ride(3.0,55.0)
            };
            Invoice summary = new Invoice();
            summary.totalRides = 2;
            summary.totalFare = 130.0;
            summary.averageFare = 65.0;
            RideRepository repository = new RideRepository();
            repository.AddRides(userId, rides);
            Ride[] ride = repository.GetRides(userId);
            Invoice details = invoice.GenerateInvoice(ride);
            Assert.AreEqual(details.totalRides, rides.Length);
        }
        
    }
}