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
        public void RemoveVisit(Guid tourId, Guid cityId, Guid museumId, Guid memberId, DateTime visitDate)
        {
            
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
                throw new ApplicationException("Tour not found.");

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
                throw new ApplicationException("City not found in the tour.");

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
                throw new ApplicationException("Museum not found in the city.");

            // --- Find visit -----------------------------------------------------
            Visit? visitToRemove = null;
            foreach (var v in museum.Visits)
            {
                if (v.MemberId == memberId && v.Date.Date == visitDate.Date)
                {
                    visitToRemove = v; // Find the visit by member ID and date.
                    break;
                }
            }

            if (visitToRemove == null)
                throw new ApplicationException("Visit not found for this member on that date.");

            // --- Remove and save ------------------------------------------------
            museum.Visits.Remove(visitToRemove);
            _storage.Save(_doc);
        }
    }
}
