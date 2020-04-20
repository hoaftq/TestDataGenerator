using System.Windows.Input;
using TestDataGeneratorLib.Entity;

namespace TestDataGenerator.Models
{
    public class TableModel : TableEntity
    {
        public bool IsSelected { get; set; }

        public TableModel(TableEntity entity, bool isSelected = false)
        {
            DatabaseName = entity.DatabaseName;
            Schema = entity.Schema;
            TableName = entity.TableName;
            TableType = entity.TableType;
            ConnectionInfo = entity.ConnectionInfo;
            IsSelected = isSelected;
        }

        public override bool Equals(object obj)
        {
            var o = obj as TableModel;
            return o != null
                   && ConnectionInfo == o.ConnectionInfo
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
    }
}
