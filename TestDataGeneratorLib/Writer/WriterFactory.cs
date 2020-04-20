using System;
using TestDataGeneratorLib.Common;

namespace TestDataGeneratorLib.Writer
{
    public class WriterFactory
    {
        public IWriter CreateWriter(WriterKind kind)
        {
            switch (kind)
            {
                case WriterKind.SQLCommandText:
                    return new SQLWriter();
                case WriterKind.TabDelimitedText:
                    return new TabDelimitedWriter();
                case WriterKind.ExcelFile:
                    return new ExcelWriter();
                case WriterKind.Database:
                    return new DBWriter();
            }

            throw new NotSupportedException();
        }
    }
}
