using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Domain
{
    public class Member
    {
        [XmlAttribute("id")] // XML attribute for the member ID.
        public Guid Id { get; set; } = Guid.NewGuid(); // Generates a new ID for each Member instance.

        [XmlAttribute("name")] // XML attribute for the member name.
        public string Name { get; set; } = string.Empty; // Name of the member.

        [XmlAttribute("bookingNumber")] // XML attribute for the booking number.
        public string BookingNumber { get; set; } = string.Empty; // Booking number for the member.
    }
}
