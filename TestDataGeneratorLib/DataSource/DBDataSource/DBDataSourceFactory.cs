using System;
using TestDataGeneratorLib.Common;
using TestDataGeneratorLib.Entity;

namespace TestDataGeneratorLib.DataSource.DBDataSource
{
    class DBDataSourceFactory : IDataSourceFactory
    {
        private DatabaseInfo dbInfo;

        public DBDataSourceFactory(DatabaseInfo dbInfo)
        {
            this.dbInfo = dbInfo;
        }

        public IDataSource CreateDataSource()
        {
            switch (dbInfo.Kind)
            {
                case DatabaseKind.MSSQL:
                    return new MSSQLDataSource(dbInfo);
            }

            throw new NotSupportedException();
        }
    }
}
