using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using TestDataGenerator.Common;
using TestDataGenerator.Dialogs;
using TestDataGenerator.Models;
using TestDataGeneratorLib.Common;
using TestDataGeneratorLib.DataSource;
using TestDataGeneratorLib.Entity;
using TestDataGeneratorLib.Reader;
using TestDataGeneratorLib.Utils;
using TestDataGeneratorLib.Writer;

namespace TestDataGenerator
{
    class MainWindowViewModel : BindableObject
    {
        private const int DEFAULT_GENERATE_ROW_COUNT = 5;

        private MainWindow view;

        private ObservableCollection<ConnectionModel> connections;

        public ObservableCollection<TableModel> Tables { get; set; } = new ObservableCollection<TableModel>();

        /// <summary>
        /// Store both meta data and generated data
        /// </summary>
        public ObservableCollection<DataTable> TablesData { get; set; } = new ObservableCollection<DataTable>();

        private TableModel selectedTable;
        public TableModel SelectedTable
        {
            get => selectedTable;
            set
            {
                selectedTable = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged(nameof(SelectedDataTable));
            }
        }

        public DataTable SelectedDataTable => TablesData.FirstOrDefault(r => r.GetExtendedTableInfo() == selectedTable);

        public int RowsCount { get; set; } = DEFAULT_GENERATE_ROW_COUNT;

        public MainWindowViewModel(MainWindow view)
        {
            this.view = view;
            connections = ConfigUtil.LoadConnections();
        }

        public ICommand GenerateCommand => new DelegateCommand((parameter) =>
        {
            var sourceFactoryProducer = new DataSourceFactoryProducer();
            var factory = sourceFactoryProducer.CreateDataSource(DataSourceType.Generator, connections[0]); // TODO
            var dataSource = factory.CreateDataSource();
            dataSource.FillData(TablesData.ToList(), RowsCount);
            //NotifyPropertyChanged("GeneratedData");
        });

        public ICommand SettingCommand => new DelegateCommand((parameter) =>
        {
            var connectionsDialog = new ConnectionConfigDialog(connections)
            {
                Owner = view
            };

            if (connectionsDialog.ShowDialog() ?? false)
            {
                connections = connectionsDialog.Connections;
            }
        });

        public ICommand UpCommand => new DelegateCommand((p) =>
        {
            int i = Tables.IndexOf(SelectedTable);
            if (i <= 0)
            {
                return;
            }

            var currentSelectedTable = SelectedTable;
            Tables.Remove(SelectedTable);
            Tables.Insert(i - 1, currentSelectedTable);
            SelectedTable = currentSelectedTable;
        });

        public ICommand DownCommand => new DelegateCommand((p) =>
        {
            int i = Tables.IndexOf(SelectedTable);
            if (i < 0 || i == Tables.Count - 1)
            {
                return;
            }

            var currentSelectedTable = SelectedTable;
            Tables.Remove(SelectedTable);
            Tables.Insert(i + 1, currentSelectedTable);
            SelectedTable = currentSelectedTable;
        });


        public ICommand ChangeCommand => new DelegateCommand((p) =>
        {
            var tableSelectionDialog = new TableSelectionDialog()
            {
                Owner = view,
                Connections = connections,
                SelectedTables = Tables.ToList()
            };
            if (tableSelectionDialog.ShowDialog() ?? false)
            {
                Tables.Clear();
                var factory = new MetaDBReaderFactory();
                foreach (var table in tableSelectionDialog.SelectedTables)
                {
                    Tables.Add(table); //TODO

                    var reader = factory.CreateReader(table.ConnectionInfo);
                    TablesData.Add(reader.GetTableMetaData(table));
                }
            }
        });

        public ICommand RemoveCommand => new DelegateCommand((p) =>
        {
            int selectedIndex = Tables.IndexOf(SelectedTable);
            Tables.Remove(SelectedTable);

            if (selectedIndex == Tables.Count)
            {
                selectedIndex = Tables.Count - 1;
            }

            SelectedTable = Tables.Count > 0 ? Tables[selectedIndex] : null;
        });

        public ICommand OutputCommand => new DelegateCommand((p) =>
        {
            var writerKind = (WriterKind)p;

            var factory = new WriterFactory();
            var writer = factory.CreateWriter(writerKind);
            var output = writer.Write(GetOrderedTablesData().ToList());

            switch (writerKind)
            {
                case WriterKind.SQLCommandText:
                    MessageBox.Show(output as string);
                    break;
                case WriterKind.TabDelimitedText:
                    MessageBox.Show(output as string);
                    break;
                case WriterKind.ExcelFile:
                    break;
                case WriterKind.Database:
                    break;
            }
        });

        private IEnumerable<DataTable> GetOrderedTablesData()
        {
            foreach (var table in Tables)
            {
                yield return TablesData.First(t => t.GetExtendedTableInfo().Equals(table));
            }
        }
    }
}
