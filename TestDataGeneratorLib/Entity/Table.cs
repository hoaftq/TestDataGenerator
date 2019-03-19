using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDataGeneratorLib.Entity
{
    public class Table
    {
        public string DBName { get; set; }

        public string Schema { get; set; }

        public string TableName { get; set; }

        public string TableType { get; set; }
    }
}
