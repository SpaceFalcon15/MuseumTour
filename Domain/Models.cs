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
    public class Museum
    {
        [XmlAttribute("id")]
        public Guid Id { get; set; } = Guid.NewGuid(); // Generates a new ID for each Museum instance.
        [XmlAttribute("name")]
        public string Name { get; set; } = string.Empty; // Name of the museum, initialized to an empty string.
        [XmlAttribute("cost")]
        public decimal Cost { get; set; } // Cost of visiting the museum.
    }
    public class Member
    {
        [XmlAttribute("id")]
        public Guid Id { get; set; } = Guid.NewGuid(); // Generates a new ID for each Member instance.
        [XmlAttribute("name")]
        public string Name { get; set; } = string.Empty; // Name of the member.
        [XmlAttribute("bookingNumber")]
        public string BookingNumber { get; set; } = string.Empty; // Booking number for the member.
    }
    public class Visit
    {
        [XmlAttribute("id")]
        public Guid Id { get; set; } = Guid.NewGuid(); // Generates a new ID for each Visit instance.
        [XmlAttribute("memberId")]
        public Guid MemberId { get; set; } // ID of the member who made the visit.
        [XmlAttribute("cityId")]
        public Guid CityId { get; set; } // ID of the city where the visit took place.
        [XmlAttribute("museumId")]
        public Guid MuseumId { get; set; } // ID of the museum visited.
        [XmlAttribute("date")]
        public DateOnly Date { get; set; } // Date of the visit.
    }
}
