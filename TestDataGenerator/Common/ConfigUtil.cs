using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using TestDataGenerator.Models;

namespace TestDataGenerator.Common
{
    static class ConfigUtil
    {
        private const string CONFIG_FOLDER_NAME = "Config";

        private const string CONNECTION_FILE_NAME = "Connections.xml";

        private static readonly string configPath;


        static ConfigUtil()
        {
            configPath = Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, CONFIG_FOLDER_NAME);
            Directory.CreateDirectory(configPath);
        }

        public static void SaveConnections(ICollection<ConnectionModel> connections)
        {
            SerializationUtil.Serialize(connections, Path.Combine(configPath, CONNECTION_FILE_NAME));
        }

        public static ObservableCollection<ConnectionModel> LoadConnections()
        {
            try
            {
                return SerializationUtil.Deserialize<ObservableCollection<ConnectionModel>>(Path.Combine(configPath, CONNECTION_FILE_NAME));
            }
            catch(Exception ex)
            {
                // TODO log?
                return new ObservableCollection<ConnectionModel>();
            }
        }

    }
}
