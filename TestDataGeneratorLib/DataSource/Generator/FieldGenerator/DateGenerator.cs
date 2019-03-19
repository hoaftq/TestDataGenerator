using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDataGeneratorLib.DataSource.Generator.FieldGenerator
{
    class DateGenerator : IFieldGenerator
    {
        public object NextValue(DataColumn colum, int rowIndex, DataRow previousRow)
        {
            throw new NotImplementedException();
        }
    }
}
