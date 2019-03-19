using System.Data;
using TestDataGeneratorLib.Entity;

namespace TestDataGeneratorLib.Reader
{
    class MSSQLMetaReader : MetaDBReader
    {
        public MSSQLMetaReader(string dbName, string connectionString) : base(dbName, connectionString)
        {
        }

        protected override string CreateSelectCommand(Table table)
        {
            return $"SELECT * FROM [{table.Schema}].[{table.TableName}]";
        }

        protected override Table CreateTableInfo(DataRow row)
        {
            return new Table()
            {
                DBName = row["TABLE_CAT"].ToString(),
                Schema = row["TABLE_SCHEM"].ToString(),
                TableName = row["TABLE_NAME"].ToString(),
                TableType = row["TABLE_TYPE"].ToString()
            };
        }
    }
}
