using System;
using TestDataGeneratorLib.Common;
using TestDataGeneratorLib.Entity;

namespace TestDataGeneratorLib.Reader
{
    public class MetaDBReaderFactory
    {
        public MetaDBReader CreateReader(DatabaseInfo dbInfo)
        {
            switch (dbInfo.Kind)
            {
                case DatabaseKind.MSSQL:
                    return new MSSQLMetaReader(dbInfo.DisplayName, dbInfo.ConnectionString);
            }

            throw new NotSupportedException();
        }
    }
}
