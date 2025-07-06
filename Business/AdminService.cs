using DataStorage;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class AdminService
    {
        private readonly XmlStorage _storage;
        private readonly MuseumToursDocumentation _doc;

        public AdminService(XmlStorage storage)
        {
            _storage = storage;
            _doc = _storage.Load(); // Load existing data or create a new instance if the file does not exist.
        }

        public MuseumTour AddTour(string name)
        {
            var tour = new MuseumTour
            {
                Name = name
            };
            _doc.Tours.Add(tour); // Add the new tour to the list of tours in the documentation.
            _storage.Save(_doc); // Save the updated documentation back to the XML file.
            return tour; // Return the newly created tour.
        }

        public City AddCityToTour(Guid tourId, string cityName, DateTime start, DateTime end)
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

            bool cityExists = false;
            foreach (var c in tour.Cities)
            {
                if (c.Name.ToLower() == cityName.ToLower())
                {
                    cityExists = true; // Check if the city already exists in the tour.
                    break;
                }
            }
            if (cityExists)
            {
                throw new ApplicationException($"{cityName} already exists in the tour."); // Throw an exception if the city already exists.
            }

            if (start > end)
            {
                throw new ApplicationException("The start date must be before the end date."); // Validate the start and end dates.
            }

            var city = new City
            {
                Name = cityName,
                StartDate = start,
                EndDate = end
            };

            tour.Cities.Add(city); // Add the new city to the tour's list of cities.
            _storage.Save(_doc); // Save the updated documentation back to the XML file.
            return city; // Return the newly created city.
        }
        public Museum AddMuseumToCity (Guid tourId, Guid cityId, string museumName, double cost)
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
            if (string.IsNullOrWhiteSpace(museumName))
            {
                throw new ApplicationException("Museum name cannot be empty."); // Validate the museum name.
            }
            foreach (var exisiting in city.Museums)
            {
                if (exisiting.Name.ToLower() == museumName.ToLower())
                {
                    throw new ApplicationException($"{museumName} already exists in {city.Name}."); // Check if the museum already exists in the city.
                }
            }

            if (cost < 0)
            {
                throw new ApplicationException("Cost cannot be negative."); // Validate the cost of the museum. 
            }

            var museum = new Museum { Name = museumName, Cost = cost }; // Create a new museum instance with the provided name and cost.
            city.Museums.Add(museum); // Add the new museum to the city's list of museums.
            _storage.Save(_doc); // Save the updated documentation back to the XML file.
            return museum; // Return the newly created museum.
        }

        public void RemoveMuseumFromCIty(Guid tourId, Guid cityId, Guid museumId)
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

        public Member AddMemberToTour(Guid tourId, string memberName, string bookingNumber)
        {
            //FInd the tour
            MuseumTour? tour = null;
            foreach (var t in _doc.Tours)
            {
                if (t.Id == tourId)
                {
                    tour = t; // Find the tour by ID.
                    break;
                }
            }

            //Validate inputs
            if (tour == null)
            {
                throw new ApplicationException("Tour not found"); // Throw an exception if the tour does not exist.
            }
            if (string.IsNullOrWhiteSpace(memberName))
            {
                throw new ApplicationException("Member name cannot be empty."); // Validate the member name.
            }
            if (string.IsNullOrWhiteSpace(bookingNumber))
            {
                throw new ApplicationException("Booking number cannot be empty."); // Validate the booking number.
            }

            // Check booking number uniqueness across all tours
            foreach (var t in _doc.Tours)
            {
                foreach (var m in t.Members)
                {
                    if (m.BookingNumber.ToLower() == bookingNumber.ToLower())
                    {
                        throw new ApplicationException($"Booking numbers must be unique."); // Check if the booking number is already used by another member.
                    }
                }
            }

            //Create and add a new member to the tour.
            var member = new Member
            {
                Name = memberName,
                BookingNumber = bookingNumber
            };
            tour.Members.Add(member); // Add the new member to the tour's list of members.
            _storage.Save(_doc); // Save the updated documentation back to the XML file.
            return member; // Return the newly created member.
        }
        public void RemoveMemberFromTour(Guid tourId, Guid memberId)
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
            tour.Members.Remove(member); // Remove the member from the tour's list of members.
            _storage.Save(_doc); // Save the updated documentation back to the XML file.
        }
        public List<MuseumTour> GetTours()
        {
            return _doc.Tours; // Return the list of tours from the documentation.
        }
    }
}
