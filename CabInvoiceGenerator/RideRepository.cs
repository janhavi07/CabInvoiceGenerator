using System;
using System.Collections.Generic;

namespace CabInvoiceTesting
{
    public class RideRepository
    {
        Dictionary<string, List<Ride>> data = new Dictionary<string, List<Ride>>();

        public void AddRides(string userId, Ride[] rides)
        {
            if (!(data.ContainsKey(userId)))
            {
                List<Ride> rideList = new List<Ride>();
                rideList.AddRange(rides);
                if (rideList.Contains(null))
                    throw new CustomException("Null Rides",CustomException.ExceptionType.NULLVALUE);
                data.Add(userId, rideList);
            }
        }

        public Ride[] GetRides(string userId)
        {
            return data[userId].ToArray();
        }
    }
}