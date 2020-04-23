﻿using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TestDataGeneratorLib.Utils;

namespace TestDataGeneratorLib.Writer
{
    class SQLWriter : IWriter
    {
        public object Write(List<DataTable> tables)
        {
            var builder = new StringBuilder();
            string prevConnecitonName = null;
            foreach (var t in tables.OrderBy(t => t.GetExtendedTableInfo().ConnectionInfo.ConnectionName))
            {
                var connectionInfo = t.GetExtendedTableInfo().ConnectionInfo;
                if (prevConnecitonName != connectionInfo.ConnectionName)
                {
                    builder.AppendLine("-- " + connectionInfo.ConnectionName);
                    builder.AppendLine("-- " + connectionInfo.ConnectionString);
                    prevConnecitonName = connectionInfo.ConnectionName;
                }

                builder.AppendLine(BuildCommentForTable(t));
                foreach (var dataRow in t.AsEnumerable())
                {
                    builder.AppendLine($"INSERT INTO {BuildTableName(t)} ({BuildFieldNamesString(t)}) VALUES({BuildValuesString(dataRow)})");
                }

                builder.AppendLine();
            }

            return builder.ToString();
        }

        private string BuildFieldNamesString(DataTable dataTable)
        {
            var builder = new StringBuilder();
            foreach (DataColumn column in dataTable.Columns)
            {
                builder.Append(", ");
                builder.Append(column.ColumnName);
            }

            return builder.Remove(0, 2).ToString();
        }

        private string BuildValuesString(DataRow row)
        {
            var builder = new StringBuilder();
            foreach (DataColumn column in row.Table.Columns)
            {
                builder.Append($", {FormatFieldValue(column, row[column])}");
            }

            return builder.Remove(0, 2).ToString();
        }

        protected virtual string BuildCommentForTable(DataTable table)
        {
            return $"-----TABLE {table.TableName}-----";
        }

        protected virtual string BuildTableName(DataTable dataTable)
        {
            var table = dataTable.GetExtendedTableInfo();
            return $"[{ table.Schema}].[{dataTable.TableName}]";
        }

        protected virtual string FormatFieldValue(DataColumn column, object value)
        {
            if (column.DataType == typeof(int) || column.DataType == typeof(decimal))
            {
                return $"{value}/*{column.ColumnName}*/";
            }

            return $"'{value}'/*{column.ColumnName}*/";
        }
    }
}
