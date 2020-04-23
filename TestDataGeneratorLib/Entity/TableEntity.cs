using System.Collections.Generic;

namespace TestDataGeneratorLib.Entity
{
    public class TableEntity
    {
        public string DatabaseName { get; set; }

        public string Schema { get; set; }

        public string TableName { get; set; }

        public string TableType { get; set; }

        public ConnectionEntity ConnectionInfo { get; set; }

        public override bool Equals(object obj)
        {
            var o = obj as TableEntity;
            return o != null
                   && ConnectionInfo == o.ConnectionInfo // Must have the same instance of ConnecitonEntity
                   && DatabaseName == o.DatabaseName
                   && Schema == o.Schema
                   && TableName == o.TableName
                   && TableType == o.TableType;
        }

        public override int GetHashCode()
        {
            string str = ConnectionInfo.ConnectionName + Schema + TableName + TableType;
            return str.GetHashCode();
        }

        //public override bool Equals(object obj)
        //{
        //    var entity = obj as TableEntity;
        //    return entity != null &&
        //           DatabaseName == entity.DatabaseName &&
        //           Schema == entity.Schema &&
        //           TableName == entity.TableName &&
        //           TableType == entity.TableType &&
        //           EqualityComparer<ConnectionEntity>.Default.Equals(ConnectionInfo, entity.ConnectionInfo);
        //}

        //public override int GetHashCode()
        //{
        //    var hashCode = -1214557472;
        //    hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DatabaseName);
        //    hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Schema);
        //    hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TableName);
        //    hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TableType);
        //    hashCode = hashCode * -1521134295 + EqualityComparer<ConnectionEntity>.Default.GetHashCode(ConnectionInfo);
        //    return hashCode;
        //}
    }
}
