using TestDataGeneratorLib.Entity;

namespace TestDataGeneratorLib.DataSource.Generator
{
    class GeneratorDataSourceFactory : IDataSourceFactory
    {
        private readonly ConnectionEntity dbInfo;

        private readonly IFieldGeneratorSelector fieldGeneratorSelector;

        public GeneratorDataSourceFactory(ConnectionEntity dbInfo, IFieldGeneratorSelector fieldGeneratorSelector = null)
        {
            this.dbInfo = dbInfo;
            this.fieldGeneratorSelector = fieldGeneratorSelector ?? new DefaultFieldGeneratorSelector();
        }

        public IDataSource CreateDataSource()
        {
            return new Generator(dbInfo, fieldGeneratorSelector);
        }
    }
}
