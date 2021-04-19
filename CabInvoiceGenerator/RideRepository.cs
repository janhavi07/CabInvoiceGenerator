using System;
using System.Collections.Generic;

namespace CabInvoiceTesting
{
    public class RideRepository
    {
        Dictionary<string, List<Ride>> data = new Dictionary<string, List<Ride>>();
        List<Ride> rideList = new List<Ride>();

        /// <summary>
        /// Add the rides making a key value pair of user as key and rides as values
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="rides"></param>
        public void AddRides(string userId, Ride[] rides)
        {
            if (userId == null)
                throw new CustomException("User is null", CustomException.ExceptionType.NULLVALUE);
            if (!(data.ContainsKey(userId)))
            {
                rideList.Clear();
                rideList.AddRange(rides);
                data.Add(userId, rideList);
            }
            else
                rideList.AddRange(rides);
        }
        /// <summary>
        /// returns the array of rides when user is given
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Ride[] GetRides(string userId)
        {
            return data[userId].ToArray();
        }
    }
}