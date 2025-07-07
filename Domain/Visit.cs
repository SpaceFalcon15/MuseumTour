using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Domain
{
    public class Visit
    {
        [XmlAttribute("id")] // XML attribute for the visit ID.
        public Guid Id { get; set; } = Guid.NewGuid(); // Generates a new ID for each Visit instance.

        [XmlAttribute("memberId")] // XML attribute for the member ID.
        public Guid MemberId { get; set; } // ID of the museum visited.

        [XmlAttribute("date")] // XML attribute for the visit date.
        public DateTime Date { get; set; } // Date of the visit.

        [XmlAttribute("isPaid")] // XML attribute for the payment status.
        public bool IsPaid { get; set; } = false; // Indicates whether the visit has been paid for, initialized to false.
    }
}
