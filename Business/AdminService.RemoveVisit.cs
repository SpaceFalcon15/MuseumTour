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
        public void RemoveVisit(Guid tourId, Guid cityId, Guid museumId, Guid memberId, DateTime visitDate) // Method to remove a visit from a specific museum in a city of a tour by their IDs and visit date.
        {

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
                throw new ApplicationException("Tour not found.");
            }
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
                throw new ApplicationException("City not found in the tour.");
            }
            Museum? museum = null;
            foreach (var m in city.Museums) // Iterate through the list of museums in the city.
            {
                if (m.Id == museumId)
                {
                    museum = m; // Find the museum by ID.
                    break;
                }
            }
            if (museum == null)
            {
                throw new ApplicationException("Museum not found in the city.");
            }

            Visit? visitToRemove = null;
            foreach (var v in museum.Visits) // Iterate through the list of visits in the museum.
            {
                if (v.MemberId == memberId && v.Date.Date == visitDate.Date)
                {
                    visitToRemove = v; // Find the visit by member ID and date.
                    break;
                }
            }

            if (visitToRemove == null) // Check if the visit was found.
            {
                throw new ApplicationException("Visit not found for this member on that date.");
            }

            museum.Visits.Remove(visitToRemove); // Remove the visit from the museum's list of visits.
            _storage.Save(_doc); // Save the updated documentation back to the XML file.
        }
    }
}
