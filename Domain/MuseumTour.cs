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
        [XmlAttribute("id")]
        public Guid Id { get; set; } = Guid.NewGuid(); // Generates a new ID for each MuseumTour instance using GUID to make it almost impossible to have a duplicate ID.
        [XmlAttribute("name")]
        public string Name { get; set; } = string.Empty; // Name of the tour, initialized to an empty string.
        [XmlArray("Cities"), XmlArrayItem("City")]
        public List<City> Cities { get; set; } = new(); // List of cities included in the tour, initialized to an empty list.
        [XmlArray("Members"), XmlArrayItem("Member")]
        public List<Member> Members { get; set; } = new(); // List of members participating in the tour, initialized to an empty list.
        [XmlArray("Visits"), XmlArrayItem("Visit")]
        public List<Visit> Visits { get; set; } = new(); // List of visits made during the tour, initialized to an empty list.
    }  
}
