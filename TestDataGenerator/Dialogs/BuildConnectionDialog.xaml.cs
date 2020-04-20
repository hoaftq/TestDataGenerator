using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TestDataGenerator.Common;
using TestDataGenerator.Models;

namespace TestDataGenerator.Dialogs
{
    /// <summary>
    /// Interaction logic for BuildConnectionDialog.xaml
    /// </summary>
    public partial class BuildConnectionDialog : Window
    {
        public BuildConnectionDialogViewModel ViewModel { get; } = new BuildConnectionDialogViewModel();

        public string ConnectionString
        {
            get => ViewModel.ConnectionString;
            set
            {
                ViewModel.ConnectionString = value;
            }
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    var x = new List<ConnectionStringTemplatesEntity>();
        //    x.Add(new ConnectionStringTemplatesEntity()
        //    {
        //        DatabaseKind = TestDataGeneratorLib.Common.DatabaseKind.LocalDB,
        //        Templates = new List<ConnectionStringTemplatesEntity.ConnectionStringTemplateEntity>()
        //         {
        //              new ConnectionStringTemplatesEntity.ConnectionStringTemplateEntity()
        //              {
        //                   Description = "d 1",
        //                   ConnectionStringTemplate = "Template 1"
        //              },
        //              new ConnectionStringTemplatesEntity.ConnectionStringTemplateEntity()
        //              {
        //                   Description = "d 2",
        //                   ConnectionStringTemplate = "Template 2"
        //              },
        //              new ConnectionStringTemplatesEntity.ConnectionStringTemplateEntity()
        //              {
        //                   Description = "d 3",
        //                   ConnectionStringTemplate = "Template 3"
        //              }
        //         }
        //    });
        //    x.Add(new ConnectionStringTemplatesEntity()
        //    {
        //        DatabaseKind = TestDataGeneratorLib.Common.DatabaseKind.MSSQL,
        //        Templates = new List<ConnectionStringTemplatesEntity.ConnectionStringTemplateEntity>()
        //         {
        //              new ConnectionStringTemplatesEntity.ConnectionStringTemplateEntity()
        //              {
        //                   Description = "d x1",
        //                   ConnectionStringTemplate = "Template x1"
        //              },
        //              new ConnectionStringTemplatesEntity.ConnectionStringTemplateEntity()
        //              {
        //                   Description = "d x2",
        //                   ConnectionStringTemplate = "Template x2"
        //              }
        //         }
        //    });
        //    SerializationUtil.Serialize(x, @"D:\Temp\Pers\abc.xml");
        //}

        public ICommand OKCommand => new DelegateCommand((p) =>
        {
            DialogResult = true;
            Close();
        });

        public ICommand CancelCommand => new DelegateCommand((p) =>
        {
            Close();
        });

        public BuildConnectionDialog()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e1)
        {
            DataContext = this;
        }

        private void TemplatesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedValue = e.AddedItems[0] as ConnectionStringTemplateModel;
            ViewModel.ChooseTemplate(selectedValue.ConnectionStringTemplate);
        }
    }
}
