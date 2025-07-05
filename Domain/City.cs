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
        [XmlAttribute("id")]
        public Guid Id { get; set; } = Guid.NewGuid(); // Generates a new ID for each City instance.
        [XmlAttribute("name")]
        public string Name { get; set; } = string.Empty; // Name of the city, initialized to an empty string.
        [XmlAttribute("start")]
        public DateOnly StartDate { get; set; } // Start date of the tour in the city, using DateOnly to represent a date without time.
        [XmlAttribute("end")]
        public DateOnly EndDate { get; set; } // End date of the tour in the city, using DateOnly to represent a date without time.
        [XmlArray("Museums"), XmlArrayItem("Museum")]
        public List<Museum> Museums { get; set; } = new(); // List of museums in the city.

    }
}
