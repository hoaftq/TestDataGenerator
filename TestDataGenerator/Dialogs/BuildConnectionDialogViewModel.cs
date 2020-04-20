using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using TestDataGenerator.Common;
using TestDataGenerator.Models;
using TestDataGeneratorLib.Utils;

namespace TestDataGenerator.Dialogs
{
    public class BuildConnectionDialogViewModel : BindableObject
    {
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

        public ListCollectionView TemplateCollectionView { get; private set; }

        private bool? isSuccessfulConnection;
        public bool? IsSuccessfulConnection
        {
            get => isSuccessfulConnection;
            private set
            {
                isSuccessfulConnection = value;
                NotifyPropertyChanged();
            }
        }

        private string connectionErrorMessage;

        public string ConnectionErrorMessage
        {
            get => connectionErrorMessage;
            private set
            {
                connectionErrorMessage = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand TestConnectionCommand => new DelegateCommand((p) =>
        {
            IsSuccessfulConnection = DBUtil.TestConnection(p as string, out string errorMessage);
            ConnectionErrorMessage = errorMessage;
        });

        public BuildConnectionDialogViewModel()
        {
            List<ConnectionStringTemplatesEntity> connectionTemplates = SerializationUtil.Deserialize<List<ConnectionStringTemplatesEntity>>("ConnectionStringTemplates.xml");

            var groupedTemplates = connectionTemplates.SelectMany(e => e.Templates.Select(t => new ConnectionStringTemplateModel()
            {
                DatabaseKind = e.DatabaseKind,
                ConnectionStringTemplate = t.ConnectionStringTemplate,
                Description = t.Description
            })).ToList();
            groupedTemplates.Insert(0, new ConnectionStringTemplateModel());

            TemplateCollectionView = new ListCollectionView(groupedTemplates.ToList());
            TemplateCollectionView.GroupDescriptions.Add(new PropertyGroupDescription("DatabaseKind"));
        }

        public void ChooseTemplate(string template)
        {
            ConnectionString += template;
        }
    }
}
