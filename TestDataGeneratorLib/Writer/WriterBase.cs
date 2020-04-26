using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TestDataGeneratorLib.Utils;

namespace TestDataGeneratorLib.Writer
{
    abstract class WriterBase : IWriter
    {
        public object Output { get; private set; }

        public virtual void Write(IEnumerable<DataTable> tables)
        {
            try
            {
                BeginWrite(tables);
                foreach (var connection in tables.GroupBy(t => t.GetExtendedTableInfo().ConnectionInfo).Select(x => x.Key))
                {
                    var tablesInConnection = tables.Where(t => t.GetExtendedTableInfo().ConnectionInfo == connection).ToList();
                    try
                    {
                        BeginConnection(tablesInConnection);
                        foreach (var table in tablesInConnection)
                        {
                            try
                            {
                                BeginTable(table);
                                WriteTable(table);
                            }
                            catch (Exception)
                            {
                                EndTable(table, true);
                                throw;
                            }

                            EndTable(table);
                        }
                    }
                    catch (Exception)
                    {
                        EndConnection(tablesInConnection, true);
                        throw;
                    }

                    EndConnection(tablesInConnection);
                }
            }
            catch (Exception ex)
            {
                Output = ex;
                EndWrite(tables, true);
                return;
            }

            EndWrite(tables);
        }

        protected virtual void BeginWrite(IEnumerable<DataTable> allTables)
        {
        }

        protected virtual void BeginConnection(IEnumerable<DataTable> tablesInConnection)
        {
        }

        protected virtual void BeginTable(DataTable table)
        {
        }

        protected abstract void WriteTable(DataTable table);


        protected virtual void EndTable(DataTable table, bool hasError = false)
        {
        }

        protected virtual void EndConnection(IEnumerable<DataTable> tablesInConnection, bool hasError = false)
        {
        }

        protected virtual void EndWrite(IEnumerable<DataTable> allTables, bool hasError = false)
        {
        }
    }
}
