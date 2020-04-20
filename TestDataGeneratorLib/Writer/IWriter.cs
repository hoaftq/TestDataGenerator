using System.Collections.Generic;
using System.Data;

namespace TestDataGeneratorLib.Writer
{
    public interface IWriter
    {
        object Write(List<DataTable> tables);
    }
}
