using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public partial class AdminService
    {
        public void AddVisit(Guid tourId, Guid cityId, Guid museumId, Guid memberId, DateTime visitDate)
        {
            // Find the tour
            MuseumTour? tour = null;
            foreach (var t in _doc.Tours) // Iterate through the list of tours in the documentation.
            {
                if (t.Id == tourId)
                {
                    tour = t; // Find the tour by ID.
                    break;
                }
            }
            if (tour == null) // Check if the tour was found.
            {
                throw new ApplicationException("Tour not found"); // Throw an exception if the tour does not exist.
            }
            // Find the city
            City? city = null;
            foreach (var c in tour.Cities) // Iterate through the list of cities in the found tour.
            {
                if (c.Id == cityId)
                {
                    city = c; // Find the city by ID.
                    break;
                }
            }
            if (city == null) // Check if the city was found.
            {
                throw new ApplicationException("City not found in the tour"); // Throw an exception if the city does not exist.
            }
            if (visitDate < city.StartDate || visitDate > city.EndDate) // Validate the visit date against the city's date range.
                throw new ApplicationException("Visit date is outside the city's date range.");
            // Find the museum
            Museum? museum = null;
            foreach (var m in city.Museums) // Iterate through the list of museums in the city.
            {
                if (m.Id == museumId)
                {
                    museum = m; // Find the museum by ID.
                    break;
                }
            }
            if (museum == null) // Check if the museum was found.
            {
                throw new ApplicationException("Museum not found in the city"); // Throw an exception if the museum does not exist.
            }
            // Find the member
            Member? member = null;
            foreach (var m in tour.Members) // Iterate through the list of members in the tour.
            {
                if (m.Id == memberId)
                {
                    member = m; // Find the member by ID.
                    break;
                }
            }
            if (member == null) // Check if the member was found.
            {
                throw new ApplicationException("Member not found in the tour"); // Throw an exception if the member does not exist.
            }

           
            foreach (var v in museum.Visits) // Iterate through the visits in the museum to check for existing visits by the member on the same date.
            {
                if (v.MemberId == member.Id && v.Date.Date == visitDate.Date) //.Date.Date gives just the date part not including the time
                    throw new ApplicationException("Member already has a visit booked on this date.");
            }

            //Counts how many visits this member already has
            int visitCount = 0;
            foreach (var c in tour.Cities) // Iterate through the cities in the tour to count the member's visits.
            {
                foreach (var m in c.Museums) // Iterate through the museums in each city.
                {
                    foreach (var v in m.Visits) // Iterate through the visits in each museum.
                    {
                        if (v.MemberId == memberId)
                            visitCount++;
                    }
                }
            }

            //Add visit
            bool isPaid = visitCount >= 2; // If the member has 2 or more visits, they are considered paid.
            var visit = new Visit
            {
                MemberId = memberId,
                Date = visitDate,
                IsPaid = isPaid
            };

            museum.Visits.Add(visit); // Add visit to museum's visits list.
            _storage.Save(_doc); // Save changes to storage.

            if (isPaid) // If the visit is paid, print a message indicating that.
            {
                Console.WriteLine("This visit has been marked as paid");
            }
            else
            {
                Console.WriteLine("This visit does not require payment.");
            }
        }
    }
}
