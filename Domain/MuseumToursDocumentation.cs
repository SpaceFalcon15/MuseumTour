using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Domain
{
    [XmlRoot("MuseumTours")]
    public class MuseumToursDocumentation
    {
        [XmlElement("Tour")]
        public List<MuseumTour> Tours { get; set; } = new List<MuseumTour>();
    }
}
