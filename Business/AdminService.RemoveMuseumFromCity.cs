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
        public void RemoveMuseumFromCity(Guid tourId, Guid cityId, Guid museumId)
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
            {
                throw new ApplicationException("Tour not found"); // Throw an exception if the tour does not exist.
            }
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
            city.Museums.Remove(museum); // Remove the museum from the city's list of museums.
            _storage.Save(_doc); // Save the updated documentation back to the XML file.
        }
    }
}
