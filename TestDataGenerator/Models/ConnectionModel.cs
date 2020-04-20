using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataGeneratorLib.Entity;

namespace TestDataGenerator.Models
{
    public class ConnectionModel : ConnectionEntity, IDataErrorInfo
    {
        public string this[string columnName]
        {
            get
            {
                string message = null;
                switch (columnName)
                {
                    case nameof(ConnectionName):
                        if (string.IsNullOrEmpty(ConnectionName))
                        {
                            return "Connection name is required";
                        }
                        break;

                    case nameof(ConnectionString):
                        if (string.IsNullOrEmpty(ConnectionString))
                        {
                            return "Connection string is required";
                        }
                        break;
                }

                return message;
            }
        }

        public string Error => "";
    }
}
