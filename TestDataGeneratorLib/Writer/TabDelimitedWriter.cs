using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TestDataGeneratorLib.Writer
{
    class TabDelimitedWriter : WriterBase
    {
        private StringBuilder builder = new StringBuilder();

        public override object Output => builder.ToString();

        //public object Write(List<DataTable> tables)
        //{
        //    StringBuilder builder = new StringBuilder();
        //    tables.ForEach(t =>
        //    {
        //        builder.AppendLine($"Table {t.TableName}");
        //        BuildTableOutput(t, builder);
        //        builder.AppendLine();
        //    });

        //    return builder.ToString();
        //}

        //private void BuildTableOutput(DataTable table, StringBuilder builder)
        //{
        //    BuildLine(table.Columns.Cast<DataColumn>(), builder);
        //    foreach (DataRow row in table.Rows)
        //    {
        //        BuildLine(table.Columns.Cast<DataColumn>().Select(c => row[c]), builder);
        //    }
        //}


        protected override void WriteTable(DataTable table)
        {
            builder.AppendLine($"Table {table.TableName}");
            BuildLine(table.Columns.Cast<DataColumn>(), builder);
            foreach (DataRow row in table.Rows)
            {
                BuildLine(table.Columns.Cast<DataColumn>().Select(c => row[c]), builder);
            }
        }



        private void BuildLine(IEnumerable<object> items, StringBuilder builder)
        {
            foreach (var item in items)
            {
                builder.AppendFormat("{0}\t", item);
            }
            builder.Remove(builder.Length - 1, 1).AppendLine();
        }
    }
}
