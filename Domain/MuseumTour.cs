using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Domain
{
    public class MuseumTour
    {
        [XmlAttribute("id")] // XML attribute for the tour ID.
        public Guid Id { get; set; } = Guid.NewGuid(); // Generates a new ID for each MuseumTour instance using GUID to make it almost impossible to have a duplicate ID.

        [XmlAttribute("name")] // XML attribute for the tour name.
        public string Name { get; set; } = string.Empty; // Name of the tour, initialized to an empty string.

        [XmlArray("Cities"), XmlArrayItem("City")] // XML array for the list of cities included in the tour.
        public List<City> Cities { get; set; } = new(); // List of cities included in the tour, initialized to an empty list.

        [XmlArray("Members"), XmlArrayItem("Member")] // XML array for the list of members participating in the tour.
        public List<Member> Members { get; set; } = new(); // List of members participating in the tour, initialized to an empty list.

        [XmlArray("Visits"), XmlArrayItem("Visit")] // XML array for the list of visits made during the tour.
        public List<Visit> Visits { get; set; } = new(); // List of visits made during the tour, initialized to an empty list.
    }  
}
