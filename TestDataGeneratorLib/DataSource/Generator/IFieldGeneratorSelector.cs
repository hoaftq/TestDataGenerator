using System.Collections.Generic;
using System.Data;
using TestDataGeneratorLib.DataSource.Generator.FieldGenerator;

namespace TestDataGeneratorLib.DataSource.Generator
{
    interface IFieldGeneratorSelector
    {
        IFieldGenerator DecideFieldGenerator(DataColumn column, int columnIndex, List<DataTable> targetTables, int tableIndex);
    }
}
