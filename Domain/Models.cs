using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Domain
{
    [XmlRoot("MuseumTours")]
    public class MuseumToursDocumentation
    {
        [XmlElement("Tour")]
        public List<MuseumTour> Tours { get; set; } = new List<MuseumTour>(); // List of MuseumTour instances, representing multiple tours in the system.
    }

    public class MuseumTour
    {
        [XmlAttribute("id")]
        public Guid Id { get; set; } = Guid.NewGuid(); // Generates a new ID for each MuseumTour instance using GUID to make it almost impossible to have a duplicate ID.
        [XmlAttribute("name")]
        public string Name { get; set; } = string.Empty; // The name of the tour, which can be set to an empty string by default.

        [XmlArray("Cities"), XmlArrayItem("City")]
        public List<City> Cities { get; set; } = new(); // List of cities included in the tour.

        [XmlArray("Members"), XmlArrayItem("Member")]
        public List<Member> Members { get; set; } = new(); // List of members associated with the tour.

        [XmlArray("Visits"), XmlArrayItem("Visit")]
        public List<Visit> Visits { get; set; } = new(); // List of visits associated with the tour.
    }
    public class City
    {
        [XmlAttribute("id")]
        public Guid Id { get; set; } = Guid.NewGuid(); // Generates a new ID for each City instance.
        [XmlAttribute("name")]
        public string Name { get; set; } = string.Empty; //The name of the city.
        [XmlElement("startDate")]
        public DateOnly StartDate { get; set; } // The start date of the tour in the city.
        [XmlElement("endDate")]
        public DateOnly EndDate { get; set; } // The end date of the tour in the city.
        [XmlArray("Musums"), XmlArrayItem("Museum")]
        public List<Museum> Museums { get; set; } = new(); // List of museums in the city.

    }
    public class Museum
    {
        [XmlAttribute("id")]
        public Guid Id { get; set; } = Guid.NewGuid(); // Generates a new ID for each Museum instance.
        [XmlAttribute("name")]
        public string Name { get; set; } = string.Empty; // The name of the museum.
        [XmlElement("cost")]
        public decimal Cost { get; set; } // The cost of visiting the museum.
    }
    public class Member
    {
        [XmlAttribute("id")]
        public Guid Id { get; set; } = Guid.NewGuid(); // Generates a new ID for each Member instance.
        [XmlAttribute("name")]
        public string Name { get; set; } = string.Empty; // The name of the member.
        [XmlElement("BookingNumber")]
        public string BookingNumber { get; set; } = string.Empty; // The booking number for the member.

    }
    public class Visit
    {
        [XmlAttribute("id")]
        public Guid Id { get; set; } = Guid.NewGuid(); // Generates a new ID for each Visit instance.
        [XmlAttribute("MemberId")]
        public Guid MemberId { get; set; } // Reference to the Member visiting.
        [XmlElement("CityId")]
        public Guid CityId { get; set; } // Reference to the City being visited.
        [XmlElement("MuseumId")]
        public Guid MuseumId { get; set; } // Reference to the Museum visiting.
        [XmlElement("VisitDate")]
        public DateOnly VisitDate { get; set; }  // The date of the visit.
    }
}
