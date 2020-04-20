using System.Collections.Generic;
using System.Data;
using TestDataGeneratorLib.DataSource.Generator.FieldGenerator;
using TestDataGeneratorLib.Entity;

namespace TestDataGeneratorLib.DataSource.Generator
{
    class Generator : IDataSource
    {
        private const string GeneratorExtendedKey = "Generator";

        // TODO not used yet
        private readonly ConnectionEntity dbInfo;

        private readonly IFieldGeneratorSelector generatorSelector;

        public Generator(ConnectionEntity dbInfo, IFieldGeneratorSelector generatorSelector)
        {
            this.dbInfo = dbInfo;
            this.generatorSelector = generatorSelector;
        }

        public void FillData(List<DataTable> tables, int numberOfRows)
        {
            for (int i = 0; i < tables.Count; i++)
            {
                FillData(tables, i, numberOfRows);
            }
        }

        private void FillData(List<DataTable> targetTables, int tableIndex, int numberOfRows)
        {
            var dataTable = targetTables[tableIndex];
            dataTable.Rows.Clear();

            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                var generator = generatorSelector.DecideFieldGenerator(dataTable.Columns[i], i, targetTables, tableIndex);
                dataTable.Columns[i].ExtendedProperties.Remove(GeneratorExtendedKey);
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

                dataTable.Rows.Add(dataRow);
                prevRow = dataRow;
            }
        }
    }
}
