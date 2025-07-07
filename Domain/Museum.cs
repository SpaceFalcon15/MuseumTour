using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Domain
{
    public class Museum
    {
        [XmlAttribute("id")] // XML attribute for the museum ID.
        public Guid Id { get; set; } = Guid.NewGuid(); // Generates a new ID for each Museum instance.

        [XmlAttribute("name")] // XML attribute for the museum name.
        public string Name { get; set; } = string.Empty; // Name of the museum, initialized to an empty string.

        [XmlAttribute("cost")] // XML attribute for the cost of visiting the museum.
        public double Cost { get; set; } // Cost of visiting the museum.

        [XmlArray("Visits"), XmlArrayItem("Visit")] // XML array for the list of visits to the museum.
        public List<Visit> Visits { get; set; } = new(); // List of visits to the museum, initialized to an empty list.
    }   
}
