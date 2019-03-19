using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataGeneratorLib.DataSource.Generator.FieldGenerator;
using TestDataGeneratorLib.Entity;
using TestDataGeneratorLib.Reader;

namespace TestDataGeneratorLib.DataSource.Generator
{
    class Generator : IDataSource
    {
        private const string GeneratorExtendedKey = "Generator";

        private DatabaseInfo dbInfo;

        private DefaultFieldGeneratorSelector generatorSelector;

        public Generator(DatabaseInfo dbInfo, DefaultFieldGeneratorSelector generatorSelector)
        {
            this.dbInfo = dbInfo;
            this.generatorSelector = generatorSelector;
        }

        public List<DataTable> GetData(List<Table> tables, int numberOfRows)
        {
            return tables.Select((r, index) => GenerateTable(r, index, numberOfRows)).ToList();
        }

        private DataTable GenerateTable(List<Table> tables, int tableIndex, int numberOfRows)
        {
            var readerFactory = new MetaDBReaderFactory();
            var reader = readerFactory.CreateReader(dbInfo);

            var dataTable = reader.GetTableInfo(tables[tableIndex]);
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                var generator = generatorSelector.DecideFieldGenerator(dataTable.Columns[i], i, tables, tableIndex);
                dataTable.Columns[i].ExtendedProperties.Add(GeneratorExtendedKey, generator);
            }

            DataRow prevRow = null;
            for (int i = 0; i < numberOfRows; i++)
            {
                var dataRow = dataTable.NewRow();
                foreach (DataColumn column in dataTable.Columns)
                {
                    var generator = column.ExtendedProperties[GeneratorExtendedKey] as IFieldGenerator;
                    dataRow[column] = generator.NextValue(column, i, prevRow);
                }

                prevRow = dataRow;
            }

            return dataTable;
        }
    }
}
