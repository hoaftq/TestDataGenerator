using System.Collections.Generic;
using System.Data;

namespace TestDataGeneratorLib.Writer
{
    interface IWriter
    {
        object GetOutputContent(List<DataTable> tables);
    }
}
