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
        public IFieldGenerator DecideFieldGenerator(DataColumn column, int columnIndex, List<DataTable> targetTables, int tableIndex)
        {
            if (column.DataType == typeof(string))
            {
                return new StringGenerator("A");
            }

            if (column.DataType == typeof(decimal))
            {
                return new DecimalGenerator();
            }

            if (column.DataType == typeof(short))
            {
                return new IntergerGenerator();
            }

            if (column.DataType == typeof(int))
            {
                return new IntergerGenerator();
            }

            if (column.DataType == typeof(DateTime))
            {
                return new DateTimeGenerator();
            }

            throw new NotSupportedException();
        }
    }
}
