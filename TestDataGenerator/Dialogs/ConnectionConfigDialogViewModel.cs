using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TestDataGenerator.Common;
using TestDataGenerator.Models;
using TestDataGeneratorLib.Common;

namespace TestDataGenerator.Dialogs
{
    public class ConnectionConfigDialogViewModel
    {
        //private const string DIALOG_FILE_FILTER = "XML Files|*.xml|All Files|*.*";

        private readonly ConnectionConfigDialog view;

        private readonly ObservableCollection<ConnectionModel> connections = new ObservableCollection<ConnectionModel>();
        public ObservableCollection<ConnectionModel> Connections
        {
            get => connections;
            set
            {
                connections.Clear();
                foreach (var c in value)
                {
                    connections.Add(c);
                }
            }
        }

        public ConnectionConfigDialogViewModel(ConnectionConfigDialog view)
        {
            this.view = view;
        }

        public ICommand BuildConnectionCommand => new DelegateCommand((p) =>
        {
            var row = p as ConnectionModel;
            var buildConnectionDialog = new BuildConnectionDialog()
            {
                Owner = view,
                ConnectionString = row.ConnectionString
            };
            if (buildConnectionDialog.ShowDialog() ?? false)
            {
                row.ConnectionString = buildConnectionDialog.ConnectionString;
            }
        });

        public ICommand OKCommand => new DelegateCommand((p) =>
        {
            ConfigUtil.SaveConnections(Connections);

            view.DialogResult = true;
            view.Close();
        });

        public ICommand CancelCommand => new DelegateCommand((p) =>
        {
            view.Close();
        });

        //public ICommand SaveCommand => new DelegateCommand((p) =>
        //{
        //    var saveFileDialog = new SaveFileDialog()
        //    {
        //        InitialDirectory = GetDefaultConnectionPath(),
        //        FileName = "Connections_" + DateTime.Now.ToString("yyyyMMdd_HHmmss"),
        //        DefaultExt = "xml",
        //        Filter = DIALOG_FILE_FILTER
        //    };

        //    if (saveFileDialog.ShowDialog() ?? false)
        //    {
        //        SerializationUtil.Serialize(Connections, saveFileDialog.FileName);
        //    }
        //});

        //public ICommand LoadCommand => new DelegateCommand((p) =>
        //{
        //    var openFileDialog = new OpenFileDialog()
        //    {
        //        InitialDirectory = GetDefaultConnectionPath(),
        //        DefaultExt = "xml",
        //        Filter = DIALOG_FILE_FILTER
        //    };

        //    if (openFileDialog.ShowDialog() ?? false)
        //    {
        //        Connections = SerializationUtil.Deserialize<ObservableCollection<ConnectionModel>>(openFileDialog.FileName);
        //    }
        //});

        public ICommand RemoveSelectedRowsCommand => new DelegateCommand((p) =>
        {
            if (MessageBox.Show("Are you sure to delete selected connection(s)?",
                                "Database Connections",
                                MessageBoxButton.OKCancel,
                                MessageBoxImage.Question) != MessageBoxResult.OK)
            {
                return;
            }

            var selectedItems = (IList)p;
            var removingItems = selectedItems.OfType<ConnectionModel>().Join(Connections,
                                                                              s => s.ConnectionName,
                                                                              dbInfo => dbInfo.ConnectionName, (s, dbInfo) => dbInfo)
                                                                        .ToList();
            foreach (var dbInfo in removingItems)
            {
                Connections.Remove(dbInfo);
            }
        });

        public void CloneConnections(ObservableCollection<ConnectionModel> cs)
        {
            connections.Clear();
            foreach (var c in cs)
            {
                connections.Add(new ConnectionModel()
                {
                    Kind = c.Kind,
                    ConnectionName = c.ConnectionName,
                    ConnectionString = c.ConnectionString
                });
            }
        }

        //private string GetDefaultConnectionPath()
        //{
        //    return Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, "Connections");
        //}
    }
}
