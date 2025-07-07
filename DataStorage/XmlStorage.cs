using System;
using System.IO;
using System.Xml.Serialization;
using Domain;

namespace DataStorage
{
    public class XmlStorage
    {
        private readonly string _filePath; // Path to the XML file where the data will be stored.
        public XmlStorage(string filePath) // Constructor to initialize the XmlStorage with a specified file path.
        {
            _filePath = filePath;
        }
        public MuseumToursDocumentation Load() // Method to load the data from the XML file.
        {
            if (!File.Exists(_filePath)) // Check if the file exists at the specified path.
            {
                return new MuseumToursDocumentation();  // Return an empty instance if the file does not exist.
            }
            var serializer = new XmlSerializer(typeof(MuseumToursDocumentation)); // Create an XmlSerializer for the MuseumToursDocumentation type.
            using var stream = File.OpenRead(_filePath); // Open the file for reading.
            return (MuseumToursDocumentation)serializer.Deserialize(stream)!; // Deserialize the XML data into a MuseumToursDocumentation object and return it.
        }
        public void Save(MuseumToursDocumentation data) // Method to save the data to the XML file.
        {
            var serializer = new XmlSerializer(typeof(MuseumToursDocumentation)); // Create an XmlSerializer for the MuseumToursDocumentation type.
            using var stream = File.Create(_filePath);  // Open the file for writing (creating it if it does not exist).
            serializer.Serialize(stream, data); // Serialize the MuseumToursDocumentation object and write it to the file.
        }
    }
}
