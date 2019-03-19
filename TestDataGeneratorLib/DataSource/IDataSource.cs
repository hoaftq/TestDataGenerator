using System.Collections.Generic;
using System.Data;
using TestDataGeneratorLib.Entity;

namespace TestDataGeneratorLib.DataSource
{
    public interface IDataSource
    {
        List<DataTable> GetData(List<Table> tables, int numberOfRows);
    }
}
