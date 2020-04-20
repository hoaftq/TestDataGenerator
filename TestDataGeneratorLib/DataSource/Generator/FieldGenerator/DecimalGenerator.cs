using System.Data;

namespace TestDataGeneratorLib.DataSource.Generator.FieldGenerator
{
    public class DecimalGenerator : IFieldGenerator
    {
        public object NextValue(DataColumn colum, int rowIndex, DataRow previousRow)
        {
            return rowIndex;
        }
    }
}
