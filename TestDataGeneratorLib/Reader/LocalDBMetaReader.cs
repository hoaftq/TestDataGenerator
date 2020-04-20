using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataGeneratorLib.Entity;

namespace TestDataGeneratorLib.Reader
{
    class LocalDBMetaReader : MSSQLMetaReader
    {
        public LocalDBMetaReader(ConnectionEntity dbInfo) : base(dbInfo)
        {
        }
    }
}
