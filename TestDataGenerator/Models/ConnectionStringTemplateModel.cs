using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataGeneratorLib.Common;

namespace TestDataGenerator.Models
{
    public class ConnectionStringTemplateModel
    {
        public DatabaseKind? DatabaseKind { get; set; }

        public string ConnectionStringTemplate { get; set; }

        public string Description { get; set; }
    }
}
