using System.ComponentModel;

namespace TestDataGeneratorLib.Common
{
    public enum WriterKind
    {
        [Description("SQL Command Text")]
        SQLCommandText,

        [Description("Tab Delimited Text")]
        TabDelimitedText,

        [Description("Excel File")]
        ExcelFile,

        [Description("Insert to Database")]
        Database
    }
}
