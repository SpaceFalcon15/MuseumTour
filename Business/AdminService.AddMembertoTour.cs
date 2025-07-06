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
    }
}
