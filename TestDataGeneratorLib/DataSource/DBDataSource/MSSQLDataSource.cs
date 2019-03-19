using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataGeneratorLib.Entity;

namespace TestDataGeneratorLib.DataSource.DBDataSource
{
    class MSSQLDataSource : DBDataSource
    {
        public MSSQLDataSource(DatabaseInfo dbInfo) : base(dbInfo)
        {
        }

        protected override string CreateSelectCommand(Table table, int numberOfRows)
        {
            return $"SELECT TOP {numberOfRows} * FROM [{table.Schema}].[{table.DBName}]";
        }
    }
}
