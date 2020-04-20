using System.Collections.Generic;
using TestDataGeneratorLib.Common;
using TestDataGeneratorLib.Utils;

namespace TestDataGeneratorLib.Entity
{
    public class ConnectionEntity : BindableObject
    {
        private DatabaseKind kind;

        public DatabaseKind Kind
        {
            get => kind;
            set
            {
                kind = value;
                NotifyPropertyChanged();
            }
        }

        private string connectionName;
        public string ConnectionName
        {
            get => connectionName;
            set
            {
                connectionName = value;
                NotifyPropertyChanged();
            }
        }

        private string connectionString;
        public string ConnectionString
        {
            get => connectionString;
            set
            {
                connectionString = value;
                NotifyPropertyChanged();
            }
        }

        public override bool Equals(object obj)
        {
            var entity = obj as ConnectionEntity;
            return entity != null &&
                   kind == entity.kind &&
                   connectionName == entity.connectionName &&
                   connectionString == entity.connectionString;
        }

        public override int GetHashCode()
        {
            var hashCode = -74572215;
            hashCode = hashCode * -1521134295 + kind.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(connectionName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(connectionString);
            return hashCode;
        }
    }
}
