using System.Data;

namespace TestDataGeneratorLib.DataSource.Generator.FieldGenerator
{
    public interface IFieldGenerator
    {
        object NextValue(DataColumn colum, int rowIndex, DataRow previousRow);
    }
}
