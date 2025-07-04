﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Domain
{
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
        public DateTime Date { get; set; } // Date of the visit.
    }
}
