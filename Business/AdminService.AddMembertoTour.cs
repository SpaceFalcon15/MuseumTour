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
        public Member AddMemberToTour(Guid tourId, string memberName, string bookingNumber) // Method to add a member to a specific tour by its ID.
        {
            //FInd the tour
            MuseumTour? tour = null;
            foreach (var t in _doc.Tours) // Iterate through the list of tours in the documentation.
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
            if (string.IsNullOrWhiteSpace(memberName)) // Check if the member name is empty or consists only of whitespace characters.
            {
                throw new ApplicationException("Member name cannot be empty."); // Validate the member name.
            }
            if (string.IsNullOrWhiteSpace(bookingNumber)) // Check if the booking number is empty or consists only of whitespace characters.
            {
                throw new ApplicationException("Booking number cannot be empty."); // Validate the booking number.
            }

            // Check booking number uniqueness across all tours
            foreach (var t in _doc.Tours) // Iterate through all tours in the documentation to ensure the booking number is unique.
            {
                foreach (var m in t.Members) // Iterate through the members of each tour.
                {
                    if (m.BookingNumber.ToLower() == bookingNumber.ToLower()) // Check if the booking number matches any existing member's booking number, ignoring case.
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
    }
}
