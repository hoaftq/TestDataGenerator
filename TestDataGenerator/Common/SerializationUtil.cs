using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TestDataGenerator.Common
{
    public static class SerializationUtil
    {
        public static void Serialize(object o, string filePath)
        {
            var serializer = new XmlSerializer(o.GetType());
            using (var writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, o);
            }
        }

        public static T Deserialize<T>(string filePath)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var reader = new StreamReader(filePath))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}
