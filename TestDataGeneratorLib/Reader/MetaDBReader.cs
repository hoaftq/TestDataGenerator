using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using TestDataGeneratorLib.Entity;
using TestDataGeneratorLib.Utils;

namespace TestDataGeneratorLib.Reader
{
    public abstract class MetaDBReader
    {
        protected ConnectionEntity dbInfo;

        public MetaDBReader(ConnectionEntity dbInfo)
        {
            this.dbInfo = dbInfo;
        }

        public IEnumerable<TableEntity> GetAllTables()
        {
            try
            {
                using (var connection = new OdbcConnection(dbInfo.ConnectionString))
                {
                    connection.Open();
                    var dataTable = connection.GetSchema("Tables");
                    return dataTable.AsEnumerable().Select(r => CreateTableInfo(r));
                }
            }
            catch (OdbcException)
            {
                return null;
            }
        }

        public DataTable GetTableMetaData(TableEntity table)
        {
            var dataTable = new DataTable();
            using (var adapter = new OdbcDataAdapter(CreateSelectCommand(table), dbInfo.ConnectionString))
            {
                adapter.FillSchema(dataTable, SchemaType.Source);
            }

            dataTable.SetExtendedTableInfo(table);
            return dataTable;
        }

        protected abstract TableEntity CreateTableInfo(DataRow row);

        protected abstract string CreateSelectCommand(TableEntity table);
    }
}
