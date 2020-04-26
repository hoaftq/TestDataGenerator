using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataGeneratorLib.Utils;

namespace TestDataGeneratorLib.Writer
{
    class DBWriter : WriterBase
    {
        private OdbcConnection odbcConnection;

        private OdbcTransaction transaction;

        protected override void WriteTable(DataTable table)
        {
            throw new NotImplementedException();
        }

        protected override void BeginConnection(IEnumerable<DataTable> tablesInConnection)
        {
            odbcConnection = new OdbcConnection();
            transaction = odbcConnection.BeginTransaction();
        }

        protected override void EndConnection(IEnumerable<DataTable> tablesInConnection, bool hasError = false)
        {
            if (!hasError)
            {
                transaction.Commit();
            }
            else
            {
                transaction.Rollback();
            }
        }

        //protected override void EndConnection(IEnumerable<DataTable> tablesInConnection)
        //{
        //    transaction.Commit();
        //}
    }
}
