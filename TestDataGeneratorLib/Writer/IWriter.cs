using System.Collections.Generic;
using System.Data;

namespace TestDataGeneratorLib.Writer
{
    public interface IWriter
    {
        void Write(IEnumerable<DataTable> tables);

        object Output { get; }
    }
}
