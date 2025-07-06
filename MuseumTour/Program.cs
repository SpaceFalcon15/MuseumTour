using BusinessLogic;
using Domain;
using DataStorage;

namespace MuseumTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var tour = new Domain.MuseumTour { Name = "Sample Tour" };
            Console.WriteLine($"Tour Name: {tour.Id}");

            // Loads in existing data from XML file or creates a new one
            var storage = new DataStorage.XmlStorage("musuemtours.xml");

            var data = storage.Load(); // Load existing data or create a new instance if the file does not exist.
            //Add a new tour for testing purposes
            var Tour = new Domain.MuseumTour { Name = "Basic Tour" }; // Create a new tour instance with a name.
            data.Tours.Add(Tour); // Add the new tour to the list of tours in the data.

            //Save the tour back to the file
            storage.Save(data); // Save the updated data back to the XML file.

            Console.WriteLine("Tour saved successfully to XML!");

            storage = new XmlStorage("museumTours.xml");
            var admin = new AdminService(storage);

            //Create a tour via business logic
            Console.Write("Enter tour name: ");
            // Taking input from the user for the tour name.  // Also tells the compiler that the value won't be null at runtime using !
            string tourName = Console.ReadLine()!;
            tour = admin.AddTour(tourName);

            Console.WriteLine($"Tour '{tour.Name}' has been created successfully with the ID {tour.Id}!");

            DateTime startDate, endDate;

            while (true)
            {
                Console.Write("Enter start date (yyyy-MM-dd): ");
                if (DateTime.TryParse(Console.ReadLine(), out startDate))
                {
                    break; // Exit the loop if the date is valid.
                }

                Console.WriteLine("Invalid date format. Please try again.");
            }

            while (true)
            {
                Console.Write("Enter end date (yyyy-MM-dd): ");
                if (DateTime.TryParse(Console.ReadLine(), out endDate) && endDate > startDate)
                {
                    break; // Exit the loop if the date is valid and after the start date.
                }
                Console.WriteLine("Invalid date format or end date is not after start date. Please try again.");
            }

            try
            {
                var city = admin.AddCityToTour(tour.Id, "Sample City", startDate, endDate);
                Console.WriteLine($"City added with:\n ID: {city.Id},\n Name: {city.Name},\n Start Date: {city.StartDate},\n End Date: {city.EndDate}");
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}"); // Catch and display any errors that occur during city addition.
            }
        }
    }
}
