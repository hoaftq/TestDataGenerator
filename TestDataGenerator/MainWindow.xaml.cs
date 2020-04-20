using System.Data;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using TestDataGeneratorLib.Common;
using TestDataGeneratorLib.Entity;

namespace TestDataGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel ViewModel;

        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new MainWindowViewModel(this);
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var settingsDialog = new SourceSettingsDialog(this);
            //var dbInfo = new List<CustomDatabaseEntity>
            //{
            //     new CustomDatabaseEntity()
            //     {
            //          ConnectionString = @"DRIVER={ODBC Driver 17 for SQL Server};SERVER=(localdb)\MSSQLLocalDB;DATABASE=TestDB;Trusted_Connection=yes;",
            //          ConnectionName= "Abc project",
            //          Kind = TestDataGeneratorLib.Common.DatabaseKind.MSSQL
            //     },
            //     new CustomDatabaseEntity()
            //     {
            //          ConnectionString = "yyyyyyyyyyyyyy",
            //          ConnectionName= "Xyz project",
            //          Kind = TestDataGeneratorLib.Common.DatabaseKind.LocalDB
            //     }
            //};

            ////settingsDialog.DBInfoCollection = dbInfo;
            ////if (settingsDialog.ShowDialog() ?? false)
            ////{

            ////}

            //var tableSelectionDialog = new TableSelectionDialog();
            //tableSelectionDialog.Databases = dbInfo;
            //tableSelectionDialog.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = ViewModel;
        }

        //private void Add_Click(object sender, RoutedEventArgs e)
        //{
        //    ViewModel.AddTable();
        //}

        //private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    var selectedItem = ((ListView)sender).SelectedItem as TableEntity;
        //    ViewModel.TableSelectionChanged(selectedItem);
        //}
    }
}
