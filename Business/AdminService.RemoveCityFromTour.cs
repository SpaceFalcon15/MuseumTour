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
        public void RemoveCityFromTour(Guid tourId, Guid cityId)
        {
            // Find the tour
            MuseumTour? tour = null;
            foreach (var t in _doc.Tours)
            {
                if (t.Id == tourId)
                {
                    tour = t;
                    break;
                }
            }

            if (tour == null)
                throw new ApplicationException("Tour not found.");

            // Find the city in the tour
            City? cityToRemove = null;
            foreach (var city in tour.Cities)
            {
                if (city.Id == cityId)
                {
                    cityToRemove = city;
                    break;
                }
            }

            if (cityToRemove == null)
                throw new ApplicationException("City not found in the tour.");

            // Remove the city which removes museums and visits within
            tour.Cities.Remove(cityToRemove);

            // Save changes
            _storage.Save(_doc);
        }
    }
}
