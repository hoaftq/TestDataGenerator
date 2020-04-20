using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using TestDataGeneratorLib.Common;
using TestDataGeneratorLib.Entity;

namespace TestDataGenerator.Dialogs
{
    /// <summary>
    /// Interaction logic for ConnectionConfigDialog.xaml
    /// </summary>
    public partial class ConnectionConfigDialog : Window
    {
        public ConnectionConfigDialogViewModel ViewModel { get; }

        public ObservableCollection<ConnectionModel> Connections => ViewModel.Connections;


        public ConnectionConfigDialog(ObservableCollection<ConnectionModel> connections)
        {
            InitializeComponent();

            ViewModel = new ConnectionConfigDialogViewModel(this);

            ViewModel.CloneConnections(connections);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //DataContext = ViewModel;
            DataContext = this;
        }

        private void sourceDataGrid_InitializingNewItem(object sender, InitializingNewItemEventArgs e)
        {
            //var newItem = e.NewItem as ConnectionEntity;
            //newItem.ConnectionString = string.Empty;
        }



        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    //if(sourceDataGrid.)
        //}

        //private void SourceDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        //{
        //    int columnIndex = sourceDataGrid.Columns.IndexOf(e.Column);
        //    if (columnIndex == 0)
        //    {
        //        var connStringCol = sourceDataGrid.FindName("connectionStringCol") as DataGridColumn;
        //        var connStringTextBlock = connStringCol.GetCellContent(e.Row) as TextBlock;
        //        if (string.IsNullOrEmpty(connStringTextBlock.Text))
        //        {
        //            var dbKind = (DatabaseKind)(e.EditingElement as ComboBox).SelectedItem;
        //            connStringTextBlock.Text = GetConnectionStringTemplate(dbKind);
        //        }
        //    }

        //    ////e.Column.GetCellContent()
        //    ////e.EditingElement.InputBindings.
        //    ////e.Column
        //    //int columnIndex = sourceDataGrid.Columns.IndexOf(e.Column);

        //    //switch (columnIndex)
        //    //{
        //    //    case 0:
        //    //        //var dbInfo = e.Row.Item as DatabaseInfo;

        //    //        if (e.Row.IsNewItem && string.IsNullOrEmpty(newConnectionStringTextBox.Text))
        //    //        {
        //    //            var dbKind = (DatabaseKind)(e.EditingElement as ComboBox).SelectedItem;
        //    //            //switch ((DatabaseKind))
        //    //            //{
        //    //            //    case DatabaseKind.Oracle:
        //    //            //        dbInfo.ConnectionString = "template";
        //    //            //        break;
        //    //            //}
        //    //            //var a = sourceDataGrid.Items[0];
        //    //            newConnectionStringTextBox.Text = GetConnectionStringTemplate(dbKind);
        //    //        }
        //    //        break;

        //    //    case 2:
        //    //        if (e.Row.IsNewItem)
        //    //        {
        //    //            //newConnectionString = (e.EditingElement as TextBox).Text;
        //    //            newConnectionStringTextBox = e.EditingElement as TextBox;
        //    //        }
        //    //        break;
        //    //}

        //    ////var dbKindComboBox = e.EditingElement as ComboBox;
        //    ////if (dbKindComboBox != null)
        //    ////{
        //    ////    var dbInfo = e.Row.Item as DatabaseInfo;
        //    ////    switch ((DatabaseKind)(e.EditingElement as ComboBox).SelectedItem)
        //    ////    {
        //    ////        case DatabaseKind.Oracle:
        //    ////            dbInfo.ConnectionString = "template";
        //    ////            break;
        //    ////    }
        //    ////}

        //    ////if(e.Column.)
        //}

        //private string GetConnectionStringTemplate(DatabaseKind dbKind)
        //{
        //    return dbKind.ToString() + "Template";
        //}

        //private void SourceDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        //{

        //}

        //private void sourceDataGrid_InitializingNewItem(object sender, InitializingNewItemEventArgs e)
        //{
        //    var newItem = (CustomDatabaseEntity)e.NewItem;
        //    newItem.ConnectionName = "";
        //    newItem.ConnectionString = "";
        //}
    }
}
