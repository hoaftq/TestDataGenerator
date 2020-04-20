using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TestDataGeneratorLib.Common;

namespace TestDataGenerator.Models
{
    public class ConnectionStringTemplatesEntity
    {
        public DatabaseKind DatabaseKind { get; set; }

        [XmlArrayItem("Template")]
        public List<ConnectionStringTemplateEntity> Templates { get; set; }

        public class ConnectionStringTemplateEntity
        {
            public string ConnectionStringTemplate { get; set; }

            public string Description { get; set; }
        }
    }
}
