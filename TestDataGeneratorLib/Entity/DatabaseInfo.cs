using TestDataGeneratorLib.Common;

namespace TestDataGeneratorLib.Entity
{
    public class DatabaseInfo
    {
        public DatabaseKind Kind { get; set; }

        public string DisplayName { get; set; }

        public string ConnectionString { get; set; }
    }
}
