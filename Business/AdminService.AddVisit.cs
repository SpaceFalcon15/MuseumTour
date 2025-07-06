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
            foreach (var t in _doc.Tours)
            {
                if (t.Id == tourId)
                {
                    tour = t; // Find the tour by ID.
                    break;
                }
            }
            if (tour == null)
            {
                throw new ApplicationException("Tour not found"); // Throw an exception if the tour does not exist.
            }
            // Find the city
            City? city = null;
            foreach (var c in tour.Cities)
            {
                if (c.Id == cityId)
                {
                    city = c; // Find the city by ID.
                    break;
                }
            }
            if (city == null)
            {
                throw new ApplicationException("City not found in the tour"); // Throw an exception if the city does not exist.
            }
            if (visitDate < city.StartDate || visitDate > city.EndDate)
                throw new ApplicationException("Visit date is outside the city's date range.");
            // Find the museum
            Museum? museum = null;
            foreach (var m in city.Museums)
            {
                if (m.Id == museumId)
                {
                    museum = m; // Find the museum by ID.
                    break;
                }
            }
            if (museum == null)
            {
                throw new ApplicationException("Museum not found in the city"); // Throw an exception if the museum does not exist.
            }
            // Find the member
            Member? member = null;
            foreach (var m in tour.Members)
            {
                if (m.Id == memberId)
                {
                    member = m; // Find the member by ID.
                    break;
                }
            }
            if (member == null)
            {
                throw new ApplicationException("Member not found in the tour"); // Throw an exception if the member does not exist.
            }

           
            foreach (var v in museum.Visits)
            {
                if (v.MemberId == member.Id && v.Date.Date == visitDate.Date) //.Date.Date gives just the date part not including the time
                    throw new ApplicationException("Member already has a visit booked on this date.");
            }

            //Counts how many visits this member already has
            int visitCount = 0;
            foreach (var c in tour.Cities)
            {
                foreach (var m in c.Museums)
                {
                    foreach (var v in m.Visits)
                    {
                        if (v.MemberId == memberId)
                            visitCount++;
                    }
                }
            }

            //Add visit
            bool isPaid = visitCount >= 2;
            var visit = new Visit
            {
                MemberId = memberId,
                Date = visitDate,
                IsPaid = isPaid
            };

            museum.Visits.Add(visit); // Add visit to museum's visits list.
            _storage.Save(_doc); // Save changes to storage.
        }
    }
}
