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
        }
    }
}
