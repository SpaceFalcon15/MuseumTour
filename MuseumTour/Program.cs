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
                Console.WriteLine("\n=== Museum Tour Admin Menu ===");
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
                Console.WriteLine($" Tour created with ID: {tour.Id} and Name:{tour.Name}");
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine($" Error: {ex.Message}");
            }
        }

        static void RemoveTour(AdminService admin)
        {
            // TODO: Implement
        }

        static void AddCityToTour(AdminService admin)
        {
            // TODO: Implement
        }

        static void AddMuseumToCity(AdminService admin)
        {
            // TODO: Implement
        }

        static void AddMemberToTour(AdminService admin)
        {
            // TODO: Implement
        }

        static void AddVisit(AdminService admin)
        {
            // TODO: Implement
        }

        static void RemoveVisit(AdminService admin)
        {
            // TODO: Implement
        }

        static void RemoveCityFromTour(AdminService admin)
        {
            // TODO: Implement
        }

        static void RemoveMuseumFromCity(AdminService admin)
        {
            // TODO: Implement
        }

        static void RemoveMemberFromTour(AdminService admin)
        {
            // TODO: Implement
        }
    }
}
