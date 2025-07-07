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
        public void RemoveMemberFromTour(Guid tourId, Guid memberId) // Method to remove a member from a specific tour by their IDs.
        {
            // Find the tour
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
            // Find the member
            Member? member = null;
            foreach (var m in tour.Members) // Iterate through the list of members in the tour.
            {
                if (m.Id == memberId)
                {
                    member = m; // Find the member by ID.
                    break;
                }
            }
            if (member == null) // Check if the member was found.
            {
                throw new ApplicationException("Member not found in the tour"); // Throw an exception if the member does not exist.
            }
            tour.Members.Remove(member); // Remove the member from the tour's list of members.
            _storage.Save(_doc); // Save the updated documentation back to the XML file.
        }
    }
}
