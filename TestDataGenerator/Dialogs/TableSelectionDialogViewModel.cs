using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;
using TestDataGenerator.Common;
using TestDataGenerator.Models;
using TestDataGeneratorLib.Entity;
using TestDataGeneratorLib.Reader;
using TestDataGeneratorLib.Utils;

namespace TestDataGenerator.Dialogs
{
    class TableSelectionDialogViewModel : BindableObject
    {
        private TableSelectionDialog view;

        private ObservableCollection<ConnectionModel> connections;
        public ObservableCollection<ConnectionModel> Connections
        {
            get => connections;
            set
            {
                connections = value;
                SelectedConnection = (Connections?.Count > 0) ? Connections[0] : null; // TODO
            }
        }

        public ConnectionModel SelectedConnection { get; set; }

        private List<TableModel> tables = new List<TableModel>();
        public List<TableModel> Tables
        {
            get => tables;
            set
            {
                tables = value;
                NotifyPropertyChanged();
            }
        }

        public List<TableModel> SelectedTables { get; set; } = new List<TableModel>();

        public TableSelectionDialogViewModel(TableSelectionDialog view)
        {
            this.view = view;
        }

        public ICommand OKCommand => new DelegateCommand((p) =>
        {
            var selectedItems = p as IList;
            //SelectedTables = selectedItems.Cast<TableEntity>().ToList();

            //SelectedTables = SelectedTables.Where(t => t.ConnectionInfo.ConnectionName != SelectedConnection.ConnectionName)
            //                               .Concat(selectedItems.Cast<TableModel>())
            //                               .ToList();

            view.DialogResult = true;
            view.Close();
        });

        public void ChangeConnectionSelection(object newConnection)
        {
            MetaDBReaderFactory readerFactory = new MetaDBReaderFactory();
            var reader = readerFactory.CreateReader(newConnection as ConnectionModel);
            var allTables = reader.GetAllTables();
            if (allTables == null)
            {
                return;
            }

            Tables = allTables.Select(t =>
            {
                bool isSelected = SelectedTables.Any(s => s.ConnectionInfo == t.ConnectionInfo
                                                          && s.DatabaseName == t.DatabaseName
                                                          && s.Schema == t.Schema
                                                          && s.TableName == t.TableName
                                                          && s.TableType == t.TableType);
                return new TableModel(t, isSelected);
            })
            .ToList();
        }

        public void ChangeTableSelection(IList addedItems, IList removedItems/*IList selectedItems*/)
        {
            //SelectedTables = SelectedTables.Where(t => t.ConnectionInfo.ConnectionName != SelectedConnection.ConnectionName)
            //                              .Concat(selectedItems.Cast<TableModel>())
            //                              .ToList();
            //var selectedTables = selectedItems.Cast<TableModel>();

            //SelectedTables.RemoveAll(t => t.ConnectionInfo.ConnectionName == SelectedConnection.ConnectionName && !selectedTables.Contains(t));

            //SelectedTables.AddRange(selectedTables.Where(t => !SelectedTables.Contains(t)));

            //var removingTables = new List<TableModel>();
            //var addingTables = new List<TableModel>();
            //foreach (TableModel item in selectedItems)
            //{

            //}


            //return;

            //foreach(var item in removedItems)
            //{
            //    SelectedTables.Remove()
            //}
            var removingTables = removedItems.Cast<TableModel>();

            SelectedTables.RemoveAll(t => t.ConnectionInfo == SelectedConnection && removingTables.Contains(t));
            SelectedTables = SelectedTables.Union(addedItems.Cast<TableModel>()).ToList();

            //SelectedTables.AddRange(addedItems.Cast<TableModel>());
        }

        public void Filter(string text)
        {
            var dataView = CollectionViewSource.GetDefaultView(Tables);
            dataView.Filter = new Predicate<object>((item) => (item as TableModel).TableName.Contains(text));
        }
    }
}
