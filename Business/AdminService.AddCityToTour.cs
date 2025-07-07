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
        public City AddCityToTour(Guid tourId, string cityName, DateTime start, DateTime end) // Method to add a city to a specific tour by its ID.
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
                throw new ApplicationException("Tour not found"); // Throw an exception if the tour does not exist.
            }

            bool cityExists = false;
            foreach (var c in tour.Cities) // Iterate through the list of cities in the found tour.
            {
                if (c.Name.ToLower() == cityName.ToLower())
                {
                    cityExists = true; // Check if the city already exists in the tour.
                    break;
                }
            }
            if (cityExists) // If the city already exists in the tour, throw an exception.
            {
                throw new ApplicationException($"{cityName} already exists in the tour."); // Throw an exception if the city already exists.
            }

            if (start > end) // Validate the start and end dates of the city.
            { 
                throw new ApplicationException("The start date must be before the end date."); // Validate the start and end dates.
            }

            var city = new City // Create a new City instance with the provided parameters.
            {
                Name = cityName,
                StartDate = start,
                EndDate = end
            };

            tour.Cities.Add(city); // Add the new city to the tour's list of cities.
            _storage.Save(_doc); // Save the updated documentation back to the XML file.
            return city; // Return the newly created city.
        }
    }
}
