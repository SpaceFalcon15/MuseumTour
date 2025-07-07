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
        public Museum AddMuseumToCity(Guid tourId, Guid cityId, string museumName, double cost) // Method to add a museum to a specific city in a tour by their IDs.
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
            if (string.IsNullOrWhiteSpace(museumName)) // Check if the museum name is empty or consists only of whitespace characters.
            {
                throw new ApplicationException("Museum name cannot be empty."); // Validate the museum name.
            }
            foreach (var exisiting in city.Museums) // Iterate through the list of existing museums in the city to check for duplicates.
            {
                if (exisiting.Name.ToLower() == museumName.ToLower()) // Check if the museum name already exists in the city, ignoring case.
                {
                    throw new ApplicationException($"{museumName} already exists in {city.Name}."); // Check if the museum already exists in the city.
                }
            }

            if (cost < 0) // Validate the cost of the museum.
            {
                throw new ApplicationException("Cost cannot be negative."); // Validate the cost of the museum. 
            }

            var museum = new Museum { Name = museumName, Cost = cost }; // Create a new museum instance with the provided name and cost.
            city.Museums.Add(museum); // Add the new museum to the city's list of museums.
            _storage.Save(_doc); // Save the updated documentation back to the XML file.
            return museum; // Return the newly created museum.
        }
    }
}
