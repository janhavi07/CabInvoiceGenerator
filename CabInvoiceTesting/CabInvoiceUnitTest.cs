using CabInvoiceGenerator;
using NUnit.Framework;

namespace CabInvoiceTesting
{
    public class Tests
    {
        InvoiceGenerator invoice = new InvoiceGenerator();
        RideRepository repository = new RideRepository();


        [Test]
        public void GivenDistanceAndTime_WhenCalculated_ShouldReturnTotalFare()
        {
            double distance = 2.0;// In kilometer
            double time = 5.0; // In minutes
            double fare = invoice.CalculateFare(Cab.NORMAL,distance, time);
            Assert.AreEqual(fare, 25.0);
        }

        [Test]
        public void GivenDistanceAndTime_WhenLessThanMinimumFarre_ShouldReturnMinumumFare()
        {
            double minimumFare = 5.0;
            double distance = 0.1;
            double time = 2.0;
            double fare = invoice.CalculateFare(Cab.NORMAL,distance, time);
            Assert.AreEqual(fare, minimumFare);
        }
        
        [Test]
        public void GivenMultipleRides_WhenCalculatedFare_ShouldReturnTotalFare()
        {
            Ride[] rides = {
                new Ride(Cab.NORMAL,2.0,25.0),
                new Ride(Cab.PREMINUM,3.0,55.0)
            };
            double ride1 = invoice.CalculateFare(Cab.NORMAL, 2.0, 25.0);
            double ride2 = invoice.CalculateFare(Cab.PREMINUM, 3.0, 55.0);
            Assert.AreEqual(ride1+ride2, 200.0);
        }
        
        [Test]
        public void GivenMultipleRide_WhenCalculated_ShouldReturnInvoice()
        {
            Ride[] rides = {
                new Ride(Cab.NORMAL,2.0,25.0),
                new Ride(Cab.NORMAL,3.0,55.0)
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
            string userId = "jan12";
            Ride[] rides = {
                new Ride(Cab.PREMINUM,2.0,25.0),
                new Ride(Cab.NORMAL,3.0,55.0)
            };
            repository.AddRides(userId, rides);
            Ride[] ride = repository.GetRides(userId);
            Invoice details = invoice.GenerateInvoice(ride);
            Assert.AreEqual(details.totalRides, rides.Length);
        }
        
        [Test]
        public void GivenOneUserAndMultipleRides_ShouldReturnTotalRides()
        {
            string userId = "jan12";
            Ride[] ride1 = {
                new Ride(Cab.PREMINUM,2.0,25.0),
                new Ride(Cab.PREMINUM,3.0,55.0)
            };
            Ride[] ride2 = {
                            new Ride(Cab.PREMINUM,3.0,30.0),
                            new Ride(Cab.PREMINUM,1.0,10.0)
            };
            repository.AddRides(userId, ride1);
            repository.AddRides(userId, ride2);
            Ride[] rides = repository.GetRides(userId);
            Invoice invoiceSummary = invoice.GenerateInvoice(rides);
            Assert.AreEqual(invoiceSummary.totalRides, 4);

        }
        

        [Test]
        public void GivenMultipleUsersAndMultipleRides_WhenCalculated_ShouldReturnProperRideCount()
        {
            string userId1 = "jan12";
            string userId2 = "pan23";
            Ride[] ride1 = {
                new Ride(Cab.PREMINUM,2.0,25.0),
                new Ride(Cab.NORMAL,3.0,55.0)
            };
            Ride[] ride2 = {
                            new Ride(Cab.PREMINUM,3.0,30.0),
                            new Ride(Cab.PREMINUM,1.0,10.0)
            };
            repository.AddRides(userId1, ride1);
            repository.AddRides(userId2, ride2);
            Ride[] rides = repository.GetRides(userId2);
            Invoice invoiceSummary = invoice.GenerateInvoice(rides);
            Assert.AreEqual(invoiceSummary.totalRides, 2);
        }
        
        [Test]
        public void GivenNullUservalue_WhenCalculated_ShouldThrowException()
        {
            try
            {
                string userId2 = null;
                Ride[] ride1 = {
                new Ride(Cab.NORMAL,2.0,25.0),
                new Ride(Cab.NORMAL,3.0,55.0)
            };
                repository.AddRides(userId2, ride1);
                repository.GetRides(userId2);
            }
            catch (CustomException exception)
            {
                Assert.AreEqual("User is null", exception.Message);
            }

        }
        
        [Test]
        public void GivenCabTypeAndRidedetails_WhenCalculated_ShouldRetunrInvoice()
        {
            string userId2 = "pan23";
            Ride[] ride1 = {
                new Ride(Cab.NORMAL, 2.0, 25.0),
                new Ride(Cab.NORMAL, 3.0, 55.0)
            };
            repository.AddRides(userId2, ride1);
            Ride[] rides = repository.GetRides(userId2);
            Invoice invoiceSummary = invoice.GenerateInvoice(rides);
            Assert.AreEqual(invoiceSummary.totalFare, 130.0);

        }
    }
}