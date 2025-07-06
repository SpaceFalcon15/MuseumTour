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
    }
}
