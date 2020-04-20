using System;
using TestDataGeneratorLib.Common;
using TestDataGeneratorLib.Entity;

namespace TestDataGeneratorLib.Reader
{
    public class MetaDBReaderFactory
    {
        public MetaDBReader CreateReader(ConnectionEntity connectionInfo)
        {
            switch (connectionInfo.Kind)
            {
                case DatabaseKind.MSSQL:
                    return new MSSQLMetaReader(connectionInfo);
                case DatabaseKind.LocalDB:
                    return new LocalDBMetaReader(connectionInfo);
            }

            throw new NotSupportedException();
        }
    }
}
