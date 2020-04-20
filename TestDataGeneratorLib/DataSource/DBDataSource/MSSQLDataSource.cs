using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataGeneratorLib.Entity;
using TestDataGeneratorLib.Utils;

namespace TestDataGeneratorLib.DataSource.DBDataSource
{
    class MSSQLDataSource : DBDataSource
    {
        public MSSQLDataSource(ConnectionEntity dbInfo) : base(dbInfo)
        {
        }

        protected override string CreateSelectCommand(DataTable table, int numberOfRows)
        {
            var tableInfo = table.GetExtendedTableInfo();
            return $"SELECT TOP {numberOfRows} * FROM [{tableInfo.DatabaseName}].[{tableInfo.Schema}].[{table.TableName}]";
        }
    }
}
