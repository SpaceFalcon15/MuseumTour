using DataStorage;
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
        private readonly XmlStorage _storage;
        private readonly MuseumToursDocumentation _doc;

        public AdminService(XmlStorage storage)
        {
            _storage = storage;
            _doc = _storage.Load(); // Load existing data or create a new instance if the file does not exist.
        }
        public List<MuseumTour> GetTours()
        {
            return _doc.Tours; // Return the list of tours from the documentation.
        }
    }
}
