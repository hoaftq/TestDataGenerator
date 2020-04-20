using System;
using System.Data;

namespace TestDataGeneratorLib.DataSource.Generator.FieldGenerator
{
    public class StringGenerator : IFieldGenerator
    {
        private const int MAX_LENGTH = 1000;

        private string startString;

        public StringGenerator(string startString)
        {
            this.startString = startString;
        }

        public object NextValue(DataColumn colum, int rowIndex, DataRow previousRow)
        {
            var endString = (++rowIndex).ToString();
            return startString + endString.PadLeft(Math.Min(colum.MaxLength, MAX_LENGTH) - startString.Length, '0');
        }
    }
}
