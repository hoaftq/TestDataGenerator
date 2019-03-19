using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using TestDataGeneratorLib.Entity;

namespace TestDataGeneratorLib.DataSource.DBDataSource
{
    abstract class DBDataSource : IDataSource
    {
        private DatabaseInfo dbInfo;

        protected DBDataSource(DatabaseInfo dbInfo)
        {
            this.dbInfo = dbInfo;
        }

        public List<DataTable> GetData(List<Table> tables, int numberOfRows)
        {
            using (var connection = new OdbcConnection(dbInfo.ConnectionString))
            {
                return tables.Select(r =>
                {
                    var dataTable = new DataTable();
                    var adapter = new OdbcDataAdapter(CreateSelectCommand(r, numberOfRows), connection);
                    adapter.Fill(dataTable);
                    return dataTable;
                }).ToList();
            }
        }

        protected abstract string CreateSelectCommand(Table table, int numberOfRows);
    }
}
