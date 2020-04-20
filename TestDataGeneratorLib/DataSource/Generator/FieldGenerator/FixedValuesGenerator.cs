using System;
using System.Data;

namespace TestDataGeneratorLib.DataSource.Generator.FieldGenerator
{
    public class FixedValuesGenerator : IFieldGenerator
    {
        public object NextValue(DataColumn colum, int rowIndex, DataRow previousRow)
        {
            throw new NotImplementedException();
        }
    }
}
