using System.Data;
using TestDataGeneratorLib.Entity;

namespace TestDataGeneratorLib.Reader
{
    class MSSQLMetaReader : MetaDBReader
    {
        public MSSQLMetaReader(ConnectionEntity dbInfo) : base(dbInfo)
        {
        }

        protected override string CreateSelectCommand(TableEntity table)
        {
            return $"SELECT * FROM [{table.Schema}].[{table.TableName}]";
        }

        protected override TableEntity CreateTableInfo(DataRow row)
        {
            return new TableEntity()
            {
                ConnectionInfo = dbInfo,
                DatabaseName = row["TABLE_CAT"].ToString(),
                Schema = row["TABLE_SCHEM"].ToString(),
                TableName = row["TABLE_NAME"].ToString(),
                TableType = row["TABLE_TYPE"].ToString()
            };
        }
    }
}
