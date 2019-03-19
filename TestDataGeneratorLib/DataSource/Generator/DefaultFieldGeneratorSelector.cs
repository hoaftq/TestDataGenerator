using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataGeneratorLib.DataSource.Generator.FieldGenerator;

namespace TestDataGeneratorLib.DataSource.Generator
{
    class DefaultFieldGeneratorSelector : IFieldGeneratorSelector
    {
        public IFieldGenerator DecideFieldGenerator(DataColumn column, int columnIndex, List<DataTable> allTables, int tableIndex)
        {
            if (column.DataType == typeof(string))
            {
                return new StringGenerator("A");
            }

            if (column.DataType == typeof(decimal))
            {
                return new DecimalGenerator();
            }

            return null;
        }
    }
}
