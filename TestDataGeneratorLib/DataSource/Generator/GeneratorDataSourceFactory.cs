using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataGeneratorLib.Entity;

namespace TestDataGeneratorLib.DataSource.Generator
{
    class GeneratorDataSourceFactory : IDataSourceFactory
    {
        private DatabaseInfo dbInfo;

        public GeneratorDataSourceFactory(DatabaseInfo dbInfo)
        {
            this.dbInfo = dbInfo;
        }

        public IDataSource CreateDataSource()
        {
            return new Generator(dbInfo);
        }
    }
}
