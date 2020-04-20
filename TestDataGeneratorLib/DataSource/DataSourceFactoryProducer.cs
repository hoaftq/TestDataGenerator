using System;
using TestDataGeneratorLib.DataSource.DBDataSource;
using TestDataGeneratorLib.DataSource.Generator;
using TestDataGeneratorLib.Entity;

namespace TestDataGeneratorLib.DataSource
{
    public class DataSourceFactoryProducer
    {
        public IDataSourceFactory CreateDataSource(DataSourceType type, ConnectionEntity dbInfo)
        {
            switch (type)
            {
                case DataSourceType.Database:
                    return new DBDataSourceFactory(dbInfo);

                case DataSourceType.Generator:
                    return new GeneratorDataSourceFactory(dbInfo);
            }

            throw new NotSupportedException();
        }
    }
}
