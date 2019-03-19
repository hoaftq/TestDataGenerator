using System.Data;

namespace TestDataGeneratorLib.DataSource.Generator.FieldGenerator
{
    interface IFieldGenerator
    {
        object NextValue(DataColumn colum, int rowIndex, DataRow previousRow);
    }
}
