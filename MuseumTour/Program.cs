using BusinessLogic;
using Domain;
using DataStorage;

namespace MuseumTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var storage = new XmlStorage("data.xml");
            var doc = storage.Load(); // returns a MuseumTourDocument
            var admin = new AdminService(doc, storage);

            while (true)
            {
                Console.WriteLine("Museum Tour Admin Menu");
                Console.WriteLine("1. Add tour");
                Console.WriteLine("2. Remove tour");
                Console.WriteLine("3. Add city to tour");
                Console.WriteLine("4. Add museum to city");
                Console.WriteLine("5. Add member to tour");
                Console.WriteLine("6. Add member visit");
                Console.WriteLine("7. Remove member visit");
                Console.WriteLine("8. Remove city");
                Console.WriteLine("9. Remove museum");
                Console.WriteLine("10. Remove member from tour");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");

                string? input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case "1":
                        AddTour(admin);
                        break;
                    case "2":
                        RemoveTour(admin);
                        break;
                    case "3":
                        AddCityToTour(admin);
                        break;
                    case "4":
                        AddMuseumToCity(admin);
                        break;
                    case "5":
                        AddMemberToTour(admin);
                        break;
                    case "6":
                        AddVisit(admin);
                        break;
                    case "7":
                        RemoveVisit(admin);
                        break;
                    case "8":
                        RemoveCityFromTour(admin);
                        break;
                    case "9":
                        RemoveMuseumFromCity(admin);
                        break;
                    case "10":
                        RemoveMemberFromTour(admin);
                        break;
                    case "0":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
        static void AddTour(AdminService admin)
        {
            Console.WriteLine("Add Tour");
            Console.Write("Enter tour name: ");
            string name = Console.ReadLine() ?? string.Empty;

            try
            {
                var tour = admin.AddTour(name);
                Console.WriteLine($" Tour created with ID: {tour.Id}\n Name: {tour.Name}");
                Console.WriteLine();
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine($" Error: {ex.Message}");
            }
        }

        static void RemoveTour(AdminService admin)
        {
            Console.WriteLine("Remove Tour");
            Guid tourId;
            while (true)
            {
                Console.Write("Enter the Tour ID to remove: ");
                if (Guid.TryParse(Console.ReadLine(), out tourId))
                    break;
                Console.WriteLine("Invalid Tour ID. Please try again.");
            }
            try
            {
                admin.RemoveTour(tourId);
                Console.WriteLine("Tour removed successfully.");
                Console.WriteLine();
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine($" Error: {ex.Message}");
            }
        }

        static void AddCityToTour(AdminService admin)
        {
            Console.WriteLine("Add City to Tour");

            Guid tourId;
            while (true)
            {
                Console.Write("Enter tour ID: ");
                if (Guid.TryParse(Console.ReadLine(), out tourId))
                    break;
                Console.WriteLine("Invalid tour ID. Please try again.");
            }

            string cityName;
            while (true)
            {
                Console.Write("Enter city name: ");
                cityName = Console.ReadLine() ?? string.Empty;
                if (!string.IsNullOrWhiteSpace(cityName))
                    break;
                Console.WriteLine("City name cannot be empty.");
            }

            DateTime startDate;
            while (true)
            {
                Console.Write("Enter start date (yyyy-MM-dd): ");
                if (DateTime.TryParse(Console.ReadLine(), out startDate))
                    break;
                Console.WriteLine("Invalid start date.");
            }

            DateTime endDate;
            while (true)
            {
                Console.Write("Enter end date (yyyy-MM-dd): ");
                if (DateTime.TryParse(Console.ReadLine(), out endDate))
                    break;
                Console.WriteLine("Invalid end date.");
            }

            try
            {
                var city = admin.AddCityToTour(tourId, cityName, startDate, endDate);
                Console.WriteLine($"City added:\n ID: {city.Id},\n Name: {city.Name},\n Start Date: {city.StartDate},\n End Date: {city.EndDate}");
                Console.WriteLine();
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void AddMuseumToCity(AdminService admin)
        {
            Console.WriteLine("Add Museum to City");

            Guid tourId;
            while (true)
            {
                Console.Write("Enter tour ID: ");
                if (Guid.TryParse(Console.ReadLine(), out tourId))
                    break;
                Console.WriteLine("Invalid tour ID. Please try again.");
            }

            Guid cityId;
            while (true)
            {
                Console.Write("Enter city ID: ");
                if (Guid.TryParse(Console.ReadLine(), out cityId))
                    break;
                Console.WriteLine("Invalid city ID. Please try again.");
            }

            string museumName;
            while (true)
            {
                Console.Write("Enter museum name: ");
                museumName = Console.ReadLine() ?? string.Empty;
                if (!string.IsNullOrWhiteSpace(museumName))
                    break;
                Console.WriteLine("Museum name cannot be empty.");
            }

            double cost;
            while (true)
            {
                Console.Write("Enter museum cost: ");
                if (double.TryParse(Console.ReadLine(), out cost) && cost >= 0)
                    break;
                Console.WriteLine("Invalid cost. Please enter a non-negative number.");
            }

            try
            {
                var museum = admin.AddMuseumToCity(tourId, cityId, museumName, cost);
                Console.WriteLine($"Museum added:\n ID: {museum.Id},\n Name: {museum.Name},\n Cost: {museum.Cost}");
                Console.WriteLine();
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void AddMemberToTour(AdminService admin)
        {
            Console.WriteLine("Add Member to Tour");

            Guid tourId;
            while (true)
            {
                Console.Write("Enter tour ID: ");
                if (Guid.TryParse(Console.ReadLine(), out tourId))
                    break;
                Console.WriteLine("Invalid tour ID. Please try again.");
            }

            string memberName;
            while (true)
            {
                Console.Write("Enter member name: ");
                memberName = Console.ReadLine() ?? string.Empty;
                if (!string.IsNullOrWhiteSpace(memberName))
                    break;
                Console.WriteLine("Member name cannot be empty.");
            }

            string bookingNumber;
            while (true)
            {
                Console.Write("Enter booking number: ");
                bookingNumber = Console.ReadLine() ?? string.Empty;
                if (!string.IsNullOrWhiteSpace(bookingNumber))
                    break;
                Console.WriteLine("Booking number cannot be empty.");
            }

            try
            {
                var member = admin.AddMemberToTour(tourId, memberName, bookingNumber);
                Console.WriteLine($"Member added:\n ID: {member.Id},\n Name: {member.Name},\n Booking Number: {member.BookingNumber}");
                Console.WriteLine();
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void AddVisit(AdminService admin)
        {
            Console.WriteLine("Add Member Visit");

            Guid tourId;
            while (true)
            {
                Console.Write("Enter tour ID: ");
                if (Guid.TryParse(Console.ReadLine(), out tourId))
                    break;
                Console.WriteLine("Invalid tour ID. Please try again.");
            }

            Guid cityId;
            while (true)
            {
                Console.Write("Enter city ID: ");
                if (Guid.TryParse(Console.ReadLine(), out cityId))
                    break;
                Console.WriteLine("Invalid city ID. Please try again.");
            }

            Guid museumId;
            while (true)
            {
                Console.Write("Enter museum ID: ");
                if (Guid.TryParse(Console.ReadLine(), out museumId))
                    break;
                Console.WriteLine("Invalid museum ID. Please try again.");
            }

            Guid memberId;
            while (true)
            {
                Console.Write("Enter member ID: ");
                if (Guid.TryParse(Console.ReadLine(), out memberId))
                    break;
                Console.WriteLine("Invalid member ID. Please try again.");
            }

            DateTime visitDate;
            while (true)
            {
                Console.Write("Enter visit date (yyyy-MM-dd): ");
                if (DateTime.TryParse(Console.ReadLine(), out visitDate))
                    break;
                Console.WriteLine("Invalid date format. Please try again.");
            }

            try
            {
                admin.AddVisit(tourId, cityId, museumId, memberId, visitDate);
                Console.WriteLine("Visit booked successfully.");
                Console.WriteLine();
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void RemoveVisit(AdminService admin)
        {
            Console.WriteLine("Remove Member Visit");

            Guid tourId;
            while (true)
            {
                Console.Write("Enter tour ID: ");
                if (Guid.TryParse(Console.ReadLine(), out tourId))
                    break;
                Console.WriteLine("Invalid tour ID. Please try again.");
            }

            Guid cityId;
            while (true)
            {
                Console.Write("Enter city ID: ");
                if (Guid.TryParse(Console.ReadLine(), out cityId))
                    break;
                Console.WriteLine("Invalid city ID. Please try again.");
            }

            Guid museumId;
            while (true)
            {
                Console.Write("Enter museum ID: ");
                if (Guid.TryParse(Console.ReadLine(), out museumId))
                    break;
                Console.WriteLine("Invalid museum ID. Please try again.");
            }

            Guid memberId;
            while (true)
            {
                Console.Write("Enter member ID: ");
                if (Guid.TryParse(Console.ReadLine(), out memberId))
                    break;
                Console.WriteLine("Invalid member ID. Please try again.");
            }

            DateTime visitDate;
            while (true)
            {
                Console.Write("Enter visit date (yyyy-MM-dd): ");
                if (DateTime.TryParse(Console.ReadLine(), out visitDate))
                    break;
                Console.WriteLine("Invalid date format. Please try again.");
            }

            try
            {
                admin.RemoveVisit(tourId, cityId, museumId, memberId, visitDate);
                Console.WriteLine("Visit removed successfully.");
                Console.WriteLine();
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void RemoveCityFromTour(AdminService admin)
        {
            Console.WriteLine("Remove City from Tour");

            Guid tourId;
            while (true)
            {
                Console.Write("Enter tour ID: ");
                if (Guid.TryParse(Console.ReadLine(), out tourId))
                    break;
                Console.WriteLine("Invalid tour ID. Please try again.");
            }

            Guid cityId;
            while (true)
            {
                Console.Write("Enter city ID: ");
                if (Guid.TryParse(Console.ReadLine(), out cityId))
                    break;
                Console.WriteLine("Invalid city ID. Please try again.");
            }

            try
            {
                admin.RemoveCityFromTour(tourId, cityId);
                Console.WriteLine("City removed from tour successfully.");
                Console.WriteLine();
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void RemoveMuseumFromCity(AdminService admin)
        {
            Console.WriteLine("Remove Museum from City");

            Guid tourId;
            while (true)
            {
                Console.Write("Enter tour ID: ");
                if (Guid.TryParse(Console.ReadLine(), out tourId))
                    break;
                Console.WriteLine("Invalid tour ID. Please try again.");
            }

            Guid cityId;
            while (true)
            {
                Console.Write("Enter city ID: ");
                if (Guid.TryParse(Console.ReadLine(), out cityId))
                    break;
                Console.WriteLine("Invalid city ID. Please try again.");
            }

            Guid museumId;
            while (true)
            {
                Console.Write("Enter museum ID: ");
                if (Guid.TryParse(Console.ReadLine(), out museumId))
                    break;
                Console.WriteLine("Invalid museum ID. Please try again.");
            }

            try
            {
                admin.RemoveMuseumFromCity(tourId, cityId, museumId);
                Console.WriteLine("Museum removed from city successfully.");
                Console.WriteLine();
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void RemoveMemberFromTour(AdminService admin)
        {
            Console.WriteLine("Remove Member from Tour");

            Guid tourId;
            while (true)
            {
                Console.Write("Enter tour ID: ");
                if (Guid.TryParse(Console.ReadLine(), out tourId))
                    break;
                Console.WriteLine("Invalid tour ID. Please try again.");
            }

            Guid memberId;
            while (true)
            {
                Console.Write("Enter member ID: ");
                if (Guid.TryParse(Console.ReadLine(), out memberId))
                    break;
                Console.WriteLine("Invalid member ID. Please try again.");
            }

            try
            {
                admin.RemoveMemberFromTour(tourId, memberId);
                Console.WriteLine("Member removed successfully.");
                Console.WriteLine();
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
