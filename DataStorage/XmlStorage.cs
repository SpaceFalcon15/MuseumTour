using System;
using System.IO;
using System.Xml.Serialization;
using Domain;

namespace DataStorage
{
    class XmlStorage
    {
        private readonly string _filePath;
        public XmlStorage(string filePath)
        {
            _filePath = filePath;
        }
        public MuseumToursDocumentation Load()
        {
            if (!File.Exists(_filePath))
                return new MuseumToursDocumentation();  // Return an empty instance if the file does not exist.
            var serializer = new XmlSerializer(typeof(MuseumToursDocumentation));
            using var stream = File.OpenRead(_filePath);
            return (MuseumToursDocumentation)serializer.Deserialize(stream)!;
        }
        public void Save(MuseumToursDocumentation data)
        {
            var serializer = new XmlSerializer(typeof(MuseumToursDocumentation));
            using var stream = File.Create(_filePath); 
            serializer.Serialize(stream, data);
        }
    }
}
