using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace TrashHandling.Models
{
    /// <summary>
    /// The class that monitors the dropzone folder.
    /// <para>Created by Kasper</para>
    /// </summary>
    public class Filewatcher
    {
        public static FileSystemWatcher watcher = new();

        /// <summary>
        /// The function that monitors the dropzone
        /// <para>Created by Kasper</para>
        /// </summary>
        /// <param name="path">The folder to monitor</param>
        public static void Monitor(string path)
        {
            watcher.Path = path;
            watcher.Filter = "*.csv";
            watcher.NotifyFilter = NotifyFilters.FileName;
            watcher.Created += OnCreated;
        }

        /// <summary>
        /// The method that fires when a file is added to the folder
        /// <para>Created by Kasper</para>
        /// </summary>
        private static void OnCreated(object sender, FileSystemEventArgs e)
        {
            MessageBox.Show($"En ny fil er blevet tilføjet til Dropzone: {e.Name}.\nDu kan gå til Import siden for at åbne den", "Notifikation om ny fil");
        }
    }
}
