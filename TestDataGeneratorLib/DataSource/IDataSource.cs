using System.Collections.Generic;
using System.Data;

namespace TestDataGeneratorLib.DataSource
{
    public interface IDataSource
    {
        void FillData(List<DataTable> tables, int numberOfRows);
    }
}
