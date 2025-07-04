using Domain;

namespace MuseumTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var tour = new Domain.MuseumTour { Name = "Sample Tour" };
            Console.WriteLine($"Tour Name: {tour.Id}");
        }
    }
}
