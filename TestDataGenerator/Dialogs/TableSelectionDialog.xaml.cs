using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using TestDataGenerator.Models;
using TestDataGeneratorLib.Entity;

namespace TestDataGenerator.Dialogs
{
    /// <summary>
    /// Interaction logic for TableSelectionDialog.xaml
    /// </summary>
    public partial class TableSelectionDialog : Window
    {
        private TableSelectionDialogViewModel ViewModel;

        public ObservableCollection<ConnectionModel> Connections
        {
            get => ViewModel.Connections;
            set => ViewModel.Connections = value;
        }

        public List<TableModel> SelectedTables
        {
            get => ViewModel.SelectedTables;
            set => ViewModel.SelectedTables = value;
        }

        public TableSelectionDialog()
        {
            InitializeComponent();
            ViewModel = new TableSelectionDialogViewModel(this);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = ViewModel;
        }

        private void connectionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewModel.ChangeConnectionSelection(e.AddedItems[0]);
        }

        private void filterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ViewModel.Filter((sender as TextBox).Text);
        }

        private void tablesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewModel.ChangeTableSelection(e.AddedItems, e.RemovedItems);
            //ViewModel.ChangeTableSelection(tablesListView.SelectedItems);
        }
    }
}
