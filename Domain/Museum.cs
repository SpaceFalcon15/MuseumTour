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
        [XmlAttribute("id")]
        public Guid Id { get; set; } = Guid.NewGuid(); // Generates a new ID for each Museum instance.
        [XmlAttribute("name")]
        public string Name { get; set; } = string.Empty; // Name of the museum, initialized to an empty string.
        [XmlAttribute("cost")]
        public double Cost { get; set; } // Cost of visiting the museum.
    }   
}
