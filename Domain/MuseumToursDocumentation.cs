using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Domain
{
    [XmlRoot("MuseumTours")]
    public class MuseumToursDocumentation
    {
        [XmlElement("Tour")] // Specifies that the Tours property will be serialized as a collection of Tour elements in XML.
        public List<MuseumTour> Tours { get; set; } = new List<MuseumTour>(); // List of museum tours, initialized to an empty list.
    }
}
