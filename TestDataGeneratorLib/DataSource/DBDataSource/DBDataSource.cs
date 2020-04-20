using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using TestDataGeneratorLib.Entity;

namespace TestDataGeneratorLib.DataSource.DBDataSource
{
    abstract class DBDataSource : IDataSource
    {
        private ConnectionEntity dbInfo;

        protected DBDataSource(ConnectionEntity dbInfo)
        {
            this.dbInfo = dbInfo;
        }

        //public List<DataTable> FillData(List<TableEntity> tables, int numberOfRows)
        //{
        //    using (var connection = new OdbcConnection(dbInfo.ConnectionString))
        //    {
        //        return tables.Select(r =>
        //        {
        //            var dataTable = new DataTable();
        //            var adapter = new OdbcDataAdapter(CreateSelectCommand(r, numberOfRows), connection);
        //            adapter.Fill(dataTable);
        //            return dataTable;
        //        }).ToList();
        //    }
        //}

        public void FillData(List<DataTable> tables, int numberOfRows)
        {
            using (var connection = new OdbcConnection(dbInfo.ConnectionString))
            {
                tables.ForEach(t =>
                {
                    var adapter = new OdbcDataAdapter(CreateSelectCommand(t, numberOfRows), connection);
                    adapter.Fill(t);
                });
            }
        }

        protected abstract string CreateSelectCommand(DataTable table, int numberOfRows);
    }
}
