using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Domain
{
    public class City
    {
        [XmlAttribute("id")] // XML attribute for the city ID.
        public Guid Id { get; set; } = Guid.NewGuid(); // Generates a new ID for each City instance.
        [XmlAttribute("name")] // XML attribute for the city name.
        public string Name { get; set; } = string.Empty; // Name of the city, initialized to an empty string.
        [XmlAttribute("start")] // XML attribute for the start date of the tour in the city.
        public DateTime StartDate { get; set; } // Start date of the tour in the city.
        [XmlAttribute("end")] // XML attribute for the end date of the tour in the city.
        public DateTime EndDate { get; set; } // End date of the tour in the city.
        [XmlArray("Museums"), XmlArrayItem("Museum")] // XML array for the list of museums in the city.
        public List<Museum> Museums { get; set; } = new(); // List of museums in the city.

    }
}
