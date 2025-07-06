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
        public void RemoveTour(Guid tourId)
        {
            MuseumTour? tour = null;
            foreach (var t in _doc.Tours)
            {
                if (t.Id == tourId) { tour = t; break; }
            }
            if (tour == null)
                throw new ApplicationException("Tour not found.");

            _doc.Tours.Remove(tour);
            _storage.Save(_doc);
        }
    }
}
