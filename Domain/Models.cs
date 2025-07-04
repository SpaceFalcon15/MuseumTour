using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Domain
{
    [XmlRoot("MuseumTours")]
    public class MuseumTours
    {
        [XmlElement("Tour")]
        public List<MuseumTour> Tours { get; set; } = new List<MuseumTour>();
    }

    public class MuseumTour
    {
        [XmlAttribute("id")]
        public Guid Id { get; set; } = Guid.NewGuid(); // Generates a new ID for each MuseumTour instance using GUID to make it almost impossible to have a duplicate ID.
        [XmlAttribute("name")]
        public string Name { get; set; } = string.Empty; //stops error when null entry is added

        [XmlArray("Cities"), XmlArrayItem("City")]
        public List<City> Cities { get; set; } = new();

        [XmlArray("Members"), XmlArrayItem("Member")]
        public List<Member> Members { get; set; } = new();

        [XmlArray("Visits"), XmlArrayItem("Visit")]
    }
    public class City
    {
        [XmlAttribute("id")]
        public Guid Id { get; set; } = Guid.NewGuid(); // Generates a new ID for each City instance.
        [XmlAttribute("name")]
        public string Name { get; set; } = string.Empty;
        [XmlElement("Description")]
        public string Description { get; set; } = string.Empty;
        [XmlElement("Latitude")]
        public double Latitude { get; set; }
        [XmlElement("Longitude")]
        public double Longitude { get; set; }

    }
    public class Member
    {
        [XmlAttribute("id")]
        public Guid Id { get; set; } = Guid.NewGuid(); // Generates a new ID for each Member instance.
        [XmlAttribute("name")]
        public string Name { get; set; } = string.Empty;

    }
}
