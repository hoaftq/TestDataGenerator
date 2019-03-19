using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using TestDataGeneratorLib.Entity;

namespace TestDataGeneratorLib.Reader
{
    public abstract class MetaDBReader
    {
        public string DBname { get; set; }

        private string ConnectionString { get; set; }

        public MetaDBReader(string dbName, string connectionString)
        {
            DBname = dbName;
            ConnectionString = connectionString;
        }

        public List<Table> GetTables()
        {
            using (var connection = new OdbcConnection(ConnectionString))
            {
                var dataTable = connection.GetSchema("Tables");
                return dataTable.AsEnumerable().Select(r => CreateTableInfo(r)).ToList();
            }
        }

        public DataTable GetTableInfo(Table table)
        {
            var dataTable = new DataTable();
            using (var adapter = new OdbcDataAdapter(CreateSelectCommand(table), ConnectionString))
            {
                adapter.FillSchema(dataTable, SchemaType.Source);
            }
            return dataTable;
        }

        protected abstract Table CreateTableInfo(DataRow row);

        protected abstract string CreateSelectCommand(Table table);
    }
}
