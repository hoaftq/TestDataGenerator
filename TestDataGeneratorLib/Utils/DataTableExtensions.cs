using System.Data;
using TestDataGeneratorLib.Entity;

namespace TestDataGeneratorLib.Utils
{
    public static class DataTableExtensions
    {
        private const string TableInfoExtendedKey = "TableInfo";

        public static TableEntity GetExtendedTableInfo(this DataTable dataTable)
            => dataTable.ExtendedProperties[TableInfoExtendedKey] as TableEntity;

        public static void SetExtendedTableInfo(this DataTable dataTable, TableEntity table)
            => dataTable.ExtendedProperties.Add(TableInfoExtendedKey, table);

    }
}
