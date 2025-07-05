using BusinessLogic;
using Domain;
using DataStorage;


namespace MuseumTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var storage = new XmlStorage("museumTours.xml");
            var admin = new AdminService(storage);

            //Create a tour via business logic
            Console.Write("Enter tour name: ");
            // Taking input from the user for the tour name.  // Also tells the compiler that the value won't be null at runtime using !
            string tourName = Console.ReadLine()!; 
            var tour = admin.AddTour(tourName);

            Console.WriteLine($"Tour '{tour.Name}' has been created successfully!");

        }
    }
}
