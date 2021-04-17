using System;
using System.Collections.Generic;

namespace CabInvoiceTesting
{
    public class RideRepository
    {
        Dictionary<string, List<Ride>> data = new Dictionary<string, List<Ride>>();
        List<Ride> rideList = new List<Ride>();

        public void AddRides(string userId, Ride[] rides)
        {
            if (userId == null)
                throw new CustomException("User is null", CustomException.ExceptionType.NULLVALUE);
            if (!(data.ContainsKey(userId)))
            {
                rideList.Clear();
                //List<Ride> tempList = new List<Ride>();
                rideList.AddRange(rides);
                data.Add(userId, rideList);
            }
            else
            {
                rideList.AddRange(rides);
                
            }
        }

        public Ride[] GetRides(string userId)
        {
            return data[userId].ToArray();
        }
    }
}